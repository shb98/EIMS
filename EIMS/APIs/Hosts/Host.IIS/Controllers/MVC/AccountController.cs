using System.ComponentModel.Composition;
using System.Web.Mvc;
using Host.IIS.Common;
using Host.IIS.Models;
using WebMatrix.WebData;
using ControllerBase = Host.IIS.Common.ControllerBase;

namespace Host.IIS.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("account")]
    public class AccountController : ControllerBase
    {
        private readonly ISecurityAdapter _securityAdapter;

        [ImportingConstructor]
        public AccountController(ISecurityAdapter securityAdapter)
        {
            _securityAdapter = securityAdapter;
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login(string returnUrl)
        {
            _securityAdapter.Initialize();

            return View(new AccountLoginModel() { ReturnUrl = returnUrl });
        }

        [HttpGet]
        [Route("logout")]
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //[Route("changepassword")]
        //[Authorize]
        //public ActionResult ChangePassword()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[Route("forgotpassword")]
        //[Authorize]
        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}
    }
}