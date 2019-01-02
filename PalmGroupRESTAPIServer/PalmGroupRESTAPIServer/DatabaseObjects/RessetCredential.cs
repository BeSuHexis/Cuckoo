using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbressetcredentials")]
    public class RessetCredential : IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public int IdCredential { get; set; }
        public string Code { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("IdCredential")]
        public virtual Credential ObjectCredential { get; set; }

        public RessetCredential()
        {
            this.Code = Guid.NewGuid().ToString();
            this.ExpireDate = System.DateTime.Now.AddHours(1);
        }
    }
}