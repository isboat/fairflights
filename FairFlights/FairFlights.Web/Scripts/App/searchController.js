'use strict';

ffApp.controller('searchController', function searchController($rootScope, $scope) {

    $scope.Message = "Message from searchController";

    $('.classGroup').chosen();
});