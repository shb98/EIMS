(function (eims) {
    var NewUserModel = function () {

        var self = this;

        self.Email = '';
        self.FullName = '';
        self.DepartmentId = '';
        self.Title = '';
    }
    eims.NewUserModel = NewUserModel;

    var NewUserResultModel = function () {

        var self = this;

        self.Email = '';
        self.TempPassword = '';
    }
    eims.NewUserResultModel = NewUserResultModel;
}(window.EIMS));
