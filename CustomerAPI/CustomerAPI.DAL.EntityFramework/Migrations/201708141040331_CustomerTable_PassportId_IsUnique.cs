namespace CustomerAPI.DAL.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTable_PassportId_IsUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Customers", "PassportId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "PassportId" });
        }
    }
}
