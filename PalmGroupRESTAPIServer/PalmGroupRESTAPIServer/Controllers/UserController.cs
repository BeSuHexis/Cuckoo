using AutoMapper;
using Newtonsoft.Json;
using PalmGroupRESTAPIServer.DatabaseObjects;
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
    public class UserController : ApiController
    {
      private  UserModel _userModel = new UserModel();

        [HttpPost]
        [Route("user/all")]
        public JsonResult<IDtoOutObjects> All(DtoInLogout dtoInLogout)
        {

            // Jak udělat authenticate
            //Ukázkové použití validačního frameworku
            if (ModelState.IsValid)
            {
                return Json(_userModel.All(dtoInLogout));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new UserIsNotValidException();
            error.Message = "dtoInLogout is not valid";
            return Json((IDtoOutObjects)error);
        }

        [HttpPost]
        [Route("user/getbyid")]
        public JsonResult<IDtoOutObjects> GetById(DtoInGetById user)
        {

            // Jak udělat authenticate
            //Ukázkové použití validačního frameworku
            if (ModelState.IsValid)
            {
                return Json(_userModel.GetById(user));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new UserIsNotValidException();
            error.Message = "GetById is not valid";
            return Json((IDtoOutObjects)error);
        }
        [HttpPost]
        [Route("user/create")]
        public JsonResult<IDtoOutObjects> Create(DtoInUser user)
        {
            
            // Jak udělat authenticate
            //Ukázkové použití validačního frameworku
            if (ModelState.IsValid)
            {         
                return Json(_userModel.CreateUser(user));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new UserIsNotValidException();
            error.Message = "user is not valid";
            return Json((IDtoOutObjects)error);
        }
        [HttpPost]
        [Route("user/delete")]
        public JsonResult<IDtoOutObjects> Delete(DtoInLogout dtoInLogout)
        {

            // Jak udělat authenticate
            //Ukázkové použití validačního frameworku
            if (ModelState.IsValid)
            {
                return Json(_userModel.DeleteUser(dtoInLogout));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("authenticate");
            error.Message = "dtoInDeleteUser is not valid";
            return Json((IDtoOutObjects)error);
        }
        [HttpPost]
        [Route("user/edit")]
        public JsonResult<IDtoOutObjects> Edit(DtoInEditUser dtoInEditUser)
        {

            // Jak udělat authenticate
            //Ukázkové použití validačního frameworku
            if (ModelState.IsValid)
            {
                return Json(_userModel.EditUser(dtoInEditUser));
            }

            DtoOutError error = new DtoOutError();
            error.Exception = new ObjectIsNotValidException("dtoInEditUser");
            error.Message = "dtoInEditUser is not valid";
            return Json((IDtoOutObjects)error);
        }
    }
}
