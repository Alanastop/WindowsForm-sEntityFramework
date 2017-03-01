// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityDocumentController.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   Defines the EntityDocumentController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers
{
    using System;
    using System.Collections.Generic;

    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    /// <summary>
    /// The entity document controller.
    /// </summary>
    public class EntityDocumentController : DocumentControllerV2, IEntityController<Document>
    {
        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Null Exception
        /// </exception>
        public override Document CreateOrUpdateEntity(Document entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new ArgumentNullException();
            }

            if (entity.Id == 0)
            {
                //if (company != null)
                //{
                //    company.Documents.Clear();
                //    entity.Company = company;
                //}

                entity = this.Repository.Create(entity);
            }
            else
            {
                //entity.Company = company;
                //if (company == null)
                //{
                //    entity.CompanyId = 0;
                //}

                this.Repository.Update(entity);
            }

            return entity;
        }

        /// <summary>
        /// The delete entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Null Exception
        /// </exception>
        public override void DeleteEntity(Document entity)
        {
            if (entity.Id > 0)
            {
                this.Repository.Delete(entity.Id, Environment.UserName);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Document}"/>.
        /// </returns>
        public override IList<Document> RefreshEntities()
        {
            return this.Repository.ReadAllList();
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
        public override Document GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }
    }
}
