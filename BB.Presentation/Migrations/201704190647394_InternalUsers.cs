namespace BB.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InternalUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InternalUsersDbs", "Email", c => c.String());
            AddColumn("dbo.InternalUsersDbs", "Password", c => c.String());
            AddColumn("dbo.InternalUsersDbs", "UserType", c => c.String());
            DropColumn("dbo.InternalUsersDbs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InternalUsersDbs", "Name", c => c.String());
            DropColumn("dbo.InternalUsersDbs", "UserType");
            DropColumn("dbo.InternalUsersDbs", "Password");
            DropColumn("dbo.InternalUsersDbs", "Email");
        }
    }
}
