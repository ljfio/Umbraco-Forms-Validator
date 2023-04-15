(function () {
    "use strict";

    function FormsValidatorEditorController($scope, eventsService, editorService, formService, editorState) {
        var vm = this;

        var state = editorState.getCurrent();
        vm.fields = formService.getAllFields(state);

        vm.rules = [];
        vm.selectedRule = null;

        vm.selectedField = null;
        vm.fieldSelectorOpen = false;

        vm.stopProcessing = false;

        vm.submit = function () {
            if ($scope.model.submit) {
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
                size: "medium",
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

        vm.removeSelectedRule = function () {
            vm.selectedRule = null;
        }

        vm.selectField = function (field) {
            vm.selectedField = field;
            vm.closeFieldSelector();
        }

        vm.removeField = function () {
            vm.selectedField = null;
        }

        vm.openFieldSelector = function () {
            vm.fieldSelectorOpen = true;
        }

        vm.closeFieldSelector = function () {
            vm.fieldSelectorOpen = false;
        }

        vm.toggleStopProcessing = function () {
            vm.stopProcessing = !vm.stopProcessing;
        }
    }

    angular.module("umbraco")
        .controller("FormsValidator.SettingEditor", FormsValidatorEditorController);
})();