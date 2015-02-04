'use strict';

ffApp.controller('searchController', function searchController($rootScope, $scope, $location, flightService) {

    $scope.Message = "Message from searchController";
    $scope.FormData = {
        DateRange: '1'
    };
    
    // Event bindings
    (function () {
        $('.dateRange_chosen').chosen();
    
        var $datepicker = $('#departureDate').pikaday({
            firstDay: 1,
            minDate: new Date('2000-01-01'),
            maxDate: new Date('2020-12-31'),
            yearRange: [2000, 2020]
        });
        $('#departureDateBtn').click(function () {
            $datepicker.pikaday('show');
        });
        
        var ad = $('#arrivalDate').pikaday({
            firstDay: 1,
            minDate: new Date('2000-01-01'),
            maxDate: new Date('2020-12-31'),
            yearRange: [2000, 2020]
        });
            
        $('#arrivalDateBtn').click(function () {
            ad.pikaday('show');
        });
        
    })();

    // public functions
    
    $scope.SubmitForm = function() {
        console.log($scope.FormData);
        uiHelper.ShowBusy();
        flightService.SearchFlight($scope.FormData).then(
            function(data) {
                if (data) {
                    uiHelper.HideBusy();
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