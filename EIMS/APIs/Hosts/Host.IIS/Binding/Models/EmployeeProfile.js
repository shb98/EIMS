(function (eims) {
    var EmployeeProfileModel = function () {

        var self = this;

        self.EmployeeId = '';
        self.Email = '';
        self.FullName = '';
        self.Gender = '';
        self.Birthday = '';
        self.Address = '';
        self.Phone = '';
        self.MobilePhone = '';
        self.DepartmentId = '';
        self.Title = '';
    }
    eims.EmployeeProfileModel = EmployeeProfileModel;
}(window.EIMS));
