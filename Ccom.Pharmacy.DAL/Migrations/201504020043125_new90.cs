namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new90 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoice", "InvoiceNo", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoice", "InvoiceNo", c => c.Int(nullable: false));
        }
    }
}
