namespace Videosity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up() {
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE DiscountRate = 0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DiscountRate = 10");
            Sql("UPDATE MembershipTypes SET Name = 'Quartely' WHERE DiscountRate = 15");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHERE DiscountRate = 20");
        }
        
        public override void Down()
        {
        }
    }
}
