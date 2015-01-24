'use strict';

ffApp.controller('searchController', function searchController($rootScope, $scope, $location, flightService) {

    $scope.Message = "Message from searchController";

    $scope.IsReturn = false;

    $('.classGroup').chosen();

    $scope.FormData = {
        OverTwelve: 1,
        UnderTwelve: 0,
        UnderTwo: 0,
        CabinClass: 'Economy'
    };

    // public functions
    $scope.SubmitForm = function() {
        console.log($scope.FormData);
        $location.path('/view');
        /*flightService.SearchFlight(viewData).then(
            function (data) {
                if (data) {
                    //redirect to graph page
                    $location.path('/view');

                    console.log(data);
                }
            },
            function (status) {
                console.log(status);
            }
        );*/
    }
});