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
    public class FriendController : ApiController
    {
         private FriendModel friendModel = new FriendModel();
        [HttpPost]
        [Route("friend/add")]
        public JsonResult<IDtoOutObjects> Add(DtoInAddFriend dtoInFriend)
        {
           if (ModelState.IsValid)
            {             
              return Json(friendModel.AddFriend(dtoInFriend));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("AddFriend");
            error.Message = "Object addFriend is not valid";
            return Json((IDtoOutObjects)error);
        }
        [HttpPost]
        [Route("friend/accept")]
        public JsonResult<IDtoOutObjects> Accept(DtoInAddFriend dtoInFriend)
        {
            if (ModelState.IsValid)
            {
                return Json(friendModel.Accept(dtoInFriend));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("AddFriend");
            error.Message = "Object accept friend is not valid";
            return Json((IDtoOutObjects)error);
        }

        [HttpPost]
        [Route("friend/delete")]
        public JsonResult<IDtoOutObjects> Delete(DtoInAddFriend dtoInFriend)
        {
            if (ModelState.IsValid)
            {
                return Json(friendModel.Delete(dtoInFriend));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("AddFriend");
            error.Message = "Object accept friend is not valid";
            return Json((IDtoOutObjects)error);
        }

    }
}
