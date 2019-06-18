using Server2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Server2.DAL
{
    public class ChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

            public ChatDbContext() : base("ChatDb")
            {
            }

            public static ChatDbContext Create()
            {
                return new ChatDbContext();
            }



    }
}