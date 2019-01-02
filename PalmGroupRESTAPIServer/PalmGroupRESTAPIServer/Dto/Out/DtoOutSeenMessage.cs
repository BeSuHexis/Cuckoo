using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutSeenMessage : IDtoOutObjects
    {
        public int Id { get; set ; }
        public int IdUser { get; set; }
        public int IdMessage { get; set; }
        public DateTime SeenTime { get; set; }
    }
}