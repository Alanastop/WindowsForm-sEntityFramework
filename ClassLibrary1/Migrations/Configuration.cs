// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="">
//   
// </copyright>
// <summary>
//   The configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    #endregion

    /// <summary>
    /// The configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(DataBaseContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );

            //context.Company.AddOrUpdate(
            //    x => x.Code,
            //    new Company { Name = "DC Company", Code = "dc", Active = true },
            //    new Company { Name = "Microsoft", Code = "mc", Active = false });
        }
    }
}