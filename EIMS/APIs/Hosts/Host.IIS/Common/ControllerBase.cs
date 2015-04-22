using System.Security.Principal;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Host.IIS.Common
{
    public class ControllerBase : Controller
    {
        public int? CurrentUserId
        {
            get
            {
                string userName = CurrentUserName;
                if (string.IsNullOrEmpty(userName))
                {
                    return null;
                }

                return WebSecurity.GetUserId(CurrentUserName);
            }
        }

        public string CurrentUserName
        {
            get
            {
                IIdentity identity = AuthenticationHelper.GetCurrentContextUserIdentity();
                if (identity == null || !identity.IsAuthenticated || string.IsNullOrEmpty(identity.Name))
                {
                    return null;
                }

                return identity.Name;
            }
        }
    }
}