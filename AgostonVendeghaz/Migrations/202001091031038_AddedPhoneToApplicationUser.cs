namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhoneToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
