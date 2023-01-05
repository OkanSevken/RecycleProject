namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(maxLength: 50),
                        ArticleQuantity = c.Int(nullable: false),
                        Carbon = c.Int(nullable: false),
                        RecyclType = c.String(maxLength: 50),
                        AddCarbon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 50),
                        UserAdress = c.String(maxLength: 50),
                        TotalCarbon = c.Int(nullable: false),
                        ArticleID = c.Int(nullable: false),
                        AddCarbon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .Index(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ArticleID", "dbo.Articles");
            DropIndex("dbo.Users", new[] { "ArticleID" });
            DropTable("dbo.Users");
            DropTable("dbo.Articles");
        }
    }
}
