using System.Net;
using System.Net.Http;
using System.Web.Http;
using Host.IIS.Common;
using Host.IIS.Models;

namespace Host.IIS.Controllers.API
{
    [RoutePrefix("api/profile")]
    public class ProfileApiController : ApiController
    {
        [HttpGet]
        [Route("profileinfo")]
        public HttpResponseMessage GetProfileInfo(HttpRequestMessage request)
        {
            var viewModel = new EmployeeProfileViewModel()
            {
                FullName = "Test Full Name",
                Address = "Test address",
                Gender = "Test Gender",
                MobilePhone = "11111111111",
                Phone = "22222222",
                Title = "Test title"
            };

            return request.CreateResponse(HttpStatusCode.OK, viewModel);
        }

        [HttpPost]
        [Route("profileinfo")]
        [ValidateModel]
        public HttpResponseMessage SaveProfileInfo(HttpRequestMessage request, EmployeeProfileViewModel profileModel)
        {
            // TODO: Save
            var response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}