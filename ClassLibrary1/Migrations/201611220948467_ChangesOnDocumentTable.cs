// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201611220948467_ChangesOnDocumentTable.cs" company="">
//   
// </copyright>
// <summary>
//   The changes on document table.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    /// <summary>
    /// The changes on document table.
    /// </summary>
    public partial class ChangesOnDocumentTable : DbMigration
    {
        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.RenameTable(name: "dbo.Document", newName: "Documents");
        }

        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            this.RenameTable(name: "dbo.Documents", newName: "Document");
        }
    }
}