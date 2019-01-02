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
    public class MessageController : ApiController
    {
        private MessageModel _messageModel = new MessageModel();
        [HttpPost]
        [Route("message/send")]
        public JsonResult<IDtoOutObjects> Send(DtoInMessage dtoInMessage)
        {                      
            if (ModelState.IsValid)
            {
                return Json(_messageModel.Send(dtoInMessage));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("Message");
            error.Message = "message is not valid";
            return Json((IDtoOutObjects)error);
        }

        [HttpPost]
        [Route("message/seen")]
        public JsonResult<IDtoOutObjects> Seen(DtoInSeenMessage dtoInSeenMessage)
        {
            if (ModelState.IsValid)
            {
                return Json(_messageModel.Seen(dtoInSeenMessage));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("SeenMessage");
            error.Message = "Seenmessage is not valid";
            return Json((IDtoOutObjects)error);
        }
        [HttpPost]
        [Route("message/all")]
        public JsonResult<IDtoOutObjects> All(DtoInLogout dtoInLogout)
        {
            if (ModelState.IsValid)
            {
                return Json(_messageModel.GetAllMessages(dtoInLogout));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("SeenMessage");
            error.Message = "Seenmessage is not valid";
            return Json((IDtoOutObjects)error);
        }
        [HttpPost]
        [Route("message/new")]
        public JsonResult<IDtoOutObjects> New(DtoInGetNewMessages dtoInGetNewMessages)
        {
            if (ModelState.IsValid)
            {
                return Json(_messageModel.GetNewMessages(dtoInGetNewMessages));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("SeenMessage");
            error.Message = "Seenmessage is not valid";
            return Json((IDtoOutObjects)error);
        }
    }
}
