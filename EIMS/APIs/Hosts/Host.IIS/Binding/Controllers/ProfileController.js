appMainModule.controller("MyProfileController", function ($scope, $http, $filter, $timeout, viewModelHelper, validator) {

    $scope.viewMode = ''; // profile, success
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
    }

    $scope.initialize = function() {
        viewModelHelper.apiGet('api/profile/profileinfo', null,
            function(result) {
                $scope.profileModel = result.data;
                $scope.profileModel.Birthday = $filter('date')($scope.profileModel.Birthday, 'yyyy/MM/dd');
                $scope.viewMode = 'profile';
            });
    };

    $scope.save = function () {
        validator.ValidateModel($scope.profileModel, profileModelRules);
        viewModelHelper.modelIsValid = $scope.profileModel.isValid;
        viewModelHelper.modelErrors = $scope.profileModel.errors;
        if (viewModelHelper.modelIsValid) {
            viewModelHelper.apiPost('api/profile/basicprofileinfo', $scope.profileModel,
                function (result) {
                    $scope.viewMode = 'success';
                });
        }
        else
            viewModelHelper.modelErrors = $scope.profileModel.errors;
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