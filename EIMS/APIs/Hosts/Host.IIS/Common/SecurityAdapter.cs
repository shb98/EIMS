using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

namespace Host.IIS.Common
{
    [Export(typeof (ISecurityAdapter))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SecurityAdapter : ISecurityAdapter
    {
        // TODO: Department Role Mapping
        public static void Initialize()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("EIMS", "Employees", "EmployeeId", "Email", true);

            if (!WebSecurity.UserExists("admin@eims.com"))
            {
                WebSecurity.CreateUserAndAccount("admin@eims.com", "Password01!");
            }

            var allRoles = Roles.GetAllRoles();
            if (!allRoles.Contains("admin"))
            {
                Roles.CreateRole("admin");
                Roles.AddUserToRole("admin@eims.com", "admin");
            }
            if (!allRoles.Contains("employee"))
            {
                Roles.CreateRole("employee");
                Roles.AddUserToRole("admin@eims.com", "employee");
            }
            if (!allRoles.Contains("hr"))
            {
                Roles.CreateRole("hr");
            }
            if (!allRoles.Contains("finance"))
            {
                Roles.CreateRole("finance");
            }
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