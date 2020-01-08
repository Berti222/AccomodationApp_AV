namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserdataToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Street", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "HouseNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HouseNumber");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
