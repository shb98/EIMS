using System.Security.Principal;
using System.Web;

namespace Host.IIS.Common
{
    public class AuthenticationHelper
    {
        public static IIdentity GetCurrentContextUserIdentity()
        {
            if (HttpContext.Current == null)
            {
                return null;
            }

            IPrincipal principal = HttpContext.Current.User;
            if (principal == null)
            {
                return null;
            }

            IIdentity identity = principal.Identity;
            return identity;
        }
    }
}