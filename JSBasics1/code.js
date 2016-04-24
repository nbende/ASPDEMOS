/// <reference path="Scripts/angular.js" />
var x = angular.module("app1", []);
x.controller("ctrl1", function ctrl1($scope) {
    var courses = ['ASP.NET MVC', 'ASP.NET Web Forms', 'MS AZURE', 'ASP.NET CORE 1.0'];
    $scope.CourseList = courses;
});