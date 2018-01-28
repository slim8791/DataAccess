namespace WebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        DepartementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.Departements", t => t.DepartementId, cascadeDelete: true)
                .Index(t => t.DepartementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "DepartementId", "dbo.Departements");
            DropIndex("dbo.Employes", new[] { "DepartementId" });
            DropTable("dbo.Employes");
            DropTable("dbo.Departements");
        }
    }
}
