namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foriknadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Courses", "OrganizationId");
            AddForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropTable("dbo.Organizations");
        }
    }
}
