namespace BackendAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAccounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AccountType = c.String(),
                        Balance = c.Int(nullable: false),
                        InterestRate = c.Int(nullable: false),
                        BranchId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionAmount = c.Int(nullable: false),
                        TransactionType = c.String(),
                        Description = c.String(),
                        CustomerAccount_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerAccounts", t => t.CustomerAccount_Id)
                .Index(t => t.CustomerAccount_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomerAccount_Id", "dbo.CustomerAccounts");
            DropForeignKey("dbo.CustomerAccounts", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.CustomerAccounts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "CustomerAccount_Id" });
            DropIndex("dbo.CustomerAccounts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CustomerAccounts", new[] { "BranchId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.CustomerAccounts");
        }
    }
}
