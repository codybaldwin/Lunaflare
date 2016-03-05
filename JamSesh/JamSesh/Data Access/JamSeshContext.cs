using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JamSesh69.Models;

namespace JamSesh69.Data_Access
{
    public class JamSeshContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MyDbContextInitializer());

            base.OnModelCreating(modelBuilder);
        }

    }

    public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<JamSeshContext>
    {
        protected override void Seed(JamSeshContext dbContext)
        {
            // seed data

            base.Seed(dbContext);
        }
    }
}