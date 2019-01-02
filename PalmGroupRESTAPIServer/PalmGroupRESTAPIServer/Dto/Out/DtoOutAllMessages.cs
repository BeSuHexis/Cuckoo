using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutAllMessages : IDtoOutObjects
    {
        public List<DtoOutMessageDetails> dtoOutMessageDetails { get; set; }
        public int Id { get; set; }

        public DtoOutAllMessages()
        {
            Random generator = new Random();
            this.Id = generator.Next(100000, 1000000);
        }
    }
}