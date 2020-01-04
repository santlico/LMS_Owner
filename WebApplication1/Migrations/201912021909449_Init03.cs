namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "OwnerID", "dbo.Owners");
            DropIndex("dbo.Branches", new[] { "OwnerID" });
            RenameColumn(table: "dbo.Branches", name: "OwnerID", newName: "Owner_ID");
            AlterColumn("dbo.Branches", "Owner_ID", c => c.Int());
            CreateIndex("dbo.Branches", "Owner_ID");
            AddForeignKey("dbo.Branches", "Owner_ID", "dbo.Owners", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "Owner_ID", "dbo.Owners");
            DropIndex("dbo.Branches", new[] { "Owner_ID" });
            AlterColumn("dbo.Branches", "Owner_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Branches", name: "Owner_ID", newName: "OwnerID");
            CreateIndex("dbo.Branches", "OwnerID");
            AddForeignKey("dbo.Branches", "OwnerID", "dbo.Owners", "ID", cascadeDelete: true);
        }
    }
}
