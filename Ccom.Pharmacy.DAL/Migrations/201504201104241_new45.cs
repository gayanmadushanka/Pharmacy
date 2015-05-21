namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "WholeSalePrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "WholeSalePrice");
        }
    }
}
