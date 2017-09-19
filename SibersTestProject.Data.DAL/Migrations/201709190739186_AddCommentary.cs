namespace SibersTestProject.Data.DAL.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        EntityId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 200),
                        UserId = c.Guid(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        EntityId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 200),
                        IsPublic = c.Boolean(nullable: false),
                        UserId = c.Guid(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        EntityId = c.Guid(nullable: false),
                        SmallImage = c.Binary(),
                        MediumImage = c.Binary(),
                        OriginalImage = c.Binary(),
                        IsArchive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId)
                .ForeignKey("dbo.Photos", t => t.EntityId)
                .Index(t => t.EntityId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GalleryPhotoes",
                c => new
                    {
                        Gallery_EntityId = c.Guid(nullable: false),
                        Photo_EntityId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gallery_EntityId, t.Photo_EntityId })
                .ForeignKey("dbo.Galleries", t => t.Gallery_EntityId)
                .ForeignKey("dbo.Photos", t => t.Photo_EntityId)
                .Index(t => t.Gallery_EntityId)
                .Index(t => t.Photo_EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Commentaries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Images", "EntityId", "dbo.Photos");
            DropForeignKey("dbo.Galleries", "UserId", "dbo.Users");
            DropForeignKey("dbo.GalleryPhotoes", "Photo_EntityId", "dbo.Photos");
            DropForeignKey("dbo.GalleryPhotoes", "Gallery_EntityId", "dbo.Galleries");
            DropForeignKey("dbo.Commentaries", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.GalleryPhotoes", new[] { "Photo_EntityId" });
            DropIndex("dbo.GalleryPhotoes", new[] { "Gallery_EntityId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.Images", new[] { "EntityId" });
            DropIndex("dbo.Galleries", new[] { "UserId" });
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropIndex("dbo.Commentaries", new[] { "UserId" });
            DropIndex("dbo.Commentaries", new[] { "PhotoId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.GalleryPhotoes");
            DropTable("dbo.UserLogins");
            DropTable("dbo.Images");
            DropTable("dbo.Galleries");
            DropTable("dbo.Photos");
            DropTable("dbo.Commentaries");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
