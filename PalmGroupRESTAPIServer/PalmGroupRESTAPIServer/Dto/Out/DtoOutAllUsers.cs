using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutAllUsers : IDtoOutObjects
    {
        public List<DtoOutUser> dtoOutUsers { get; set; }
        public int Id { get; set; }

        public DtoOutAllUsers()
        {
            Random generator = new Random();
            this.Id = generator.Next(100000, 1000000);
        }
    }
}