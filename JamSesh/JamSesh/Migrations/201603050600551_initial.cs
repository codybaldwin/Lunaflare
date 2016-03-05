namespace JamSesh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                        StreamUrl = c.String(),
                        Playlist_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_Id)
                .Index(t => t.Playlist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Playlist_Id", "dbo.Playlists");
            DropIndex("dbo.Songs", new[] { "Playlist_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Playlists");
        }
    }
}
