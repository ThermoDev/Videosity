namespace Videosity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up() {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Godzilla 2017', '11-17-2017', '11-19-2017', 5, 9)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Guardians of the Galaxy', '07-31-2014', '11-19-2017', 6, 9)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('IT', '09-07-2017', '11-19-2017', 10, 5)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Desperado', '08-25-1995', '11-19-2017', 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
