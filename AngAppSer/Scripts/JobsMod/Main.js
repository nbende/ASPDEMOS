/// <reference path="../angular.js" />
var app = angular.module("AppService", []);

app.factory("JService", function ($http) {
    // code here
    var jobsdata = {};
    jobsdata.getJobs = function () {
        return $http.get("http://localhost:12162/api/jobs");
    }
    return jobsdata;
});

// custom filter
app.filter("ReverseData", function () {
    return function (text) {
        return text.split("").reverse().join("");
    }
});

app.controller("JobsController", function ($scope, JService) {
    JService.getJobs().success(s1).error(e1);

    function s1(res) {
        $scope.Jobs = res;
    }
    function e1() {
        alert("Error Could not invoke the service");
    }
})

app.controller("Summary", function ($scope, JService) {
    JService.getJobs().success(function (res) {
        $scope.data = res;
    })
});