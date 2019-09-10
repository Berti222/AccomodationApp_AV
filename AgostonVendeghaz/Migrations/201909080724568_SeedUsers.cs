namespace AgostonVendeghaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0967058b-7876-435b-82ab-c8e38075f72f', N'admin@agostonvendeghaz.com', 0, N'APlfJ2pgNt9CgrkFgABb32PVlfBK1B3qwV5Uk7zTVarg6hKqpjJfVF01dKzhCTGTVQ==', N'607c47dc-619e-47d2-96e3-65a819978161', NULL, 0, 0, NULL, 1, 0, N'admin@agostonvendeghaz.com')
    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0dd0d447-f6ed-42c8-91b2-198163573bc3', N'guest@agostonvendeghaz.com', 0, N'AKbhufoAiIZr6k4liHYPCTBRI+PsDr56bwxRI87KTsH543azhNrEE+9De2jG2mZkVg==', N'846cea0c-b121-4b4b-ae4f-667cd712662e', NULL, 0, 0, NULL, 1, 0, N'guest@agostonvendeghaz.com')
    
    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'70b6dfc7-7d4e-4976-88be-d0268fc280c2', N'Admin')

    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0967058b-7876-435b-82ab-c8e38075f72f', N'70b6dfc7-7d4e-4976-88be-d0268fc280c2')

");
        }
        
        public override void Down()
        {
        }
    }
}
