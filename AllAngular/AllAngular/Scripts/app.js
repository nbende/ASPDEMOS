/// <reference path="../Scripts/angular.js" />
/// <reference path="../Scripts/angular-route.js" />
var x = angular.module('rtApp', ['ngRoute']);        // <p loadingbar>waiting</p>
x.config(['$routeProvider',function ($routeProvider) {
      $routeProvider.
        when('/addJobs', {
            templateUrl: '/addjobs1.html',
            controller: 'AddJobsController'
        }).
        when('/showJobs', {
            templateUrl: '/present.html',
            controller: 'ShowJobsController'
        }).
        otherwise({
            redirectTo: '/addJobs'
        });
}]);
x.directive('loadingbar', ['$rootScope',
function ($rootScope) {
    return {
        link: function (scope, element, attrs) {
            element.addClass('hide');
            $rootScope.$on('$routeChangeStart', function () {
                element.removeClass('hide');
            });
            $rootScope.$on('$routeChangeSuccess', function () {
                element.addClass('hide');
            });
        }
    };
}]);
x.factory("JobsDataService", function ($http) {
    var jobrec = {};
    jobrec.AddJobrec = function (jdata) {
        alert("Fine");
        var promise = $http({
            method: 'POST',
            url: 'http://localhost:12162/api/jobs', data: jdata
        });
        return promise;
    }
    return jobrec;
});
x.factory("JService", function ($http) {
    // code here
    var jobsdata = {};
    jobsdata.getJobs = function () {
        return $http.get("http://localhost:12162/api/jobs");
    }
    return jobsdata;
});
x.filter("ReverseData", function () {
    return function (text) {
        return text.split("").reverse().join("");
    }
});
x.controller("AddJobsController", function ($scope, JobsDataService) {
    $scope.job = {};
    $scope.job.Interested = false;
    $scope.job.country = [{ value: "Ind", label: "India" },
                        { value: "USA", label: "United States" },
                        { value: "UK", label: "United Kingdom" },
                        { value: "Aus", label: "Australia" }
    ];
    $scope.job.AddJob = function () {
        console.log($scope.job);
        // use webapi call to add data
        var jrec = { job_id: $scope.job.job_id, job_desc: $scope.job.job_desc, min_lvl: $scope.job.min_lvl };
        if ($scope.frmjobs.$valid) {
            var promise = JobsDataService.AddJobrec(jrec);

            promise.success(function (data, status) {
                alert("Record Successfully added");
                $scope.showSuccessMessage = true;
            });

            promise.error(function () {
                alert("Failed to add the record");
                $scope.showSuccessMessage = true;

            });
        }
    }
})
x.controller("ShowJobsController", function ($scope, JService) {
    $scope.Message = "Show Jobs here";
    JService.getJobs().success(s1).error(e1);

    function s1(res) {
        $scope.Jobs = res;
    }
    function e1() {
        alert("Error Could not invoke the service");
    }
})



