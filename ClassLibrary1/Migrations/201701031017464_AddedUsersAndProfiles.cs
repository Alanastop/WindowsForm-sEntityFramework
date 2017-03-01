// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201701031017464_AddedUsersAndProfiles.cs" company="">
//   
// </copyright>
// <summary>
//   The added users and profiles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    /// <summary>
    /// The added users and profiles.
    /// </summary>
    public partial class AddedUsersAndProfiles : DbMigration
    {
        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Profile", "UserId", "dbo.User");
            this.DropIndex("dbo.Profile", new[] { "UserId" });
            this.DropTable("dbo.User");
            this.DropTable("dbo.Profile");
        }

        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                    "dbo.Profile",
                    c =>
                        new
                            {
                                Id = c.Int(nullable: false, identity: true),
                                UserId = c.Int(nullable: false),
                                ProfileType = c.Int(nullable: false),
                                ViewId = c.String(nullable: false),
                                Customization = c.String(nullable: false),
                            })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                    "dbo.User",
                    c => new { Id = c.Int(nullable: false, identity: true), Name = c.String(nullable: false), })
                .PrimaryKey(t => t.Id);
        }
    }
}