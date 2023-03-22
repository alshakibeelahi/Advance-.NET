namespace Z_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PkFkEmpDnrClctionCreqAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CRId = c.Int(nullable: false),
                        EId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectRequests", t => t.CRId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EId, cascadeDelete: true)
                .Index(t => t.CRId)
                .Index(t => t.EId);
            
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodDes = c.String(nullable: false),
                        PreTime = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        DId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donors", t => t.DId, cascadeDelete: true)
                .Index(t => t.DId);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Organization = c.String(nullable: false),
                        OrgAddress = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collections", "EId", "dbo.Employees");
            DropForeignKey("dbo.Collections", "CRId", "dbo.CollectRequests");
            DropForeignKey("dbo.CollectRequests", "DId", "dbo.Donors");
            DropIndex("dbo.CollectRequests", new[] { "DId" });
            DropIndex("dbo.Collections", new[] { "EId" });
            DropIndex("dbo.Collections", new[] { "CRId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Donors");
            DropTable("dbo.CollectRequests");
            DropTable("dbo.Collections");
        }
    }
}
