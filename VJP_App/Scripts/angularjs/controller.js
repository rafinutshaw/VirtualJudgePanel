angular.module('MyApp.controllers', [])
    .controller("MyCtrl1", function ($scope) {
        $scope.message = "Hello from ctrl1";
    })
    .controller("MyCtrl2", function ($scope) {
        $scope.message = "Ctrl2";
    });
