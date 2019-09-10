namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTouristTax : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "TouristTax");
            DropColumn("dbo.ReserveRooms", "PeopleUnder18");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReserveRooms", "PeopleUnder18", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "TouristTax", c => c.Int(nullable: false));
        }
    }
}
