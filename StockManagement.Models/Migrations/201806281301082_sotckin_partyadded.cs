namespace StockManagement.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sotckin_partyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockIns", "PartyId", c => c.Int());
            CreateIndex("dbo.StockIns", "PartyId");
            AddForeignKey("dbo.StockIns", "PartyId", "dbo.Parties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockIns", "PartyId", "dbo.Parties");
            DropIndex("dbo.StockIns", new[] { "PartyId" });
            DropColumn("dbo.StockIns", "PartyId");
        }
    }
}
