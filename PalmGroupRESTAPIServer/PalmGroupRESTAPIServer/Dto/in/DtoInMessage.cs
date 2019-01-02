using System;
using System.ComponentModel.DataAnnotations;


namespace PalmGroupRESTAPIServer.Dto.In
{
    public class DtoInMessage: IAuthorization
    {
        [Required]
        public int ChatRoomId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(700)]
        public string Text { get; set; }
         
        public string File { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string DeviceName { get ; set ; }
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Token { get; set; }
    }
}