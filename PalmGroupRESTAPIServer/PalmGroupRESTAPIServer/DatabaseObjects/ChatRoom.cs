using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbchatrooms")]
    public class ChatRoom : IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ChatRoomPhoto { get; set; }
        public bool IsDeleted { get; set; }
   

    }
}