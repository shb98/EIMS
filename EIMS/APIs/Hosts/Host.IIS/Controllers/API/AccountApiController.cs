using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;
using System.Web.Security;

using Host.IIS.Common;
using Host.IIS.Models;

namespace Host.IIS.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/account")]
    public class AccountApiController : ApiController
    {
        private readonly ISecurityAdapter _securityAdapter;

        [ImportingConstructor]
        public AccountApiController(ISecurityAdapter securityAdapter)
        {
            _securityAdapter = securityAdapter;
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(HttpRequestMessage request, [FromBody] AccountLoginModel accountModel)
        {
            HttpResponseMessage response = null;

            var success = _securityAdapter.Login(accountModel.LoginEmail, accountModel.Password,
                accountModel.RememberMe);
            if (success)
                response = request.CreateResponse(HttpStatusCode.OK);
            else
                response = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized login.");

            return response;
        }

        [HttpPost]
        [Route("changepw")]
        [Authorize]
        public HttpResponseMessage ChangePassword(HttpRequestMessage request,
            [FromBody] AccountChangePasswordModel passwordModel)
        {
            HttpResponseMessage response = null;

            ValidateAuthorizedUser(passwordModel.LoginEmail);

            var success = _securityAdapter.ChangePassword(passwordModel.LoginEmail, passwordModel.OldPassword,
                passwordModel.NewPassword);
            if (success)
            {
                response = request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to change password.");
            }

            return response;
        }



        [HttpPost]
        [Route("createuser")]
        [Authorize(Roles = "admin,hr")]
        public HttpResponseMessage CreateUser(HttpRequestMessage request,
            [FromBody] CreateNewUserModel passwordModel)
        {
            HttpResponseMessage response = null;

            var tempPassword = Membership.GeneratePassword(8, 1);
            _securityAdapter.Register(passwordModel.Email, tempPassword, new
            {
                FullName = passwordModel.FullName,
                Department_DepartmentId = passwordModel.DepartmentId,
                Title = passwordModel.Title
            });

            Roles.AddUserToRole(passwordModel.Email, "employee");
            response = request.CreateResponse(HttpStatusCode.OK, tempPassword);

            return response;
        }

        private void ValidateAuthorizedUser(string userRequested)
        {
            var userLoggedIn = User.Identity.Name;
            if (userLoggedIn != userRequested)
                throw new SecurityException("Attempting to access data for another user.");
        }
    }
}