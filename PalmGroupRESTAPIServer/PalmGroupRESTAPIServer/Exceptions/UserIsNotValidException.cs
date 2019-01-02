using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class UserIsNotValidException: Exception, ICustomExceptions
    {
        public UserIsNotValidException()
            : base("User is not valid")
        {

        }
    }
}