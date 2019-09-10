namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfNights = c.Int(nullable: false),
                        RoomPriceWithoutDiscount = c.Int(nullable: false),
                        RoomPriceWithDiscount = c.Int(nullable: false),
                        DiscountPercent = c.Int(nullable: false),
                        TouristTax = c.Int(nullable: false),
                        ExtraBed = c.Int(nullable: false),
                        ExtraBedPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invoices");
        }
    }
}
