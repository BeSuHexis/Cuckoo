using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class UserIsNotYourFriendException : Exception, ICustomExceptions
    {
        public UserIsNotYourFriendException()
            :base("user is not your friend so you cant delete friendship")
        {
        }
    }
}