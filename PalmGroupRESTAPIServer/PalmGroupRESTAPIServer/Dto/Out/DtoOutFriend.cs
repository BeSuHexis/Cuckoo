using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutFriend : IDtoOutObjects
    {
        public int Id { get; set; }
        public int IdApplicant { get; set; }
        public int IdReciever { get; set; }
        public bool Accepted { get; set; }
   
    }
}