namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToMoviesForGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            Sql("UPDATE Movies SET GenreId=1 WHERE Id=1");
            Sql("UPDATE Movies SET GenreId=2 WHERE Id=2");
            Sql("UPDATE Movies SET GenreId=2 WHERE Id=3");
            Sql("UPDATE Movies SET GenreId=2 WHERE Id=4");
            Sql("UPDATE Movies SET GenreId=2 WHERE Id=5");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
        }
    }
}
