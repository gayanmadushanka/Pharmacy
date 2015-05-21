namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InvoiceItem", "SellingPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceItem", "SellingPrice", c => c.Double(nullable: false));
        }
    }
}
