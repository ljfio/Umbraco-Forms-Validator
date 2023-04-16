(function () {
    "use strict";

    function FormsValidatorEditorController($scope, eventsService, editorService) {
        var vm = this;
        
        vm.selectedRule = null;
        vm.selectedField = null;
        
        vm.customMessage = null;
        vm.stopProcessing = false;

        vm.submit = function () {
            if ($scope.model.submit) {
                
                $scope.model.rule = vm.selectedRule;
                $scope.model.field = vm.selectedField;
                $scope.model.message = vm.customMessage;
                $scope.model.stopProcessing = vm.stopProcessing;
                
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
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.open(options);
        }

        vm.openFieldPicker = function () {
            var options = {
                title: "Field",
                size: "small",
                view: "/App_Plugins/FormsValidator/views/fieldPicker.html",
                submit: function (model) {
                    vm.selectedField = model.field;
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
        }

        vm.removeField = function () {
            vm.selectedField = null;
        }

        vm.toggleStopProcessing = function () {
            vm.stopProcessing = !vm.stopProcessing;
        }
    }

    angular.module("umbraco")
        .controller("FormsValidator.SettingEditor", FormsValidatorEditorController);
})();