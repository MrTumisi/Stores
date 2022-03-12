namespace Stores.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "City");
        }
    }
}
