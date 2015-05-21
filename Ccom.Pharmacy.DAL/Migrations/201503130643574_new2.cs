namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceItem", "ItemId", "dbo.Item");
            DropIndex("dbo.InvoiceItem", new[] { "ItemId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.InvoiceItem", "ItemId");
            AddForeignKey("dbo.InvoiceItem", "ItemId", "dbo.Item", "Id", cascadeDelete: true);
        }
    }
}
