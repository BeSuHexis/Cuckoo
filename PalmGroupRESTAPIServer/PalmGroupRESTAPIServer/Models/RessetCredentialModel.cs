using AutoMapper;
using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.DatabaseRepositories;
using PalmGroupRESTAPIServer.Dto.Out;
using PalmGroupRESTAPIServer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Models
{

    public class RessetCredentialModel
    {
        private CredentialsRepository _credentialRepository = new CredentialsRepository();
        private RessetCredentialsRepository _ressetCredentialsRepository = new RessetCredentialsRepository();
        public IDtoOutObjects RessetPassword(string Email)
        {
            Credential credential = _credentialRepository.FindBy(x => x.IsDeleted == false && x.ObjectUser.IsDeleted == false && x.LoginName == Email).FirstOrDefault();
            if (credential != null)
            {
                RessetCredential ressetCredential = new RessetCredential();
                ressetCredential.ObjectCredential = credential;
                _ressetCredentialsRepository.Add(ressetCredential);
                _ressetCredentialsRepository.Save();
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<RessetCredential, DtoOutRessetCredential>(); });
                IMapper mapper = config.CreateMapper();
                DtoOutRessetCredential dtoOutRessetCredential = new DtoOutRessetCredential();
                mapper.Map(credential, dtoOutRessetCredential);
                return dtoOutRessetCredential;

            }
            else {
                throw new UserWithThisEmailDoesntExistException();      
            }
        }
    }
}