using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ControllerBase = Host.IIS.Common.ControllerBase;

namespace Host.IIS.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize(Roles = "hr,admin")]
    [RoutePrefix("eployee")]
    public class EmployeeManagementController : ControllerBase
    {
        [Route("manage")]
        public ViewResult ManageEmployee()
        {
            return View();
        }
    }
}