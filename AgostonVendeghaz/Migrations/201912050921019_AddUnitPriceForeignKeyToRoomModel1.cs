namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitPriceForeignKeyToRoomModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "UnitPriceID");
            RenameColumn(table: "dbo.Rooms", name: "UnitPrices_Id", newName: "UnitPriceID");
            RenameIndex(table: "dbo.Rooms", name: "IX_UnitPrices_Id", newName: "IX_UnitPriceID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rooms", name: "IX_UnitPriceID", newName: "IX_UnitPrices_Id");
            RenameColumn(table: "dbo.Rooms", name: "UnitPriceID", newName: "UnitPrices_Id");
            AddColumn("dbo.Rooms", "UnitPriceID", c => c.Int());
        }
    }
}
