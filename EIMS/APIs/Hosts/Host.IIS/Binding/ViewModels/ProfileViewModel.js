appMainModule.controller("MyProfileViewModel", function($scope, $http, viewModelHelper, validator) {

    $scope.viewMode = ''; // profile, success
    $scope.profileModel = null;
    $scope.viewModelHelper = viewModelHelper;


    var accountModelRules = [];

    var setupRules = function () {
        accountModelRules.push(new validator.PropertyRule("FullName", {
            required: { message: "Full name is required" }
        }));
        accountModelRules.push(new validator.PropertyRule("Address", {
            required: { message: "Address is required" }
        }));
        accountModelRules.push(new validator.PropertyRule("MobilePhone", {
            required: { message: "MobilePhone is required" }
        }));
    }

    $scope.initialize = function() {
        viewModelHelper.apiGet('api/profile/profileinfo', null,
            function(result) {
                $scope.profileModel = result.data;
                $scope.viewMode = 'profile';
            });
    };

    $scope.save = function () {
        validator.ValidateModel($scope.profileModel, accountModelRules);
        viewModelHelper.modelIsValid = $scope.profileModel.isValid;
        viewModelHelper.modelErrors = $scope.profileModel.errors;
        if (viewModelHelper.modelIsValid) {
            viewModelHelper.apiPost('api/profile/profileinfo', $scope.profileModel,
                function (result) {
                    $scope.viewMode = 'success';
                });
        }
        else
            viewModelHelper.modelErrors = profileModel.errors;
    }

    $scope.validate = function (field, invalid) {
        for (var i = 0; i < propertyBag.length; i++) {
            if (propertyBag[i].PropertyName == field) {
                propertyBag[i].Invalid = invalid;
                break;
            }
        }
    }

    setupRules();
    $scope.initialize();
});