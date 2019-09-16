namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReserveRoomTableRenamedToReservedRooms : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReserveRooms", newName: "ReservedRooms");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ReservedRooms", newName: "ReserveRooms");
        }
    }
}
