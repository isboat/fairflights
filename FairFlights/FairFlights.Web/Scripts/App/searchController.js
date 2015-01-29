'use strict';

ffApp.controller('searchController', function searchController($rootScope, $scope, $location, flightService) {

    $scope.Message = "Message from searchController";

    $('.classGroup').chosen();

    $scope.FormData = {
        IsReturn : false,
        OverTwelve: 1,
        UnderTwelve: 0,
        UnderTwo: 0,
        CabinClass: 'Economy'
    };

    // public functions
    $scope.SubmitForm = function() {
        console.log($scope.FormData);

        flightService.SearchFlight($scope.FormData).then(
            function(data) {
                if (data) {
                    //redirect to graph page
                    $location.path('/view');

                    console.log(data);
                }
            },
            function(status) {
                console.log(status);
            }
        );
    };
});