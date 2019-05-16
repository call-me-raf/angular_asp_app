(function () {
    'use strict';

    angular
        .module('app')

        .controller('wordCtrl', ['$scope', '$filter', 'dataService', function ($scope, $filter, dataService) {
            $scope.words = [];
            getData();
            function getData() {
                dataService.getWords().then(function (result) {
                    $scope.words = result;
                });
            }
            $scope.deleteWord = function (id) {
                dataService.deleteWord(id).then(function () {
                    toastr.success('Слово успешно удалено');
                    getData();
                });
            }
            $scope.reverseWord = function (id) {
                dataService.reverseWord(id).then(function () {
                    getData();
                });
            }
            $scope.createWord = function (word) {
                dataService.addWord(word).then(function () {
                    toastr.success('Слово успешно зашифровано');
                });
            }
        }])
        .controller('wordAddCtrl', ['$scope', '$location', 'dataService', '$rootScope', function ($scope, $location, dataService) {
            $scope.createWord = function (word) {
                dataService.addWord(word).then(function () {
                    toastr.success('Слово успешно зашифровано');
                    $location.path('/');
                });
            };
            }]);
})();