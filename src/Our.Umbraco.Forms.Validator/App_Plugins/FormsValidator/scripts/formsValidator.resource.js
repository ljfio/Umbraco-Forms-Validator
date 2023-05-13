function formsValidatorResource($q, $http, umbRequestHelper) {
    return {
        getAllRules: function () {
            return umbRequestHelper.resourcePromise(
                $http.get(
                    umbRequestHelper.getApiUrl(
                        "formsValidatorRulesApiBaseUrl",
                        "GetAll"
                    )
                ),
                "Failed to retrieve forms validator rules"
            );
        },
        saveSettings: function (id, settings) {
            var query = {
                id: id,
            };

            return umbRequestHelper.resourcePromise(
                $http.post(
                    umbRequestHelper.getApiUrl(
                        "formsValidatorSettingsApiBaseUrl",
                        "Save",
                        query
                    ),
                    settings
                ),
                "Failed to save forms validator settings"
            );
        },
        getSettings: function (id) {
            var query = {
                id: id,
            };

            return umbRequestHelper.resourcePromise(
                $http.get(
                    umbRequestHelper.getApiUrl(
                        "formsValidatorSettingsApiBaseUrl",
                        "Get",
                        query
                    )
                ),
                "Failed to retrieve forms validator settings "
            );
        }
    }
}

angular.module('umbraco.resources')
    .factory('formsValidatorResource', formsValidatorResource);