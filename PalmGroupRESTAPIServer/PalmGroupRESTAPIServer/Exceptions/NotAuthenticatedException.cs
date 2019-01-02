using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class NotAuthenticatedException : Exception, ICustomExceptions

    {
        public NotAuthenticatedException()
         :base("authentication failed login again")
        {
        }
    }
}