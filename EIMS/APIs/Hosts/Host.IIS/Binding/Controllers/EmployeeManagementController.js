﻿appMainModule.controller("EmployeeManagementController", function ($scope, $http, $filter, $timeout, viewModelHelper, validator) {

    $scope.viewMode = ''; // employeelist, updateemployee
    $scope.profileModel = null;
    $scope.viewModelHelper = viewModelHelper;


    var profileModelRules = [];

    var setupRules = function () {
        profileModelRules.push(new validator.PropertyRule("FullName", {
            required: { message: "Full name is required" }
        }));
        profileModelRules.push(new validator.PropertyRule("Email", {
            required: { message: "Email is required" }
        }));
        profileModelRules.push(new validator.PropertyRule("Address", {
            required: { message: "Address is required" }
        }));
        profileModelRules.push(new validator.PropertyRule("MobilePhone", {
            required: { message: "MobilePhone is required" }
        }));
        profileModelRules.push(new validator.PropertyRule("DepartmentId", {
            required: { message: "Department is required" }
        }));
        profileModelRules.push(new validator.PropertyRule("Title", {
            required: { message: "Title is required" }
        }));
    }

    $scope.initialize = function () {
        viewModelHelper.apiGet('api/profile/allprofileinfo', null,
            function (result) {
                $scope.allEmployees = result.data;
                $scope.viewMode = 'employeelist';
            });
    };

    $scope.update = function () {
        $scope.viewMode = 'updateemployee';
    }

    $scope.save = function () {
        validator.ValidateModel($scope.currentEmployee, profileModelRules);
        viewModelHelper.modelIsValid = $scope.currentEmployee.isValid;
        viewModelHelper.modelErrors = $scope.currentEmployee.errors;
        if (viewModelHelper.modelIsValid) {
            viewModelHelper.apiPost('api/profile/profileinfo', $scope.currentEmployee,
                function (result) {
                    $scope.viewMode = 'updateemployee';
                });
        }
        else
            viewModelHelper.modelErrors = $scope.currentEmployee.errors;
    }

    $scope.validate = function (field, invalid) {
        for (var i = 0; i < propertyBag.length; i++) {
            if (propertyBag[i].PropertyName == field) {
                propertyBag[i].Invalid = invalid;
                break;
            }
        }
    }

    $scope.openBirthday = function ($event) {
        $timeout(function () {
            $scope.openedBirthday = true;
        });
    }

    setupRules();
    $scope.initialize();
});