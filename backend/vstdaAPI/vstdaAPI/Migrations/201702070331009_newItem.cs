namespace vstdaAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.listItems",
                c => new
                    {
                        listItemId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PriorityLevel = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.listItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.listItems");
        }
    }
}
