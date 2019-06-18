using Server2.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<ChatDbContext>
    {
        protected override void Seed(ChatDbContext db)
        {
            db.Users.Add(new User { Name = "Первый чаттер" });
            db.Users.Add(new User { Name = "Второй чаттер" });
            db.Users.Add(new User { Name = "Третий чаттер" });

            base.Seed(db);
        }
    }
}