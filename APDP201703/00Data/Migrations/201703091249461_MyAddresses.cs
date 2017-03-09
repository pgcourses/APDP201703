namespace _00Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyAddresses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.MyAddresses");
        }
    }
}
