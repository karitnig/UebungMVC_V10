namespace UebungMVC_V10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbSetDatum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        DatumID = c.Int(nullable: false, identity: true),
                        AnfangDateTime = c.DateTime(),
                        EndeDateTime = c.DateTime(),
                        AbstandDateTimeText = c.String(),
                    })
                .PrimaryKey(t => t.DatumID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Data");
        }
    }
}
