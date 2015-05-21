namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Description = c.String(),
                        ImagePath = c.String(),
                        Quantity = c.Int(nullable: false),
                        ActualPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        ExpireDate = c.DateTime(),
                        SupplierId = c.Int(nullable: false),
                        ItemCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategory", t => t.ItemCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Address = c.String(maxLength: 100),
                        ContactNumber = c.String(maxLength: 10),
                        AccountNumber = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Color = c.String(nullable: false, maxLength: 7),
                        ImagePath = c.String(nullable: false, maxLength: 100),
                        ToolTip = c.String(maxLength: 30),
                        PathToLoad = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        MiddleName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 128),
                        UserRoleId = c.Int(nullable: false),
                        Address = c.String(maxLength: 100),
                        HomeNumber = c.String(maxLength: 10),
                        OfficeNumber = c.String(maxLength: 10),
                        MobileNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 100),
                        ImagePath = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRole", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoleWithModule",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRoleId, t.ModuleId })
                .ForeignKey("dbo.UserRole", t => t.UserRoleId, cascadeDelete: true)
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.ModuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRoleId", "dbo.UserRole");
            DropForeignKey("dbo.UserRoleWithModule", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.UserRoleWithModule", "UserRoleId", "dbo.UserRole");
            DropForeignKey("dbo.InvoiceItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory");
            DropForeignKey("dbo.InvoiceItem", "InvoiceId", "dbo.Invoice");
            DropIndex("dbo.UserRoleWithModule", new[] { "ModuleId" });
            DropIndex("dbo.UserRoleWithModule", new[] { "UserRoleId" });
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.User", new[] { "UserRoleId" });
            DropIndex("dbo.User", new[] { "UserName" });
            DropIndex("dbo.Item", new[] { "ItemCategoryId" });
            DropIndex("dbo.Item", new[] { "SupplierId" });
            DropIndex("dbo.InvoiceItem", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceItem", new[] { "ItemId" });
            DropTable("dbo.UserRoleWithModule");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.Module");
            DropTable("dbo.Supplier");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.Item");
            DropTable("dbo.InvoiceItem");
            DropTable("dbo.Invoice");
        }
    }
}
