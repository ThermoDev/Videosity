namespace Videosity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up() {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Sci-Fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Action')");
        }

        public override void Down()
        {
        }
    }
}
