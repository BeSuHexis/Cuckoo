using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class UserDoesNotAskedForFriendshipException : Exception, ICustomExceptions
    {
        public UserDoesNotAskedForFriendshipException()
            :base("this user does not asked for friendship with you")
        {
        }
    }
}