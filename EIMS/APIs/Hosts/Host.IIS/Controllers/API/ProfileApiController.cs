using System.ComponentModel.Composition;
using System.Linq;
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
    public class ProfileApiController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        [ImportingConstructor]
        public ProfileApiController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("profileinfo")]
        public HttpResponseMessage GetProfileInfo(HttpRequestMessage request)
        {
            //todo: get user id from authentication
            var employeeId = 1;
            var employee = _employeeRepository.Get(employeeId);

            var viewModel = new EmployeeProfileViewModel()
            {
                FullName = employee.FullName,
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
        public HttpResponseMessage SaveProfileInfo(HttpRequestMessage request, EmployeeProfileViewModel profileModel)
        {
            //todo: get user id from authentication
            var employeeId = 1;
            var employee = new Employee()
            {
                EmployeeId = employeeId,
                FullName = profileModel.FullName,
                Address = profileModel.Address,
                Gender = profileModel.Gender,
                MobilePhone = profileModel.MobilePhone,
                Phone = profileModel.Phone,
                Title = profileModel.Title
            };

            _employeeRepository.Update(employee);

            var response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}