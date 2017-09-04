namespace SibersTestProject.Data.DAL.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commentaries",
                c => new
                    {
                        EntityId = c.Guid(nullable: false),
                        Comment = c.String(nullable: false),
                        PhotoId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.PhotoId)
                .Index(t => t.UserId);
            
            
        }
        
        public override void Down()
        {
           
            DropForeignKey("dbo.Commentaries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Commentaries", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Commentaries", new[] { "UserId" });
            DropIndex("dbo.Commentaries", new[] { "PhotoId" });         
            DropTable("dbo.Commentaries");
        
        }
    }
}
