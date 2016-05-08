/// <reference path="Scripts/angular.js" />
var x = angular.module("Main", []);
x.controller("DeptController", f1);

function f1($scope) {
    var data = [
            { Deptno: 10, Dname: "Computers", Loc: "true" },
            { Deptno: 20, Dname: "Sales", Loc: "false" },
            { Deptno: 30, Dname: "Marketing", Loc: "true" },
            { Deptno: 40, Dname: "Others", Loc: "true" }
    ];
    $scope.Depts = data;
    $scope.Add = function() {
        $scope.Depts.push({ Deptno: $scope.Deptno, Dname: $scope.Dname, Loc: $scope.Loc });
        $scope.Deptno = "";
        $scope.Dname = "";
        $scope.Loc = "";
    }
}




