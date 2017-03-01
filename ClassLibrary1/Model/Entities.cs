// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entities.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The entities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Model
{
    #region

    using DcProgrammingTutorial.Lib.Model.Persistent;

    #endregion

    /// <summary>
    /// The entities.
    /// </summary>
    public class Entities
    {
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public Company Company { get; set; }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        public Document Document { get; set; }
    }
}