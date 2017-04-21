namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageNodes : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Menus");
            DropTable("dbo.Pages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PagesModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        ParentId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PagesModelId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        OrderId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId);
            
        }
    }
}
