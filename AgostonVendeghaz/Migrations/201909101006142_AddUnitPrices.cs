namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitPrices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitPrices",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        RoomPrice = c.Int(nullable: false),
                        DiscountFromDay = c.Int(nullable: false),
                        Discount = c.Double(nullable: false),
                        ExtraBedPrice = c.Int(nullable: false),
                        TouristTaxPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnitPrices");
        }
    }
}
