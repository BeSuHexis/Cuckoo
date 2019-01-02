using AutoMapper;
using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.DatabaseRepositories;
using PalmGroupRESTAPIServer.Dto.In;
using PalmGroupRESTAPIServer.Dto.Out;
using PalmGroupRESTAPIServer.Exceptions;
using PalmGroupRESTAPIServer.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Models
{
    public class UserModel
    {
        private UsersRepository _usersRepostiory = new UsersRepository();
        private CredentialsRepository credentialsRepository = new CredentialsRepository();

        public IDtoOutObjects All(DtoInLogout dtoInLogout)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInLogout.Token, dtoInLogout.DeviceName))
            {
                List<User> users = _usersRepostiory.FindBy(x =>x.IsDeleted == false).ToList();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, DtoOutUser>(); });
                IMapper mapper = config.CreateMapper();
                List<DtoOutUser> list = new List<DtoOutUser>();
                foreach (User item in users)
                {
                    DtoOutUser dtoOutUser = new DtoOutUser();
                    mapper.Map(item, dtoOutUser);
                    list.Add(dtoOutUser);
                }
              
                DtoOutAllUsers dtoOutAllUsers = new DtoOutAllUsers();
                dtoOutAllUsers.dtoOutUsers = list;
                return dtoOutAllUsers;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
        }

        public IDtoOutObjects GetById(DtoInGetById dtoInGetById)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInGetById.Token, dtoInGetById.DeviceName))
            {
               User user = _usersRepostiory.FindBy(x => x.Id == dtoInGetById.Id && x.IsDeleted == false).FirstOrDefault();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, DtoOutUser>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutUser dtoOutUser = new DtoOutUser();
                mapper.Map(user, dtoOutUser);
                return dtoOutUser;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
        }

        public IDtoOutObjects CreateUser(DtoInUser dtoInUser)
        {
            string deviceName = dtoInUser.DeviceName;
            User user = new User();
            var configIn = new MapperConfiguration(cfg => { cfg.CreateMap<DtoInUser, User>(); });
            IMapper mapperIn = configIn.CreateMapper();
            mapperIn.Map(dtoInUser, user);
            user.BornDate = new DateTime(dtoInUser.Year, dtoInUser.Month, dtoInUser.Day);
            try
            {

                if (!UserExists(user))
                {
                    Credential c = new Credential(user.Email, Guid.NewGuid().ToString(),user);
                                      
                    Credential credential = credentialsRepository.Add(c);
                    credentialsRepository.Save();
                   User u = _usersRepostiory.FindBy(x=>x.Id==user.Id&& x.IsDeleted==false).FirstOrDefault();
#region createMapperUser
                    var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, DtoOutUser>(); });
                      IMapper mapper = config.CreateMapper();
#endregion
                    DtoOutUser dtoOutUser = new DtoOutUser();
                   mapper.Map(u, dtoOutUser);                   
        
                    dtoOutUser.TokenString = TokenTools.CreateToken(u, deviceName).TokenString; 
                    return dtoOutUser;
                }
                else
                {
                    DtoOutError error = new DtoOutError();
                    error.Exception = new DuplicateObjectInDatabaseException("User");
                    error.Message = "This user is already created";
                    return error;             
                }
            }
            catch (Exception ex)
            {
                DtoOutError error = new DtoOutError();             
                error.Exception = ex;
                error.Message = ex.Message;
                return error;

            }

        }
        public IDtoOutObjects DeleteUser(DtoInLogout dtoInLogout)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInLogout.Token, dtoInLogout.DeviceName))
            {
                User user = TokenTools.getUserFromToken(dtoInLogout.Token);
                user.IsDeleted = true;
                _usersRepostiory.Edit(user);
                _usersRepostiory.Save();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, DtoOutUser>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutUser dtoOutUser = new DtoOutUser();
                mapper.Map(user, dtoOutUser);
                return dtoOutUser;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
        }
        public IDtoOutObjects EditUser(DtoInEditUser dtoInEditUser)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInEditUser.Token, dtoInEditUser.DeviceName))
            {
                User user = TokenTools.getUserFromToken(dtoInEditUser.Token);
                user.BornDate = new DateTime(dtoInEditUser.Year, dtoInEditUser.Month, dtoInEditUser.Day);
                var configIn = new MapperConfiguration(cfg => { cfg.CreateMap<DtoInEditUser, User>(); });
                IMapper mapperIn = configIn.CreateMapper();
                mapperIn.Map(dtoInEditUser, user);
                _usersRepostiory.Edit(user);
                _usersRepostiory.Save();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, DtoOutUser>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutUser dtoOutUser = new DtoOutUser();
                mapper.Map(user, dtoOutUser);
                return dtoOutUser;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
        }
        private bool UserExists(User u)
        {
            if (_usersRepostiory.FindBy(x => x.Email == u.Email && x.IsDeleted==false).FirstOrDefault() == null)
                return false;

            return true;

        }
    }
}