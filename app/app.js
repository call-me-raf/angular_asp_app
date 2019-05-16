(function () {
    'use strict';

    angular
        .module('app', [
            'ngRoute'
        ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');

            $routeProvider
                .when('/', {
                    controller: 'wordCtrl',
                    templateUrl: '/app/templates/word.html'
                })
                .when('/addword', {
                    controller: 'wordAddCtrl',
                    templateUrl: '/app/templates/wordAdd.html'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();   