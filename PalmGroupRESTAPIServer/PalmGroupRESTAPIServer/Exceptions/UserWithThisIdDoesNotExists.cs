using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class UserWithThisIdDoesNotExists : Exception
    {
        public UserWithThisIdDoesNotExists()
              : base("User with this Id doesnt exist")
        {
        }
    }
}