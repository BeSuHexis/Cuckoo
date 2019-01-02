using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutError : IDtoOutObjects
    {
        public DtoOutError()
        {
            Random generator = new Random();
            this.Id = generator.Next(100000, 1000000);
        }

        public int Id { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }

    }
}