namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Menu : DbMigration
    {
        public override void Up()
        {
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
        
        public override void Down()
        {
            DropTable("dbo.Menus");
        }
    }
}
