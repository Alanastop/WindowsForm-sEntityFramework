// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityController.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The EntityController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers.Interface
{
    #region

    using System.Collections.Generic;

    using DcProgrammingTutorial.Lib.Model.Persistent.Interface;
    using DcProgrammingTutorial.Lib.Repositories.Interface;

    #endregion

    /// <summary>
    /// The EntityController interface.
    /// </summary>
    /// <typeparam name="T">
    /// Company or Document.
    /// </typeparam>
    public interface IEntityController<T>
        where T : IEntity
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        IEntityRepository<T> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T CreateOrUpdateEntity(T entity);

        /// <summary>
        /// The delete entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void DeleteEntity(T entity);

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Entity}"/>.
        /// </returns>
        IList<T> RefreshEntities();

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetEntity(int id);
    }
}