using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.Dto.In
{
    public class DtoInSeenMessage : IAuthorization
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string DeviceName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Token { get; set; }
        [Required]
        public int IdMessage { get; set; }
    }
}