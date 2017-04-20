var mainApp = angular.module("mainApp", ['ngRoute']);

mainApp.config(function ($routeProvider) {
    $routeProvider
        .when(login,
        {
            templateUrl: '/Views/Authentication/Login.html',
            controller: 'HomeController'
        })
        .when(std,
        {
            templateUrl: '/Views/Authentication/viewStudents.html',
            controller: 'StudentController'
        })
        .otherwise({
            redirectTo: login
        });
});

mainApp.controller('StudentController', function ($scope) {
    $scope.students = [
		{ name: 'Mark Waugh', city: 'New York' },
		{ name: 'Steve Jonathan', city: 'London' },
		{ name: 'John Marcus', city: 'Paris' }
    ];

});

var login = "/Login";

var std = "/viewStudents";