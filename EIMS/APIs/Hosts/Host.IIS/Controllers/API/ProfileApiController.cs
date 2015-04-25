using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EIMS.Data;
using EIMS.Data.DataRepositories;

using Host.IIS.Common;
using Host.IIS.Models;

namespace Host.IIS.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/profile")]
    [Authorize(Roles = "employee")]
    public class ProfileApiController : ApiControllerBase
    {
        private readonly IEmployeeProfileRepository _employeeProfileRepository;

        [ImportingConstructor]
        public ProfileApiController(IEmployeeProfileRepository employeeProfileRepository)
        {
            _employeeProfileRepository = employeeProfileRepository;
        }

        [HttpGet]
        [Route("profileinfo")]
        public HttpResponseMessage GetProfileInfo(HttpRequestMessage request)
        {
            var employeeId = CurrentUserId;
            var employee = _employeeProfileRepository.Get(employeeId);

            var viewModel = new EmployeeProfileViewModel
            {
                FullName = employee.FullName,
                Email = employee.Email,
                Address = employee.Address,
                Gender = employee.Gender,
                Birthday = employee.Birthday == null ? new DateTime(1900, 1, 1) : employee.Birthday.Value.Date,
                MobilePhone = employee.MobilePhone,
                Phone = employee.Phone,
                Title = employee.Title,
                Department = employee.Department == null ? string.Empty : employee.Department.Name
            };

            return request.CreateResponse(HttpStatusCode.OK, viewModel);
        }

        [HttpPost]
        [Route("profileinfo")]
        [ValidateModel]
        public HttpResponseMessage SaveProfileInfo(HttpRequestMessage request, EmployeeProfileViewModel profileModel)
        {
            var employeeId = CurrentUserId;

            // Title and department can only updated by HR or admin
            var employee = new Employee
            {
                EmployeeId = employeeId,
                FullName = profileModel.FullName,
                Email = profileModel.Email,
                Address = profileModel.Address,
                Gender = profileModel.Gender,
                Birthday = new DateTimeOffset(profileModel.Birthday),
                MobilePhone = profileModel.MobilePhone,
                Phone = profileModel.Phone
            };

            _employeeProfileRepository.Update(employee);

            var response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}