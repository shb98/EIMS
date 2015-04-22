(function (eims) {
    var AccountLoginModel = function () {

        var self = this;

        self.LoginEmail = '';
        self.Password = '';
        self.RememberMe = false;
    }
    eims.AccountLoginModel = AccountLoginModel;
}(window.EIMS));
