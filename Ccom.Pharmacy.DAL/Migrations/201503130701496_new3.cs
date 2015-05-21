namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.InvoiceItem", "ItemId");
            AddForeignKey("dbo.InvoiceItem", "ItemId", "dbo.Item", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItem", "ItemId", "dbo.Item");
            DropIndex("dbo.InvoiceItem", new[] { "ItemId" });
        }
    }
}
