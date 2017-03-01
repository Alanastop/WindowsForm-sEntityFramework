// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentController.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   A controller that that manipulates the documents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories;
    using DcProgrammingTutorial.Lib.Repositories.Interface;

    /// <summary>
    /// The document controller.
    /// </summary>
    public class DocumentController : IDocumentController, IEntityController<Document>
    {
        #region Const Messages

        /// <summary>
        /// The message that is displayed every time our list is empty.
        /// </summary>
        private const string DocumentListEmptyErrorMessage = "The provided list has no documents!";

        #endregion

        #region Private Variables

        /// <summary>
        /// The counter that increases the document id.
        /// </summary>
        private int counterId;

        #endregion 

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        public DocumentController()
        {
            this.counterId = 1;
            this.Repository = new DocumentEntityRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Document> Repository { get; set; }

        #region Public Methods

        /// <summary>
        /// A method that calculates the average balance of the documents in our current list.
        /// </summary>
        /// <param name="list">
        /// The cells binding list.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the average of our current documents.
        /// </returns>
        /// <exception cref="ArgumentException"> Fired when given list is empty.</exception>
        public virtual double CalculateAverageBalance(IList<Document> list)
        {
            if (list.Count > 0)
            {
                return list.Average(document => document.Balance);
            }
            else
            {
                throw new NullReferenceException(DocumentListEmptyErrorMessage);
            }
        }

        /// <summary>
        /// A method that calculates the tax of the selected document.
        /// </summary>
        /// <param name="document">
        /// The selected document.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the selected document tax.
        /// </returns>
        public virtual double CalculateTax(Document document)
        {
            return document.Balance * 0.4;
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Exception method
        /// </exception>
        public virtual Document CreateOrUpdateEntity(Document entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Not Implemented Exception
        /// </exception>
        public virtual void DeleteEntity(Document entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Document}"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not Implemented Exception
        /// </exception>
        public virtual IList<Document> RefreshEntities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not Implemented Exception
        /// </exception>
        public virtual Document GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}