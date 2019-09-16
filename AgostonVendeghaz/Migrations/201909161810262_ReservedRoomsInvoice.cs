namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservedRoomsInvoice : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ReservedRooms", "InvoiceId");
            AddForeignKey("dbo.ReservedRooms", "InvoiceId", "dbo.Invoices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservedRooms", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.ReservedRooms", new[] { "InvoiceId" });
        }
    }
}
