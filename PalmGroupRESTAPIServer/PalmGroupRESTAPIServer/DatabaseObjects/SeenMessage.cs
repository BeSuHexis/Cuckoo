using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbseenmessages")]
    public class SeenMessage: IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdMessage { get; set; }
        public DateTime SeenTime { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("IdUser")]
        public virtual User ObjectUser { get; set; }
        [ForeignKey("IdMessage")]
        public virtual Message ObjectMessage { get; set; }

    }
}