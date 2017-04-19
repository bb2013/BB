var leftNavigation = angular.module("leftNavigation", ['ngRoute']);

leftNavigation.config(function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: '/Views/Admin/CMS/leftPanel/addPages/Page.html',
            controller: 'PageController'
        })
        .otherwise({
            redirectTo: "/"
        });
});

leftNavigation.controller('PageController', function ($scope) {
    $scope.pagename = "pages pages";
});

var mainNavigation = angular.module("mainNavigation", ['ngRoute']);

mainNavigation.config(function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: '/Views/Admin/CMS/leftPanel/addPages/Page.html',
            controller: 'PageController'
        })
        .otherwise({
            redirectTo: "/"
        });
});

mainNavigation.controller('PageController', function ($scope) {
    $scope.pagename1 = "pages pages 123";
});