namespace StockManagement.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockindetails_party_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockInDetails", "PartyId", c => c.Int());
            CreateIndex("dbo.StockInDetails", "PartyId");
            AddForeignKey("dbo.StockInDetails", "PartyId", "dbo.Parties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockInDetails", "PartyId", "dbo.Parties");
            DropIndex("dbo.StockInDetails", new[] { "PartyId" });
            DropColumn("dbo.StockInDetails", "PartyId");
        }
    }
}
