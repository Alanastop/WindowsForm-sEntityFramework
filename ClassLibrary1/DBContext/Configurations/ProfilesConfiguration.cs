// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfilesConfiguration.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The profiles configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.DBContext.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using DcProgrammingTutorial.Lib.Model.Persistent;

    /// <summary>
    /// The profiles configuration.
    /// </summary>
    public class ProfilesConfiguration : EntityTypeConfiguration<Profile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilesConfiguration"/> class.
        /// </summary>
        public ProfilesConfiguration()
        {
            this.ToTable("Profile");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



            // Required Entities
            this.Property(x => x.UserId).IsRequired();
            this.Property(x => x.ProfileType).IsRequired();
            this.Property(x => x.ViewId).IsRequired();
            this.Property(x => x.Customization).IsRequired();
            this.Property(x => x.Code).IsOptional();
        }
    }
}
