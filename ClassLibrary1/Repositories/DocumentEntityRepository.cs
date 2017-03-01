// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentEntityRepository.cs" company="Data Communication">
//  DC Tutorial 
// </copyright>
// <summary>
//   The document entity provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories.Interface;

    #endregion

    /// <summary>
    /// The Document entity Repository.
    /// </summary>
    public class DocumentEntityRepository : IEntityRepository<Document>
    {
        /// <summary>
        /// Creates a Document.
        /// </summary>
        /// <summary>
        /// Creates a document.
        /// </summary>
        /// <param name="document">
        /// The entity parameter.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        public Document Create(Document document)
        {
            using (var context = new DataBaseContext())
            {
                context.Document.Add(document);
                if (document.Company != null)
                {
                    context.Entry(document.Company).State = EntityState.Unchanged;
                    document.Company.Documents.Where(x => x.Id > 0)
                        .ToList()
                        .ForEach(x => context.Entry(x).State = EntityState.Unchanged);
                }

                context.SaveChanges();
            }

            return document;
        }

        /// <summary>
        /// Deletes a Document by id.
        /// </summary>
        /// <param name="id">
        /// The Document Id.
        /// </param>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var document = context.Document.SingleOrDefault(x => x.Id == id);
                if (document == null)
                {
                    throw new ArgumentNullException($"ArgumentNullException");
                }

                context.Document.Remove(document);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a Document by id and User name.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="createdBy">
        /// The created by.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Document is null
        /// </exception>
        public void Delete(int id, string createdBy)
        {
            using (var context = new DataBaseContext())
            {
                var document = context.Document.SingleOrDefault(x => x.Id == id && x.CreatedBy == createdBy);
                if (document == null)
                {
                    throw new ArgumentNullException();
                }

                context.Document.Remove(document);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Reads all documents.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Document}"/>.
        /// returns a list of documents
        /// </returns>
        public IList<Document> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Document.Include("Company").ToList();
            }
        }

        /// <summary>
        /// Reads all documents by query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Document> ReadAllQuery(DataBaseContext context)
        {
            return context.Document.Include("Company");
        }

        /// <summary>
        /// Reads single Document.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        public Document ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var document = context.Document.Include("Company").SingleOrDefault(x => x.Id == id);
                return document;
            }
        }

        /// <summary>
        /// Updates a document.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// DataBase Document is Null
        /// </exception>
        public void Update(Document document)
        {
            using (var context = new DataBaseContext())
            {
                var databaseDocument = context.Document.Include("Company").SingleOrDefault(x => x.Id == document.Id);
                if (databaseDocument == null)
                {
                    return;
                }

                if (document.Company != null)
                {
                    var databaseCompany = context.Company.SingleOrDefault(x => x.Id == document.Company.Id);
                    databaseDocument.Company = databaseCompany;
                }
                else
                {
                    databaseDocument.CompanyId = null;
                }

                databaseDocument.Name = document.Name;
                databaseDocument.Code = document.Code;
                databaseDocument.Balance = document.Balance;  
                databaseDocument.Updated = DateTime.Now;
                databaseDocument.UpdatedBy = Environment.UserName;
                context.SaveChanges();
            }
        }
    }
}