// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyEntityProvider.cs" company="Data Communication">
//   company 
// </copyright>
// <summary>
//   The company entity provider.
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
    /// The company entity provider.
    /// </summary>
    public class CompanyEntityProvider : IEntityProvider<Company>
    {
        /// <summary>
        /// The read all.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{company}"/>.
        /// </returns>
        public IList<Company> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Company.ToList();
            }
        }

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Company> ReadAllQuery()
        {
            using (var context = new DataBaseContext())
            {
                return context.Company.Include("Company");
            }
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        public Company ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                return context.Company.SingleOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        public void Create(Company company)
        {
            using (var context = new DataBaseContext())
            {
                context.Company.Add(company);
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
        /// This exception checks if company is null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var company = context.Company.Find(id);
                if (company == null)
                {
                    throw new ArgumentNullException();
                }

                context.Company.Remove(company);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The Id.
        /// </param>
        /// <param name="createdBy">
        /// The Created By.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception checks if company is null
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
        /// The update.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        public void Update(Company company)
        {
            using (var context = new DataBaseContext())
            {
                var tempcompany = context.Document.Find(company.Id);
                tempcompany.Name = company.Name;
                tempcompany.Code = company.Code;
                tempcompany.UpdatedBy = Environment.UserName;
                tempcompany.Updated = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
