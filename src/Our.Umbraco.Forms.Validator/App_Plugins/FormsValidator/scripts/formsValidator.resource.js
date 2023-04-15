function formsValidatorResource($q, $http, umbRequestHelper){
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
        }
    }
}

angular.module('umbraco.resources').factory('formsValidatorResource', formsValidatorResource);