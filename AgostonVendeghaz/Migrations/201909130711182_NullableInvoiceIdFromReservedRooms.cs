namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableInvoiceIdFromReservedRooms : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReservedRooms", "InvoiceId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReservedRooms", "InvoiceId", c => c.Int(nullable: false));
        }
    }
}
