namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserDataToReservedRooms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservedRooms", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.ReservedRooms", new[] { "InvoiceId" });
            AddColumn("dbo.ReservedRooms", "Name", c => c.String(nullable: false));
            AddColumn("dbo.ReservedRooms", "ZipCode", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.ReservedRooms", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ReservedRooms", "Street", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.ReservedRooms", "HouseNumber", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ReservedRooms", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.ReservedRooms", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReservedRooms", "Email");
            DropColumn("dbo.ReservedRooms", "PhoneNumber");
            DropColumn("dbo.ReservedRooms", "HouseNumber");
            DropColumn("dbo.ReservedRooms", "Street");
            DropColumn("dbo.ReservedRooms", "City");
            DropColumn("dbo.ReservedRooms", "ZipCode");
            DropColumn("dbo.ReservedRooms", "Name");
            CreateIndex("dbo.ReservedRooms", "InvoiceId");
            AddForeignKey("dbo.ReservedRooms", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
        }
    }
}
