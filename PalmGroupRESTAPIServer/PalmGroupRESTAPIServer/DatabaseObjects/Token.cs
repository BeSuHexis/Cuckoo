using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbtokens")]
    public class Token: IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        [Column("Token")]
        public string TokenString { get; set; }
        public DateTime ValidTo { get; set; }
        public string DeviceName { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("IdUser")]
        public virtual User ObjectUser { get; set; }



    }
}