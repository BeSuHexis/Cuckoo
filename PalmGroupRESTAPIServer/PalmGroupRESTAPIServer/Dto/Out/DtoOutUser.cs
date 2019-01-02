using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.Out
{
    public class DtoOutUser : IDtoOutObjects, IDtoOutAuthenticate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime BornDate { get; set; }
        public string Country { get; set; }
        public string TokenString { get; set; }
    }
}