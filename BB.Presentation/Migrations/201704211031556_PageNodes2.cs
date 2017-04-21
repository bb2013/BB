namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageNodes2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageNodes", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageNodes", "ParentId", "dbo.PageNodes");
            DropIndex("dbo.PageNodes", new[] { "ParentId" });
            DropTable("dbo.PageNodes");
        }
    }
}
