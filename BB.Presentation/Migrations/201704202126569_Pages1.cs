namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pages1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PagesModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        ParentId = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PagesModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pages");
        }
    }
}
