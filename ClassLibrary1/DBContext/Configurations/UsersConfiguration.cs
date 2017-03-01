// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersConfiguration.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The user configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.DBContext.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using DcProgrammingTutorial.Lib.Model.Persistent;

    /// <summary>
    /// The user configuration.
    /// </summary>
    public class UsersConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersConfiguration"/> class.
        /// </summary>
        public UsersConfiguration()
        {
            this.ToTable("User");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasMany(x => x.Profiles).WithRequired(x => x.User).HasForeignKey(x => x.UserId);

            // Required Entities
            this.Property(x => x.Name).IsRequired();
            this.Property(x => x.Code).IsOptional();
        }
    }
}
