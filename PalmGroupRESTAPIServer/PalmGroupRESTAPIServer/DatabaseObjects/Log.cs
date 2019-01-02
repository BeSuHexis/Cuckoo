using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tblogs")]
    public class Log : IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string ActionType { get; set; }
        public string ActionMessage { get; set; }
        public string DeviceName { get; set; }
        public DateTime LogDate { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("IdUser")]
        public virtual User ObjectUser { get; set; }
    }
}