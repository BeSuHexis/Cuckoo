using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class MessageIsNotValidException:Exception, ICustomExceptions
    {
        public MessageIsNotValidException()
            : base("Message is not valid")
        {

        }
    }
}