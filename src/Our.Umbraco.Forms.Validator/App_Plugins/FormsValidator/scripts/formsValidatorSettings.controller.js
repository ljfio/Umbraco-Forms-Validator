(function () {
    function FormsValidatorSettingsController($routeParams, formResource, formsValidatorResource, editorService) {
        var vm = this;

        vm.settings = [];

        vm.settingsProperties = [
            {
                "alias": "description",
                "header": "Description"
            }
        ];

        vm.editSetting = function () {

        }

        vm.newSetting = function () {
            var options = {
                title: "New Validaton Rule",
                size: "small",
                view: "/App_Plugins/FormsValidator/views/ruleSettingEditor.html",
                submit: function (model) {
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
    }

    angular.module("umbraco")
        .controller("FormsValidator.SettingsContentApp", FormsValidatorSettingsController);
})();