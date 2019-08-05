namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Customers OFF");
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies(Id, Name, Genre, NumberInStock, ReleaseDate, DateAdded) VALUES (1, 'Shrek', 'Comedy', 1, '1-14-1991', '3-4-2003')");
            Sql("INSERT INTO Movies(Id, Name, Genre, NumberInStock, ReleaseDate, DateAdded) VALUES (2, 'Die Hard', 'Action', 10, '1-14-1991 8:00:00 AM', '6-1-1991 8:00:00 AM')");
            Sql("INSERT INTO Movies(Id, Name, Genre, NumberInStock, ReleaseDate, DateAdded) VALUES (3, 'The Matrix', 'Action', 20, '1-14-1991 8:00:00 AM', '8-24-1998 8:00:00 AM')");
            Sql("INSERT INTO Movies(Id, Name, Genre, NumberInStock, ReleaseDate, DateAdded) VALUES (4, 'Tomb Raider', 'Action', 13, '1-14-1991 8:00:00 AM', '2-17-1996 8:00:00 AM')");
            Sql("INSERT INTO Movies(Id, Name, Genre, NumberInStock, ReleaseDate, DateAdded) VALUES (5, 'John Wick', 'Action', 11, '1-14-1991 8:00:00 AM', '4-19-2011 8:00:00 AM')");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }
        
        public override void Down()
        {
        }
    }
}
