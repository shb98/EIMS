using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Host.IIS.Common;
using Host.IIS.Models;
using EIMS.Data.DataRepositories;

namespace Host.IIS.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/department")]
    [Authorize]
    public class DepartmentController : ApiControllerBase
    {
        private IDepartmentRepository _departmentRepository;

        [ImportingConstructor]
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        [Route("alldepartments")]
        public HttpResponseMessage GetAllDepartments(HttpRequestMessage request)
        {
            var departments = _departmentRepository.Get().Select(d => new DepartmentModel()
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name
            }).ToArray();

            return request.CreateResponse(HttpStatusCode.OK, departments);
        }
    }
}