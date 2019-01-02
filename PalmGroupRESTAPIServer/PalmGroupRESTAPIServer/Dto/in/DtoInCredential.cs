using System;
using System.ComponentModel.DataAnnotations;


namespace PalmGroupRESTAPIServer.Dto.In
{
    public class DtoInCredential: IDtoInObjects
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string LoginName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string DeviceName { get ; set ; }
      
    }
}