// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBaseContext.cs" company="Data Communication">
//  DC Tutorial 
// </copyright>
// <summary>
//   The Database context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.DBContext
{
    #region

    using System.Data.Entity;

    using DcProgrammingTutorial.Lib.DBContext.Configurations;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    #endregion

    /// <summary>
    /// The Database context.
    /// </summary>
    public class DataBaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseContext"/> class.
        /// </summary>
        public DataBaseContext()
            : base("ConnectionString")
        {
        }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        public DbSet<Company> Company { get; set; }

        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        public DbSet<Document> Document { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        public DbSet<Profile> Profile { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new DocumentConfiguration());
            modelBuilder.Configurations.Add(new UsersConfiguration());
            modelBuilder.Configurations.Add(new ProfilesConfiguration());
        }
    }
}