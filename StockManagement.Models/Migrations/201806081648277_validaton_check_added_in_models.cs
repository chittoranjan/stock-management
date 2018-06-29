namespace StockManagement.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validaton_check_added_in_models : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Products", "Code", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Code", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
