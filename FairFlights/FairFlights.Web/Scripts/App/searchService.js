'use strict';

ffApp.factory('flightService', function ($http, $q) {
    
    var service = {

        graphData : [],

        SearchFlight: function (viewData) {
            var self = this;
            self.graphData = viewData;

            var deferred = $q.defer();
            deferred.resolve(true);
            /*
            $http({ method: 'POST', url: url, data: JSON.stringify(viewData), dataType: 'json' })
                .success(function (data, status) {
                    self.graphData = data;
                    deferred.resolve(data);
                })
                .error(function (data, status) {
                    deferred.reject(status);
                });*/

            deferred.reject(false);

            return deferred;
        }
    };

    return service;
});