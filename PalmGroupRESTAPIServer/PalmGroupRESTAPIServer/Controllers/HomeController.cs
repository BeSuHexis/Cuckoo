using AutoMapper;
using Newtonsoft.Json;
using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.Dto.In;
using PalmGroupRESTAPIServer.Dto.Out;
using PalmGroupRESTAPIServer.Exceptions;
using PalmGroupRESTAPIServer.Models;
using PalmGroupRESTAPIServer.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace PalmGroupRESTAPIServer.Controllers
{
    public class HomeController : ApiController
    {


        [HttpPost]
        [Route("home/save")]
        public JsonResult<IDtoOutObjects> Save(DtoInCredential dtoInCredential)
        {

            LoginModel loginModel = new LoginModel();
            try
            {

                return Json((IDtoOutObjects)loginModel.Login(dtoInCredential.LoginName, dtoInCredential.Password, dtoInCredential.DeviceName));
            }
            catch (Exception ex)
            {
                DtoOutError error = new DtoOutError();
                error.Exception = ex;
                error.Message = "user is not valid";
                return Json((IDtoOutObjects)error);

            }



        }
        [HttpPost]
        [Route("home/Authenticate")]
        public bool Authenticate(DtoInMessage Token)
        {
          return TokenTools.Authentication(Token.Token, Token.DeviceName);

        }
    }
}
