using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Host.IIS.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    [RoutePrefix("profile")]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}