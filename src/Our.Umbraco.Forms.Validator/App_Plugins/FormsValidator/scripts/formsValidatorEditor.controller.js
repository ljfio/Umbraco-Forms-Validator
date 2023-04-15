(function () {
    "use strict";
    
    function FormsValidatorEditorController($scope, formsValidatorResource) {
        var vm = this;

        vm.rules = [];
        vm.selectedRule = {};
        
        vm.fields = [];
        vm.selectedField = "";
        
        vm.stopProcessing = false;
        
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
        
        vm.selectRule = function (){
            
        }
        
        vm.toggleStopProcessing = function() {
            vm.stopProcessing = !vm.stopProcessing;
        }

        formsValidatorResource.getAllRules()
            .then(function (rules) {
                vm.rules = rules;
            });
    }

    angular.module("umbraco")
        .controller("FormsValidator.SettingEditor", FormsValidatorEditorController);
})();