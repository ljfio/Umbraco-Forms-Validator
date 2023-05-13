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
                "Failed to retrieve data for forms validator rules"
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
                "Failed to save forms validator rules"
            );
        }
    }
}

angular.module('umbraco.resources')
    .factory('formsValidatorResource', formsValidatorResource);