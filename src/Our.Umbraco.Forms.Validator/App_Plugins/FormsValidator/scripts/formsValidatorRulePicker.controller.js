(function() {
    "use strict";
    
    function FormsValidatorRulePickerController($scope, formsValidatorResource) {
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
        
        vm.selectRule = function(rule){
            $scope.model.rule = rule;
            vm.submit();
        }

        formsValidatorResource.getAllRules()
            .then(function (rules) {
                vm.rules = rules;
            });
    }

    angular.module("umbraco")
        .controller("FormsValidator.RulePicker", FormsValidatorRulePickerController);
})();