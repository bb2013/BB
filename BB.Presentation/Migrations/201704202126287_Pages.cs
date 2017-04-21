namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pages : DbMigration
    {
        public override void Up()
        {
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
                        ItemPosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PagesModelId);
            
        }
    }
}
