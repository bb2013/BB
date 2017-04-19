namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomersDbs",
                c => new
                    {
                        CustomersDbId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomersDbId);
            
            CreateTable(
                "dbo.InternalUsersDbs",
                c => new
                    {
                        InternalUsersDbId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InternalUsersDbId);
            
            DropTable("dbo.InternalUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InternalUsers",
                c => new
                    {
                        InternalUserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.InternalUserId);
            
            DropTable("dbo.InternalUsersDbs");
            DropTable("dbo.CustomersDbs");
        }
    }
}
