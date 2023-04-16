(function() {
    "use strict";

    function FormsValidatorFieldPickerController($scope, formService, editorState) {
        var vm = this;

        var state = editorState.getCurrent();
        vm.fields = formService.getAllFields(state);

        vm.submit = function () {
            if ($scope.model.submit) {
                $scope.model.submit($scope.model);
            }
        }

        vm.close = function (){
            if ($scope.model.close) {
                $scope.model.close();
            }
        }

        vm.selectField = function(rule){
            $scope.model.field = rule;
            vm.submit();
        }
    }

    angular.module("umbraco")
        .controller("FormsValidator.FieldPicker", FormsValidatorFieldPickerController);
})();