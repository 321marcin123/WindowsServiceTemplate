namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSomething = c.Boolean(nullable: false),
                        Name = c.String(),
                        SomeValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestClasses");
        }
    }
}
