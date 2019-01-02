using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutToken : IDtoOutObjects, IDtoOutAuthenticate
    {
        public int Id { get; set; }     
        public string TokenString { get; set; }
        public int IdUser { get; set; }

        public DtoOutToken()
        {
            Random generator = new Random();
            this.Id = generator.Next(100000, 1000000);
        }
    }
}