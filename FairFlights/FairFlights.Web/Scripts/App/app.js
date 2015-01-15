'use strict';

var ffApp = angular.module('ffApp', ['ngRoute']).config(function ($routeProvider) {

    $routeProvider.when('/view',
        {
            templateUrl: 'Views/Home/view.html',
            controller: 'graphController'
        });
    
    $routeProvider.when('/',
        {
            templateUrl: 'Templates/SearchPage.html',
            controller: 'searchController'
        });

    $routeProvider.otherwise({ redirectTo: '/'});
});

ffApp.run();