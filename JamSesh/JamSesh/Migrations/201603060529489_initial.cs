namespace JamSesh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jammers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(),
                        Jammer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jammers", t => t.Jammer_Id)
                .Index(t => t.Jammer_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                        StreamUrl = c.String(),
                        playlist_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.playlist_Id)
                .Index(t => t.playlist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "playlist_Id", "dbo.Playlists");
            DropForeignKey("dbo.Playlists", "Jammer_Id", "dbo.Jammers");
            DropIndex("dbo.Songs", new[] { "playlist_Id" });
            DropIndex("dbo.Playlists", new[] { "Jammer_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Playlists");
            DropTable("dbo.Jammers");
        }
    }
}
