using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Exceptions
{
    public class DatabaseConnectionFailedException:Exception, ICustomExceptions
    {
        public DatabaseConnectionFailedException()
            : base("Database connection failed")
        {

        }
    }
}