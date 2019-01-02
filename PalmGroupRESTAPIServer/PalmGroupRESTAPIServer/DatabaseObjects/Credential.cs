using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer.DatabaseObjects
{
    [Table("tbcredentials")]
    public class Credential: IDatabaseObject
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool IsTerminated { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("IdUser")]
        public virtual User ObjectUser { get; set; }

        public Credential(string loginName, string password, User objectUser)
        {
            LoginName = loginName;
            Password = password;
            ObjectUser = objectUser;
        }

        public Credential()
        {
        }
    }
}