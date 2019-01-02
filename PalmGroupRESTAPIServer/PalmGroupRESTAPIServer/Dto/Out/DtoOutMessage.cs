using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutMessage : IDtoOutObjects
    {
        public int Id { get; set ; }
        public int IdUser { get; set; }
        public int IdChatRoom { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public string File { get; set; }
    }
}