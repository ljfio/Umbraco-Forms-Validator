(function () {
    "use strict";
    
    function FormsValidatorEditorController($scope, formsValidatorResource) {
        var vm = this;

        vm.rules = [];
        
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

        formsValidatorResource.getAllRules()
            .then(function (rules) {
                vm.rules = rules;
            });
    }

    angular.module("umbraco")
        .controller("FormsValidator.SettingEditor", FormsValidatorEditorController);
})();