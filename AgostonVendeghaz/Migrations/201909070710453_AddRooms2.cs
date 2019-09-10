namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRooms2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Rooms", "Id");
        }
    }
}
