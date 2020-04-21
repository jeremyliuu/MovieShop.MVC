namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingMovieTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Genres", newName: "Genre");
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Overview = c.String(),
                        Tagline = c.String(maxLength: 512),
                        Budget = c.Decimal(precision: 18, scale: 2),
                        Revenue = c.Decimal(precision: 18, scale: 2),
                        ImdbUrl = c.String(maxLength: 2084),
                        TmdbUrl = c.String(maxLength: 2084),
                        PosterUrl = c.String(maxLength: 2084),
                        BackdropUrl = c.String(maxLength: 2084),
                        OriginalLanguage = c.String(maxLength: 64),
                        ReleaseDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RunTime = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genre", "Name", c => c.String());
            DropTable("dbo.Movie");
            RenameTable(name: "dbo.Genre", newName: "Genres");
        }
    }
}
