// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The profiles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Model.Persistent
{
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Model.Persistent.Interface;

    /// <summary>
    /// The profiles.
    /// </summary>
    public class Profile : IEntity
    {
        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of.
        /// </summary>
        public ProfileType ProfileType { get; set; }

        /// <summary>
        /// Gets or sets the entity type.
        /// </summary>
        public string ViewId { get; set; }

        /// <summary>
        /// Gets or sets the customization.
        /// </summary>
        public string Customization { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public User User { get; set; }
    }
}
