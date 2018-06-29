namespace StockManagement.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isDeleted_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parties", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parties", "IsDeleted");
        }
    }
}
