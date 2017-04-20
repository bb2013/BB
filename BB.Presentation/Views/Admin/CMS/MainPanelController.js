var routerApp = angular.module('routerApp', ['ui.router']);

routerApp.config(function($stateProvider, $urlRouterProvider) {    
    $urlRouterProvider.otherwise('/cms');

    $stateProvider
        .state('cms', {
            url: '/cms',
            views: {
                // the main template will be placed here (relatively named)
                '': { templateUrl: '/Views/Admin/CMS/bodyPanel/bodyPanelIndex.html' },

                // the child views will be defined here (absolutely named)
                'leftPanel@cms': {
                    templateUrl: '/Views/Admin/CMS/bodyPanel/leftPanel/LeftPanelIndex.html',
                    controller: 'scotchController4'
                },

                // for column two, we'll define a separate controller 
                'rightPanel@cms': {
                    templateUrl: '/Views/Admin/CMS/bodyPanel/rightPanel/RightPanelIndex.html',
                    controller: 'scotchController4'
                }
            }
        });
});

routerApp.controller('scotchController4', function ($scope) {
    $scope.left = "left";
    $scope.main = "main";
    $scope.right = "right";
});