(function () {
    "use strict";

    function FormsValidatorSettingsController($routeParams, $scope, formService, formsValidatorResource, editorService, eventsService) {
        var vm = this;

        vm.settings = [];
        
        vm.settingSelected = false;

        vm.settingsProperties = [
            {
                "alias": "description",
                "header": "Description"
            },
        ];

        vm.selectSetting = function (setting) {
            setting.selected = !setting.selected;
            
            vm.settingSelected = false;
            
            _.each(vm.settings, (e, i) => {
                if (e.selected) {
                    vm.settingSelected = true;
                }
            });
        }

        vm.editSetting = function (setting) {
            debugger;
        }
        
        vm.deleteSettings = function () {
            
        }

        vm.newSetting = function () {
            var options = {
                title: "Rule settings",
                size: "medium",
                view: "/App_Plugins/FormsValidator/views/ruleSettingEditor.html",
                submit: function (model) {
                    vm.settings.push({
                        name: model.rule.name,
                        description: model.rule.description,
                        icon: model.rule.icon,
                        data: {
                            rule: model.rule.id,
                            values: model.values,
                        },
                        selected: false,
                    });

                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.open(options);
        }
        
        const getAllRules = function() {
            formsValidatorResource.getAllRules()
                .then(rules => {
                    formsValidatorResource.getSettings($routeParams.id)
                        .then(settings => {
                            vm.settings = settings.map(setting => {
                                const [rule] = rules.filter(rule => rule.id == setting.rule);

                                return {
                                    name: rule.name,
                                    description: rule.description,
                                    icon: rule.icon,
                                    data: {
                                        ...setting,
                                    },
                                    selected: false
                                };
                            });
                        });
                });
        }

        if (!$routeParams.create) {
            getAllRules();
        }

        var unsubscribe = eventsService.on('umbracoForms.saved', function (event, args) {
            debugger;

            var settings = vm.settings.map(setting => setting.data);

            formsValidatorResource.saveSettings(args.id, settings)
                .then(() => {
                   getAllRules(); 
                });
        });

        $scope.$on("$destroy", function () {
            unsubscribe();
        });
    }

    angular.module("umbraco")
        .controller("FormsValidator.SettingsContentApp", FormsValidatorSettingsController);

    angular.module('umbraco.services')
        .config(['$provide', function ($provide) {
            return $provide.decorator('formResource', ['$delegate', 'eventsService', function ($delegate, eventsService) {
                var original = $delegate.saveWithWorkflows;

                $delegate.saveWithWorkflows = function (formWithWorkflows) {
                    return original(formWithWorkflows)
                        .then(function (response) {
                            eventsService.emit('umbracoForms.saved', {
                                id: response.data.id,
                            });

                            return response;
                        });
                };

                return $delegate;
            }]);
        }]);
})();
