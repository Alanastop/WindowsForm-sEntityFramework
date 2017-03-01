// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The users.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Model.Persistent
{
    using System.Collections.Generic;

    using DcProgrammingTutorial.Lib.Model.Persistent.Interface;

    /// <summary>
    /// The users.
    /// </summary>
    public class User : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
          this.Profiles = new List<Profile>();  
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of profiles of the current user.
        /// </summary>
        public virtual IList<Profile> Profiles { get; set; }
    }
}   
