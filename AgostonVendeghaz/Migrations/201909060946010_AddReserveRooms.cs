namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReserveRooms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReserveRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        RoomId = c.Byte(nullable: false),
                        ReservedAt = c.DateTime(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        NumberOfPeople = c.Int(nullable: false),
                        PeopleUnder18 = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReserveRooms", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.ReserveRooms", new[] { "InvoiceId" });
            DropTable("dbo.ReserveRooms");
        }
    }
}
