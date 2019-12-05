namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitPriceForeignKeyToRoomModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "UnitPriceID", c => c.Int());
            AddColumn("dbo.Rooms", "UnitPrices_Id", c => c.Byte());
            CreateIndex("dbo.Rooms", "UnitPrices_Id");
            AddForeignKey("dbo.Rooms", "UnitPrices_Id", "dbo.UnitPrices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UnitPrices_Id", "dbo.UnitPrices");
            DropIndex("dbo.Rooms", new[] { "UnitPrices_Id" });
            DropColumn("dbo.Rooms", "UnitPrices_Id");
            DropColumn("dbo.Rooms", "UnitPriceID");
        }
    }
}
