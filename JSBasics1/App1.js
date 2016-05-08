/// <reference path="Scripts/angular.js" />
var x = angular.module("Main", []);
x.controller("SDept", c1);

function c1($scope) {
    // dept is model
    var dept = { Deptno: 10, Dname: "Computers", Loc: "India" };
    $scope.deptrec = dept;
}