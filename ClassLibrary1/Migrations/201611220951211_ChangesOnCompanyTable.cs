// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201611220951211_ChangesOnCompanyTable.cs" company="">
//   
// </copyright>
// <summary>
//   The changes on company table.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    /// <summary>
    /// The changes on company table.
    /// </summary>
    public partial class ChangesOnCompanyTable : DbMigration
    {
        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.RenameTable(name: "dbo.Company", newName: "Companies");
        }

        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            this.RenameTable(name: "dbo.Companies", newName: "Company");
        }
    }
}