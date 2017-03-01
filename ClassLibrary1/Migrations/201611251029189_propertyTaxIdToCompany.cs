namespace DcProgrammingTutorial.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertyTaxIdToCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "TaxId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "TaxId");
        }
    }
}
