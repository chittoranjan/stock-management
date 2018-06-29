namespace StockManagement.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_party_from_stockindetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockInDetails", "PartyId", "dbo.Parties");
            DropIndex("dbo.StockInDetails", new[] { "PartyId" });
            DropColumn("dbo.StockInDetails", "PartyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockInDetails", "PartyId", c => c.Int());
            CreateIndex("dbo.StockInDetails", "PartyId");
            AddForeignKey("dbo.StockInDetails", "PartyId", "dbo.Parties", "Id");
        }
    }
}
