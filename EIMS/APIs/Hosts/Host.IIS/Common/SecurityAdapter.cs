using System.ComponentModel.Composition;
using WebMatrix.WebData;

namespace Host.IIS.Common
{
    [Export(typeof (ISecurityAdapter))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SecurityAdapter : ISecurityAdapter
    {
        public void Initialize()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("EIMS", "Employees", "EmployeeId", "Email", true);
        }

        public void Register(string loginEmail, string password)
        {
            WebSecurity.CreateAccount(loginEmail, password);
        }

        public void Register(string loginEmail, string password, object propertyValues)
        {
            WebSecurity.CreateUserAndAccount(loginEmail, password, propertyValues);
        }

        public bool Login(string loginEmail, string password, bool rememberMe)
        {
            return WebSecurity.Login(loginEmail, password, rememberMe);
        }

        public bool ChangePassword(string loginEmail, string oldPassword, string newPassword)
        {
            return WebSecurity.ChangePassword(loginEmail, oldPassword, newPassword);
        }

        public bool UserExists(string loginEmail)
        {
            return WebSecurity.UserExists(loginEmail);
        }

        public int GetUserId(string loginEmail)
        {
            return WebSecurity.GetUserId(loginEmail);
        }
    }
}