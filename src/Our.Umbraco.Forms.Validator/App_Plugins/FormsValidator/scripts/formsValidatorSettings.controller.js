(function () {
    "use strict";

    function FormsValidatorSettingsController($routeParams, $scope, formService, formsValidatorResource, editorService, eventsService) {
        var vm = this;

        vm.settings = [];
        
        vm.settingsProperties = [
            {
                "alias": "field",
                "header": "Field"
            }
        ];

        vm.editSetting = function () {

        }

        vm.newSetting = function () {
            var options = {
                title: "Rule settings",
                size: "small",
                view: "/App_Plugins/FormsValidator/views/ruleSettingEditor.html",
                submit: function (model) {
                    vm.settings.push({
                        name: model.rule.name,
                        icon: model.rule.icon,
                        field: model.field.alias,
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

        if (!$routeParams.create && $routeParams.id > 0) {
        }
        
        var unsubscribe = eventsService.on('umbracoForms.saved', function (event, args){
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
