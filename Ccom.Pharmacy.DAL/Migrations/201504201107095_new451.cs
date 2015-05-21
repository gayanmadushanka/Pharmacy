namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new451 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Discount");
        }
    }
}
