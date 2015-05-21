namespace Ccom.Pharmacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoice", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoice", "Discount");
        }
    }
}
