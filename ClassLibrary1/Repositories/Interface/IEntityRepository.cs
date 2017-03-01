// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityRepository.cs" company="Data Communication">
//   DC Tutorial
// </copyright>
// <summary>
//   The OldEntityRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Repositories.Interface
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Model.Persistent.Interface;

    #endregion

    /// <summary>
    /// The OldEntityRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// Company or Document parameter
    /// </typeparam>
    public interface IEntityRepository<T>
        where T : IEntity
    {
        /// <summary>
        /// Creates a Company or Document.
        /// </summary>
        /// <param name="entity">
        /// Company or Document entity.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Create(T entity);

        /// <summary>
        /// Deletes the current Company or Document.
        /// </summary>
        /// <param name="id">
        /// The Id of the Company or Document.
        /// </param>
        void Delete(int id);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="createdBy">
        /// The created by.
        /// </param>
        void Delete(int id, string createdBy);

        /// <summary>
        /// Reads all Companies or Documents
        /// </summary>
        /// <returns>
        /// The <see cref="IList{List}"/>.
        /// </returns>
        IList<T> ReadAllList();

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> ReadAllQuery(DataBaseContext context);

        /// <summary>
        /// Reads single Company or Documents.
        /// </summary>
        /// <param name="id">
        /// The Id of the Company or Document.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        T ReadOne(int id);

        /// <summary>
        /// Updates the current Company or Document.
        /// </summary>
        /// <param name="entity">
        /// Takes a Company or Document entity.
        /// </param>
        void Update(T entity);
    }
}