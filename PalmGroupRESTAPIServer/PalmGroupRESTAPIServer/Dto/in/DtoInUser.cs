using System;
using System.ComponentModel.DataAnnotations;

namespace PalmGroupRESTAPIServer.Dto.In
{
    public class DtoInUser : IDtoInObjects
    { 
    
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(300)]
        public string ProfilePhoto { get; set; }

        [Required]
    
        public int Day { get; set; }
        [Required]
  
        public int Month { get; set; }
        [Required]
    
        public int Year { get; set; }
   
        [Required]
        [MinLength(1)]
        [MaxLength(300)]
        public string Country { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string DeviceName { get; set ; }
    }
}