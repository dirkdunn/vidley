namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReferenceDataToGenre : DbMigration
    {
        public override void Up()
        {
            //Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Action')");
            //Sql("SET IDENTITY_INSERT Genres OFF");

           

            
        }

        public override void Down()
        {
        }
    }
}
