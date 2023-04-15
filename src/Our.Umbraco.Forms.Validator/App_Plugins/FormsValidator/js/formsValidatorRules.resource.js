function formsValidatorRulesResource($q, $http, umbRequestHelper){
    return {
        getAll: function () {
            return umbRequestHelper.resourcePromise(
                $http.get(
                    umbRequestHelper.getApiUrl(
                        "formsValidatorRulesApiBaseUrl",
                        "GetAll"
                    )
                ),
                "Failed to retrieve data for forms validator rules"
            );
        }
    }
}

angular.module('umbraco.resources').factory('formsValidatorRulesResource', formsValidatorRulesResource);