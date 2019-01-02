using PalmGroupRESTAPIServer.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PalmGroupRESTAPIServer
{
    public class TestContext : DbContext
    {
        private static TestContext tc = null;

        private TestContext() { }
        public static TestContext GetInstance()
        {

           if (tc == null)
                tc = new TestContext();

            return tc;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();     
            modelBuilder.Entity<ChatRoom>().ToTable("tbchatrooms");
            modelBuilder.Entity<Credential>().ToTable("tbcredentials");
            modelBuilder.Entity<Log>().ToTable("tblogs");
            modelBuilder.Entity<Message>().ToTable("tbmessages");
            modelBuilder.Entity<RessetCredential>().ToTable("tbressetcredentials");
            modelBuilder.Entity<SeenMessage>().ToTable("tbseenmessages");
            modelBuilder.Entity<Token>().ToTable("tbtokens");
            modelBuilder.Entity<User>().ToTable("tbusers");
            modelBuilder.Entity<Friend>().ToTable("tbfriends");
            modelBuilder.Entity<ChatMember>().ToTable("tbchatmembers");

        }
    }
}