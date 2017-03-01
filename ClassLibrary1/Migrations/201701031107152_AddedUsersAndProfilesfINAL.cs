// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201701031107152_AddedUsersAndProfilesfINAL.cs" company="">
//   
// </copyright>
// <summary>
//   The added users and profilesf inal.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    /// <summary>
    /// The added users and profilesf inal.
    /// </summary>
    public partial class AddedUsersAndProfilesfINAL : DbMigration
    {
        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.DropColumn("dbo.User", "Code");
            this.DropColumn("dbo.Profile", "Code");
        }

        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("dbo.Profile", "Code", c => c.String());
            this.AddColumn("dbo.User", "Code", c => c.String());
        }
    }
}