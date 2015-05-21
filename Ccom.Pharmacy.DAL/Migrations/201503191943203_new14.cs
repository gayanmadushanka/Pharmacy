namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceItem", "TotalAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceItem", "TotalAmount");
        }
    }
}
