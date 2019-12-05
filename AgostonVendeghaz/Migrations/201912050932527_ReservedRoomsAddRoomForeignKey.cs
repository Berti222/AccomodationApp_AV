namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservedRoomsAddRoomForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ReservedRooms", "RoomId");
            AddForeignKey("dbo.ReservedRooms", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservedRooms", "RoomId", "dbo.Rooms");
            DropIndex("dbo.ReservedRooms", new[] { "RoomId" });
        }
    }
}
