namespace Videosity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerBirthDate : DbMigration
    {
        public override void Up() {
            Sql("UPDATE Customers SET BirthDate = '1994-09-14' WHERE Name = 'Norman Jayden'");
        }
        
        public override void Down()
        {
        }
    }
}
