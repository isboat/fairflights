'use strict';

ffApp.factory('flightService', function ($http, $q) {
    
    var service = {

        graphData : [],

        SearchFlight: function (viewData) {
            var self = this;
            self.graphData = viewData;

            var deferred = $q.defer();
            
            $http({ method: 'POST', url: "/api/Flight/SearchFlight", data: JSON.stringify(viewData), dataType: 'application/json',  headers: { 'Content-Type': 'application/json' } })
                .success(function (data, status) {
                    self.graphData = data;
                    deferred.resolve(data);
                })
                .error(function (data, status) {
                    deferred.reject(status);
                });
            
            return deferred.promise;
        }
    };

    return service;
});