namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "Email", c => c.String());
            AddColumn("dbo.Workers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Email");
            DropColumn("dbo.Owners", "Email");
        }
    }
}
