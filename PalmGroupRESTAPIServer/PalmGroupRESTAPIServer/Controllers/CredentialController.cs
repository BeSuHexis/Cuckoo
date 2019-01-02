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
    public class CredentialController : ApiController
    {
        private CredentialModel _credentialModel = new CredentialModel();
        [HttpPost]
        [Route("credential/changePassword")]
        public JsonResult<IDtoOutObjects> ChangePassword(DtoInChangePassword dtoInChangePassword)
        {
            if (ModelState.IsValid)
            {
                return Json(_credentialModel.ChangePassword(dtoInChangePassword));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("CredentialDto");
            error.Message = "CredentialDto is not valid";
            return Json((IDtoOutObjects)error);
        }

    }
}
