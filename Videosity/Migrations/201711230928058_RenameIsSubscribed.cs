namespace Videosity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIsSubscribed : DbMigration
    {
        public override void Up() {
            RenameColumn("dbo.Customers", "isSubscribed", "tempSubscribed");
            RenameColumn("dbo.Customers", "tempSubscribed", "IsSubscribed");
        }

        public override void Down()
        {
        }
    }
}
