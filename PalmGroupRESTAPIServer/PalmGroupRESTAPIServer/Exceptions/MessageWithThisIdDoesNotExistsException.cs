using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class MessageWithThisIdDoesNotExistsException : Exception
    {
        public MessageWithThisIdDoesNotExistsException()           
        {

        }
    }
}