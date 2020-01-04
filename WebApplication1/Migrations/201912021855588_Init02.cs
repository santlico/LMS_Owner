namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        branch_name = c.String(),
                        city = c.String(),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Owners", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrgName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Salary = c.Int(nullable: false),
                        JobTitle = c.String(),
                        Branche_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.Branche_ID)
                .Index(t => t.Branche_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "Branche_ID", "dbo.Branches");
            DropForeignKey("dbo.Branches", "OwnerID", "dbo.Owners");
            DropIndex("dbo.Workers", new[] { "Branche_ID" });
            DropIndex("dbo.Branches", new[] { "OwnerID" });
            DropTable("dbo.Workers");
            DropTable("dbo.Owners");
            DropTable("dbo.Branches");
        }
    }
}
