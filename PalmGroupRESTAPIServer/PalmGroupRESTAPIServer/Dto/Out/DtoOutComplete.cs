using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutComplete : IDtoOutObjects
    {
        public bool Completed { get; set; }
        public int Id { get; set; }
        public DtoOutComplete()
        {
            Random generator = new Random();
            this.Id = generator.Next(100000, 1000000);
        }
    }
}