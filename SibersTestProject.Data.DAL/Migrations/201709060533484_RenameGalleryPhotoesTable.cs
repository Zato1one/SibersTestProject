namespace SibersTestProject.Data.DAL.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGalleryPhotoesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GalleryPhotoes", newName: "GalleryPhotos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GalleryPhotos", newName: "GalleryPhotoes");
        }
    }
}
