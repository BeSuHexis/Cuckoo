using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class ObjectIsNotValidException : Exception, ICustomExceptions
    {
        public ObjectIsNotValidException(string name)
             : base(("Object:"+ name+" is not valid"))
        {
        }
    }
}