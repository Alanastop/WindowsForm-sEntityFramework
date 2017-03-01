// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyEntityRepository.cs" company="Data Communication">
// DcProgrammingTutorial  
// </copyright>
// <summary>
//   The company entity provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories.Interface;

    /// <summary>
    /// The company entity provider.
    /// </summary>
    public class CompanyEntityRepository : IEntityRepository<Company>
    {
        /// <summary>
        /// Creates a Company.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// The company
        /// </returns>
        public Company Create(Company company)
        {
            using (var context = new DataBaseContext())
            {
                context.Company.Add(company);
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var validationErrors in exception.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                "Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }

            return company;
        }

        /// <summary>
        /// Deletes a Company by Id.
        /// </summary>
        /// <param name="id">
        /// The Company Id.
        /// </param>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var company = context.Company.SingleOrDefault(x => x.Id == id);
                if (company == null)
                {
                    throw new ArgumentNullException();
                }

                context.Company.Remove(company);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes Company by Id and Name
        /// </summary>
        /// <param name="id">
        /// The Company id.
        /// </param>
        /// <param name="createdBy">
        /// The Company created by.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Company is null
        /// </exception>
        public void Delete(int id, string createdBy)
        {
            using (var context = new DataBaseContext())
            {
                var company = context.Company.SingleOrDefault(x => x.Id == id && x.CreatedBy == createdBy);
                if (company == null)
                {
                    throw new ArgumentNullException();
                }

                context.Company.Remove(company);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Reads all Companies.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Company}"/>.
        /// </returns>
        public IList<Company> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Company.Include("Documents").ToList();
            }
        }

        /// <summary>
        /// Reads all Companies by query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Company> ReadAllQuery(DataBaseContext context)
        {
            return context.Company.Include("Documents");
        }

        /// <summary>
        /// Reads a single Company.
        /// </summary>
        /// <param name="id">
        /// The Company Id.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// </returns>
        public Company ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var company = context.Company.Include("Documents").SingleOrDefault(x => x.Id == id);
                return company;
            }
        }

        /// <summary>
        /// Updates a Company.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// DataBase Company is Null
        /// </exception>
        public void Update(Company company)
        {
            using (var context = new DataBaseContext())
            {
                var databaseCompany = context.Company.SingleOrDefault(x => x.Id == company.Id);

                if (databaseCompany == null)
                {
                    return;
                }

                databaseCompany.Name = company.Name;
                databaseCompany.Code = company.Code;
                databaseCompany.TaxId = company.TaxId;
                databaseCompany.Updated = DateTime.Now;
                databaseCompany.UpdatedBy = Environment.UserName;
                databaseCompany.TaxId = company.TaxId;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Unlinks the selected document from company.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Unlink(int id)
        {
            using (var context = new DataBaseContext())
            {
                var databaseDocument = context.Document.SingleOrDefault(x => x.Id == id);

                if (databaseDocument == null)
                {
                    return;
                }

                databaseDocument.Company = null;
                databaseDocument.CompanyId = null;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The unlink.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        public void Unlink(Company company, Document document)
        {
            using (var context = new DataBaseContext())
            {
                var databaseCompany = context.Company.SingleOrDefault(x => x.Id == company.Id);
                var databaseDocument = context.Document.SingleOrDefault(x => x.Id == document.Id);
                if (databaseCompany == null)
                {
                    return;
                }

                databaseCompany.Documents.Remove(databaseDocument);
                context.SaveChanges();
            }
        }

    }
}