using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class YouAreAlreadyFriendsExceptions : Exception, ICustomExceptions
    {
        public YouAreAlreadyFriendsExceptions()
            : base("you are already friends")
        {
        }
    }
}