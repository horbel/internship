/// <reference path="Scripts/angular.min.js" />
//'mgcrea.ngStrap'
///
var myApp = angular.module('myApp', []);
myApp.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true).hashPrefix('*');
       $routeProvider
        .when('/home', {
            templateUrl: '/index.html',
            controller: 'personController'
        })
    .when('/newPersonForm', {
        templateUrl: '/efTemplate.html',
        controller: 'efPersonController'
    })
    .when('/editPersonForm', {
        templateUrl: '/editForm.html',
        controller: 'efPersonController'
    });
})
myApp.controller('personController', function ($scope, $http, $location) {
    $http.get('persons.json').success(function (data) {
        $scope.persons = data;
        $scope.phoneTypeOptions = [
            { title: 'Home phone number', id: 0 },
            { title: 'Fax number', id: 1 }
        ];
        $scope.currentPhoneType = $scope.phoneTypeOptions[0];
        $scope.removePerson = function (personToRemove) {
            var index = $scope.persons.indexOf(personToRemove);
            $scope.persons.splice(index, 1);
        }
        //$scope.showCreatePersonForm = function () {
        //    $modal.open({                
        //        templateUrl: '/efTemplate.html',
        //        controller: 'personController'
        //    });
        //}
        $scope.showEditPersonForm = function (person) {
            $scope.currentFirstName = person.firstName;
            $scope.currentLastName = person.lastName;
        }

    });
})