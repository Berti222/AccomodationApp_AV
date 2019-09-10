namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRooms1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Available", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "RoomNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomNumber", c => c.String(maxLength: 10));
            DropColumn("dbo.Rooms", "Available");
        }
    }
}
