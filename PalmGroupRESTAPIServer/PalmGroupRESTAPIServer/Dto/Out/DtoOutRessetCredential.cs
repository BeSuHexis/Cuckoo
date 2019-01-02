using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutRessetCredential : IDtoOutObjects
    {
        public int Id { get; set; }

        public string Code { get; set; }

    }
}