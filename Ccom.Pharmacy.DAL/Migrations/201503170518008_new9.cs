namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "UserName" });
            AddColumn("dbo.Invoice", "InvoiceNo", c => c.Int(nullable: false));
            AddColumn("dbo.Invoice", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Invoice", "Cash", c => c.Double(nullable: false));
            AddColumn("dbo.Invoice", "Balance", c => c.Double(nullable: false));
            AddColumn("dbo.Item", "Code", c => c.String(maxLength: 10));
            AddColumn("dbo.Item", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Item", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.ItemCategory", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.Invoice", "Description", c => c.String(maxLength: 400));
            AlterColumn("dbo.Item", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.ItemCategory", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.Supplier", "FirstName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Supplier", "LastName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Module", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.User", "MiddleName", c => c.String(maxLength: 200));
            AlterColumn("dbo.User", "LastName", c => c.String(maxLength: 200));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.UserRole", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.UserRole", "Description", c => c.String(maxLength: 400));
            CreateIndex("dbo.User", "UserName", unique: true);
            DropColumn("dbo.Invoice", "Amount");
            DropColumn("dbo.Item", "ActualPrice");
            DropColumn("dbo.Item", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Discount", c => c.Double(nullable: false));
            AddColumn("dbo.Item", "ActualPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Invoice", "Amount", c => c.Double(nullable: false));
            DropIndex("dbo.User", new[] { "UserName" });
            AlterColumn("dbo.UserRole", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserRole", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.User", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.User", "MiddleName", c => c.String(maxLength: 30));
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Module", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Supplier", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Supplier", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.ItemCategory", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Item", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Invoice", "Description", c => c.String());
            DropColumn("dbo.ItemCategory", "Code");
            DropColumn("dbo.Item", "TotalAmount");
            DropColumn("dbo.Item", "UnitPrice");
            DropColumn("dbo.Item", "Code");
            DropColumn("dbo.Invoice", "Balance");
            DropColumn("dbo.Invoice", "Cash");
            DropColumn("dbo.Invoice", "TotalAmount");
            DropColumn("dbo.Invoice", "InvoiceNo");
            CreateIndex("dbo.User", "UserName", unique: true);
        }
    }
}
