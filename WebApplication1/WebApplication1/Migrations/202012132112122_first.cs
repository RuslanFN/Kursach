namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        INN = c.String(),
                        TelDot = c.String(),
                        schet = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Abonent_A_ID = c.Int(nullable: false),
                        Abonent_B_ID = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        IsNight = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TelDot_A = c.String(),
                        TelDot_B = c.String(),
                        Price_D = c.Single(nullable: false),
                        Price_N = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarifs");
            DropTable("dbo.Calls");
            DropTable("dbo.Abonents");
        }
    }
}
