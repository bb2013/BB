namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pages2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Order", c => c.Int(nullable: false));
            AlterColumn("dbo.Pages", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "ParentId", c => c.Double(nullable: false));
            DropColumn("dbo.Pages", "Order");
        }
    }
}
