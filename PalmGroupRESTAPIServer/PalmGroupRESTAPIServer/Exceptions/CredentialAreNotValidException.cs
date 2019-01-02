using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class CredentialAreNotValidException: Exception,ICustomExceptions
    {
        public CredentialAreNotValidException()
            : base("Credential is not valid")
        {

        }
    }
}