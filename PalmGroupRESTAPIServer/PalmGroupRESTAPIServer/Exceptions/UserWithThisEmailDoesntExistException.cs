using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class UserWithThisEmailDoesntExistException : Exception, ICustomExceptions
    {
        public UserWithThisEmailDoesntExistException()
           : base("User with this email doesnt exist")
        { 
           
        }
    }
}