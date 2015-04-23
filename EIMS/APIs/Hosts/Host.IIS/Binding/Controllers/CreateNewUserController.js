
appMainModule.controller("CreateNewUserController", function ($scope, $http, viewModelHelper, validator) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.newUserModel = new EIMS.NewUserModel();
    $scope.newUserResultModel = new EIMS.NewUserResultModel();
    $scope.viewMode = 'newUser'; // changepw, success

    var newUserModelRules = [];

    var setupRules = function () {
        newUserModelRules.push(new validator.PropertyRule("Email", {
            required: { message: "Email is required" }
        }));
        newUserModelRules.push(new validator.PropertyRule("FullName", {
            required: { message: "Full Name is required" }
        }));
        newUserModelRules.push(new validator.PropertyRule("DepartmentId", {
            required: { message: "Department is required" }
        }));
        newUserModelRules.push(new validator.PropertyRule("Title", {
            required: { message: "Title is required" }
        }));
    }

    var initializeDepartments = function () {
        viewModelHelper.apiGet('api/department/alldepartments', null,
                function (result) {
                    $scope.departments = result.data;
                });
    }

    $scope.createNewUser = function () {
        validator.ValidateModel($scope.newUserModel, newUserModelRules);
        viewModelHelper.modelIsValid = $scope.newUserModel.isValid;
        viewModelHelper.modelErrors = $scope.newUserModel.errors;
        if (viewModelHelper.modelIsValid) {
            viewModelHelper.apiPost('api/account/createuser', $scope.newUserModel,
                function (result) {
                    $scope.newUserResultModel.Email = $scope.newUserModel.Email;
                    $scope.newUserResultModel.TempPassword = result.data;
                    $scope.viewMode = 'success';
                });
        }
        else
            viewModelHelper.modelErrors = $scope.newUserModel.errors;
    }

    setupRules();
    initializeDepartments();
});
