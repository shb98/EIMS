(function (eims) {
    var AccountChangePasswordModel = function () {

        var self = this;

        self.LoginEmail = '';
        self.OldPassword = '';
        self.NewPassword = '';
    }
    eims.AccountChangePasswordModel = AccountChangePasswordModel;
}(window.EIMS));
