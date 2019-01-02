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
    public class CredentialModel
    {
        private CredentialsRepository _credentialsRepository = new CredentialsRepository();
        public IDtoOutObjects ChangePassword(DtoInChangePassword dtoInChangePassword)
        {

            DtoOutError error = new DtoOutError();
            if (TokenTools.Authentication(dtoInChangePassword.Token, dtoInChangePassword.DeviceName))
            {
                User user = TokenTools.getUserFromToken(dtoInChangePassword.Token);
               Credential credential = _credentialsRepository.FindBy(x => x.IdUser == user.Id && x.IsDeleted == false && x.ObjectUser.IsDeleted == false).FirstOrDefault(); // toto zanmená že každý user může mít jen jedny credentials
                credential.Password = dtoInChangePassword.Password;
                _credentialsRepository.Edit(credential);
                _credentialsRepository.Save();
                DtoOutComplete dtoOutComplete = new DtoOutComplete();
                dtoOutComplete.Completed = true;
                return dtoOutComplete;
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