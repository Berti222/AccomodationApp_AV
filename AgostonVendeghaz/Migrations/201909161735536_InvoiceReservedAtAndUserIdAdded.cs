namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceReservedAtAndUserIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "ReservedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Invoices", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "UserId");
            DropColumn("dbo.Invoices", "ReservedAt");
        }
    }
}
