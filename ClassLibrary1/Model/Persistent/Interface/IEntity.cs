// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   An interface which holds the code and the id of our entities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Model.Persistent.Interface
{
    /// <summary>
    /// An interface which holds the code and the id of our entities.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the code of our current entities.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Gets or sets the id our current entities.
        /// </summary>
        int Id { get; set; }
    }
}