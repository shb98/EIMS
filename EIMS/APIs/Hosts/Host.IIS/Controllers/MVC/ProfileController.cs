using System.Web.Mvc;

namespace Host.IIS.Controllers.MVC
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}