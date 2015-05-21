namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new46 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Discount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Discount", c => c.Double(nullable: false));
        }
    }
}
