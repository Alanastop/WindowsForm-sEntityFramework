// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201611220957010_ChangesOnCompany.cs" company="">
//   
// </copyright>
// <summary>
//   The changes on company.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    /// <summary>
    /// The changes on company.
    /// </summary>
    public partial class ChangesOnCompany : DbMigration
    {
        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.AlterColumn("dbo.Company", "Code", c => c.String());
        }

        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            this.AlterColumn("dbo.Company", "Code", c => c.String(nullable: false));
        }
    }
}