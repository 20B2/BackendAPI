namespace BackendAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATMs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        District = c.String(),
                        Tole = c.String(),
                        WardNo = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Lattitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BranchName = c.String(),
                        District = c.String(),
                        Tole = c.String(),
                        WardNo = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Lattitude = c.Double(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Branches");
            DropTable("dbo.ATMs");
        }
    }
}
