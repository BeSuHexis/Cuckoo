using PalmGroupRESTAPIServer.Dto.In;
using PalmGroupRESTAPIServer.Dto.Out;
using PalmGroupRESTAPIServer.Exceptions;
using PalmGroupRESTAPIServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace PalmGroupRESTAPIServer.Controllers
{
    public class LoginController : ApiController
    {
        private LoginModel loginModel = new LoginModel();
        [HttpPost]
        [Route("login/login")]
        public JsonResult<IDtoOutObjects> Login(DtoInCredential dtoInCredential)
        {
            if (ModelState.IsValid)
            {

                return Json((IDtoOutObjects)loginModel.Login(dtoInCredential.LoginName, dtoInCredential.Password, dtoInCredential.DeviceName));
            }
            else 
            {
                DtoOutError error = new DtoOutError();
                CredentialAreNotValidException ex = new CredentialAreNotValidException();
                error.Exception = ex;
                error.Message = "Credentials are not valid";
                return Json((IDtoOutObjects)error);

            }
        }
        [HttpPost]
        [Route("login/logout")]
        public JsonResult<IDtoOutObjects> Logout(DtoInLogout dtoInLogout)
        {
            if (ModelState.IsValid)
            {

                return Json(loginModel.Logout(dtoInLogout));
            }
            else
            {
                DtoOutError error = new DtoOutError();
                CredentialAreNotValidException ex = new CredentialAreNotValidException();
                error.Exception = ex;
                error.Message = "Credentials are not valid";
                return Json((IDtoOutObjects)error);

            }
        }
    }
}
