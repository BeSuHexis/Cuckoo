using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbfriends")]
    public class Friend: IDatabaseObject
    {

        [Key]
        public int Id { get; set; }
        public int IdApplicant { get; set; }
        public int IdReciever { get; set; }
        public bool Accepted { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("IdApplicant")]
        public virtual User ObjectApplicant { get; set; }
        [ForeignKey("IdReciever")]
        public virtual User ObjectReciever { get; set; }

    }
}