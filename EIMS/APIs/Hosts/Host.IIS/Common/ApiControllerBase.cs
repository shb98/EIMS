using System.Security.Principal;
using System.Web.Http;
using WebMatrix.WebData;

namespace Host.IIS.Common
{
    public class ApiControllerBase : ApiController
    {
        public int CurrentUserId
        {
            get
            {
                return WebSecurity.GetUserId(CurrentUserName);
            }
        }
        public string CurrentUserName
        {
            get
            {
                var identity = AuthenticationHelper.GetCurrentContextUserIdentity();
                if (identity == null || !identity.IsAuthenticated || string.IsNullOrEmpty(identity.Name))
                {
                    return null;
                }

                return identity.Name;
            }
        }
    }
}