namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUnitPrice : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO 
            UnitPrices (Id, RoomPrice, DiscountFromDay, Discount, ExtraBedPrice, TouristTaxPrice)
            VALUES 
            (1, 8000, 5, 0.15, 2000, 500)");
        }
        
        public override void Down()
        {
        }
    }
}
