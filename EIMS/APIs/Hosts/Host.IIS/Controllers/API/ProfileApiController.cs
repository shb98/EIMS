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
    [Authorize]
    public class ProfileApiController : ApiControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISecurityAdapter _securityAdapter;

        [ImportingConstructor]
        public ProfileApiController(IEmployeeRepository employeeRepository, ISecurityAdapter securityAdapter)
        {
            _employeeRepository = employeeRepository;
            _securityAdapter = securityAdapter;

            _securityAdapter.Initialize();
        }

        [HttpGet]
        [Route("profileinfo")]
        public HttpResponseMessage GetProfileInfo(HttpRequestMessage request)
        {
            var employeeId = CurrentUserId;
            var employee = _employeeRepository.Get(employeeId);

            var viewModel = new EmployeeProfileViewModel
            {
                FullName = employee.FullName,
                Email = employee.Email,
                Address = employee.Address,
                Gender = employee.Gender,
                MobilePhone = employee.MobilePhone,
                Phone = employee.Phone,
                Title = employee.Title
            };

            return request.CreateResponse(HttpStatusCode.OK, viewModel);
        }

        [HttpPost]
        [Route("profileinfo")]
        [ValidateModel]
        [Authorize]
        public HttpResponseMessage SaveProfileInfo(HttpRequestMessage request, EmployeeProfileViewModel profileModel)
        {
            var employeeId = CurrentUserId;

            var employee = new Employee
            {
                EmployeeId = employeeId,
                FullName = profileModel.FullName,
                Email = profileModel.Email,
                Address = profileModel.Address,
                Gender = profileModel.Gender,
                MobilePhone = profileModel.MobilePhone,
                Phone = profileModel.Phone,
                Title = profileModel.Title
            };

            _employeeRepository.Update(employee);

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}