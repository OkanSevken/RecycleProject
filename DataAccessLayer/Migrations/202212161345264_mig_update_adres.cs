namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_adres : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserAdress", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserAdress", c => c.String(maxLength: 50));
        }
    }
}
