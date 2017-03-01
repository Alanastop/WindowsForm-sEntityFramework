// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentEntityProvider.cs" company="Data Communication">
//   company
// </copyright>
// <summary>
//   Defines the DocumentEntityProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Classes.Persistent;
    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Interfaces;

    /// <summary>
    /// The document entity provider.
    /// </summary>
    public class DocumentEntityProvider : IEntityProvider<Document>
    {
        /// <summary>
        /// The read all.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{document}"/>.
        /// </returns>
        public IList<Document> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Document.Include("Company").ToList();
            }
        }

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Document> ReadAllQuery()
        {
            using (var context = new DataBaseContext())
            {
                return context.Document.Include("Company");
            }
        }

        /// <summary>
        /// The read one.
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
                return context.Document.Include("Company").SingleOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        public void Create(Document document)
        {
            using (var context = new DataBaseContext())
            {
                context.Document.Add(document);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception checks if document is null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var document = context.Document.Find(id);
                if (document == null)
                {
                    throw new ArgumentNullException();
                }

                context.Document.Remove(document);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="createdBy">
        /// The created by.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception checks if document is null
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
        /// The update.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        public void Update(Document document)
        {
            using (var context = new DataBaseContext())
            {
                var tempdocument = context.Document.Find(document.Id);
                tempdocument.Name = document.Name;
                tempdocument.Balance = document.Balance;
                tempdocument.Code = document.Code;
                tempdocument.UpdatedBy = Environment.UserName;
                tempdocument.Updated = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
