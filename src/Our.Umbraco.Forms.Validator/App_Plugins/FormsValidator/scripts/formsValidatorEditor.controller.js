(function () {
    "use strict";

    function FormsValidatorEditorController($scope, eventsService, editorService) {
        var vm = this;

        vm.selectedRule = null;

        var resetValues = function () {
            vm.selection = {};
            vm.values = {};

            if (vm.selectedRule) {
                vm.selectedRule
                    .settingFields
                    .forEach(field => {
                        if (field.type === 'toggle')
                            vm.values[field.alias] = false;
                        else
                            vm.values[field.alias] = null;
                    });
            }
        };

        resetValues();

        vm.submit = function () {
            if ($scope.model.submit) {
                $scope.model.rule = vm.selectedRule;
                $scope.model.values = vm.values;

                $scope.model.submit($scope.model);
            }
        }

        vm.close = function () {
            if ($scope.model.close) {
                $scope.model.close();
            }
        }

        vm.openRulePicker = function () {
            var options = {
                title: "Rules",
                size: "small",
                view: "/App_Plugins/FormsValidator/views/rulePicker.html",
                submit: function (model) {
                    vm.selectedRule = model.rule;

                    resetValues();

                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.open(options);
        }

        vm.removeSelectedRule = function () {
            vm.selectedRule = null;
            resetValues();
        }

        vm.openFieldPicker = function (alias) {
            var options = {
                title: "Field",
                size: "small",
                view: "/App_Plugins/FormsValidator/views/fieldPicker.html",
                submit: function (model) {
                    vm.selection[alias] = model.field;
                    vm.values[alias] = model.field.id;

                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.open(options);
        }

        vm.toggleValue = function (alias) {
            vm.values[alias] = !vm.values[alias];
        }

        vm.removeValue = function (alias) {
            delete vm.values[alias];
        }
    }

    angular.module("umbraco")
        .controller("FormsValidator.SettingEditor", FormsValidatorEditorController);
})();