namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitPricesIdAsInteger : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "UnitPrices_Id", "dbo.UnitPrices");
            DropIndex("dbo.Rooms", new[] { "UnitPrices_Id" });
            DropPrimaryKey("dbo.UnitPrices");
            AlterColumn("dbo.Rooms", "UnitPrices_Id", c => c.Int());
            AlterColumn("dbo.UnitPrices", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UnitPrices", "Id");
            CreateIndex("dbo.Rooms", "UnitPrices_Id");
            AddForeignKey("dbo.Rooms", "UnitPrices_Id", "dbo.UnitPrices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UnitPrices_Id", "dbo.UnitPrices");
            DropIndex("dbo.Rooms", new[] { "UnitPrices_Id" });
            DropPrimaryKey("dbo.UnitPrices");
            AlterColumn("dbo.UnitPrices", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Rooms", "UnitPrices_Id", c => c.Byte());
            AddPrimaryKey("dbo.UnitPrices", "Id");
            CreateIndex("dbo.Rooms", "UnitPrices_Id");
            AddForeignKey("dbo.Rooms", "UnitPrices_Id", "dbo.UnitPrices", "Id");
        }
    }
}
