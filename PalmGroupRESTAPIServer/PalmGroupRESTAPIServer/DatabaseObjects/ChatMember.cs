using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbchatmembers")]
    public class ChatMember : IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public int IdChat { get; set; }
        public int IdUser { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("IdUser")]
        public virtual User ObjectUser { get; set; }
        [ForeignKey("IdChat")]
        public virtual ChatRoom ObjectChat { get; set; }
    }
}