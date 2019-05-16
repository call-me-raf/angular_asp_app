(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getWords = function () {
                var deferred = $q.defer();
                $http.get('/Word/Index').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addWord = function (word) {
                var deffered = $q.defer();
                $http.post('/Word/Create', word).then(function () {
                    deffered.resolve();
                }, function () {
                        deffered.reject();
                });
                return deffered.promise;
            };

            service.deleteWord = function (id) {
                var deffered = $q.defer();
                $http.post('/Word/Delete', { id: id }).then(function () {
                    deffered.resolve();
                }, function () {
                        deffered.reject();
                });
                return deffered.promise;
            };

            service.reverseWord = function (id) {
                var deffered = $q.defer();
                $http.post('/Word/Reverse', { id: id }).then(function () {
                    deffered.resolve();
                }, function () {
                    deffered.reject();
                });
                return deffered.promise;
            };

            return service;
        }]);
})();