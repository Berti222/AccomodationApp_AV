namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReserveRoom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReserveRooms", "RoomId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReserveRooms", "RoomId", c => c.Byte(nullable: false));
        }
    }
}
