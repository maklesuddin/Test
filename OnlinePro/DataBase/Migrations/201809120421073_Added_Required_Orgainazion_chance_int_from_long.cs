namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Required_Orgainazion_chance_int_from_long : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropPrimaryKey("dbo.Organizations");
            AddColumn("dbo.Courses", "Organization_Id", c => c.Long());
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.Organizations", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Organizations", "Id");
            CreateIndex("dbo.Courses", "Organization_Id");
            AddForeignKey("dbo.Courses", "Organization_Id", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.Courses", new[] { "Organization_Id" });
            DropPrimaryKey("dbo.Organizations");
            AlterColumn("dbo.Organizations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "Code", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropColumn("dbo.Courses", "Organization_Id");
            AddPrimaryKey("dbo.Organizations", "Id");
            CreateIndex("dbo.Courses", "OrganizationId");
            AddForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
    }
}
