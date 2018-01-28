namespace WebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departements", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departements", "Name", c => c.Int(nullable: false));
        }
    }
}
