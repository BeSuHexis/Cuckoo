using AutoMapper;
using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.DatabaseRepositories;
using PalmGroupRESTAPIServer.Dto.In;
using PalmGroupRESTAPIServer.Dto.Out;
using PalmGroupRESTAPIServer.Exceptions;
using PalmGroupRESTAPIServer.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Models
{
    public class LoginModel
    {
        private CredentialsRepository _credentialRepository = new CredentialsRepository();
        private TokensRepository tokensRepository = new TokensRepository();
        public IDtoOutObjects Login(string loginName, string password, string deviceName)
        {
            Credential credential = _credentialRepository.FindBy(x => x.LoginName == loginName && x.IsDeleted == false && x.ObjectUser.IsDeleted == false).FirstOrDefault();
            if (credential != null && credential.Password == password)
            {
                Token t = TokenTools.CreateToken(credential.ObjectUser, deviceName);
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Token, DtoOutToken>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutToken dtoOutToken = new DtoOutToken();
                mapper.Map(t, dtoOutToken);
                dtoOutToken.IdUser = TokenTools.getUserFromToken(dtoOutToken.TokenString).Id;
                return dtoOutToken;
            }
            else
            {
                DtoOutError error = new DtoOutError();
                error.Exception = new CredentialAreNotValidException();
                error.Message = "Credentials are not assign to account";
                return error;

            }
        }

        public IDtoOutObjects Logout(DtoInLogout dtoInLogout)
        {
            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInLogout.Token, dtoInLogout.DeviceName))
            {
                Token token = TokenTools.getTokenObjectFromString(dtoInLogout.Token);
                token.IsDeleted = true;
                tokensRepository.Edit(token);
                tokensRepository.Save();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Token, DtoOutToken>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutToken dtoOutToken = new DtoOutToken();
                mapper.Map(token, dtoOutToken);
                return dtoOutToken;
            }
            else
            {
                NotAuthenticatedException ex = new NotAuthenticatedException();
                error.Exception = ex;
                return error;
            }
        }
    }
}