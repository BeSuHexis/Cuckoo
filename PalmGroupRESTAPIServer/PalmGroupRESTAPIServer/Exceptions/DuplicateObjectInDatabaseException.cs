using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class DuplicateObjectInDatabaseException:Exception, ICustomExceptions
    {
        public DuplicateObjectInDatabaseException(string name)
        : base(("There are duplicate objects in database "+ name))
        {

        }
    }
}