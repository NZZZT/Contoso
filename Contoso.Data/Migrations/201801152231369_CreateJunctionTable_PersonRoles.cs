namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateJunctionTable_PersonRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeopleRoles",
                c => new
                    {
                        People_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.People_Id, t.Role_Id })
                .ForeignKey("dbo.People", t => t.People_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.People_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeopleRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.PeopleRoles", "People_Id", "dbo.People");
            DropIndex("dbo.PeopleRoles", new[] { "Role_Id" });
            DropIndex("dbo.PeopleRoles", new[] { "People_Id" });
            DropTable("dbo.PeopleRoles");
        }
    }
}
