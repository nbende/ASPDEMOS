/// <reference path="angular.js" />
var app = angular.module("ApiMod", []);
app.factory("JobsService", function ($http) {
    var JobsData = {};
    JobsData.GetJobs = function () {
        return $http.get("http://localhost:18347/api/jobs");
    }
    return JobsData;
});
app.factory("AddJobsService", function ($http) {
    var JobsData = {};
    JobsData.AddJob = function (jobrec) {
        var prom = $http({
            method: "POST",
            url: "http://localhost:18347/api/jobs",
            data: jobrec
        })
        return prom;
    }
    return JobsData;
});

app.controller("AddJobsController", function (AddJobsService,$scope) {
    var job = {}; // preparing the model
    job.job_id = 0;
    job.job_desc = "";
    job.min_lvl = 0;

    job.ddmax = [
        { Name: "Prog10", Val: "10" },
        { Name: "Anal20", Val: "20" },
        { Name: "Dev30", Val: "30" },
        { Name: "Others", Val: "40" }
    ];

    job.Interested = true;
    job.AddJobdata = function () {
        // code to push $scope.Job data into a model which perfectly fits for our api
        AddJobsService.AddJob($scope.Job);
        alert("New Job Created");
    }
    $scope.Job = job;
})

app.controller("JobsController", function (JobsService,$scope) {
    JobsService.GetJobs().success(f1).error(e1);

    function f1(res) {
        $scope.JData = res;
    }
    function e1() {
        alert("Failed to invoke the service");
    }
})