// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserEntityRepository.cs" company="Data Communication">
//    DcProgrammingTutorial
// </copyright>
// <summary>
//   The user entity repository.
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
    /// The user entity repository.
    /// </summary>
    public class UserEntityRepository : IEntityRepository<User>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User Create(User user)
        {
            using (var context = new DataBaseContext())
            {
                context.User.Add(user);
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

            return user;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Returns an ArgumentNullException.
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var user = context.User.SingleOrDefault(x => x.Id == id);
                if (user == null)
                {
                    throw new ArgumentNullException();
                }

                context.User.Remove(user);
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
        /// <exception cref="NotImplementedException">
        /// Returns an ArgumentNullException.
        /// </exception>
        public void Delete(int id, string createdBy)
        {
            using (var context = new DataBaseContext())
            {
                var user = context.User.SingleOrDefault(x => x.Id == id);
                if (user == null)
                {
                    throw new ArgumentNullException();
                }

                context.User.Remove(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Reads all Users.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Profile}"/>.
        /// </returns>
        public IList<User> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.User.Include("Profiles").ToList();
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
        public IQueryable<User> ReadAllQuery(DataBaseContext context)
        {
            return context.User.Include("Profiles");
        }

        /// <summary>
        /// Reads a single Company.
        /// </summary>
        /// <param name="id">
        /// The Company Id.
        /// </param>
        /// <returns>
        /// The <see cref="Profile"/>.
        /// </returns>
        public User ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var user = context.User.Include("Profiles").SingleOrDefault(x => x.Id == id);
                return user;
            }
        }

        /// <summary>
        /// Updates a Company.
        /// </summary>
        /// <param name="user">
        /// The company.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// DataBase Company is Null
        /// </exception>
        public void Update(User user)
        {
            using (var context = new DataBaseContext())
            {
                var databaseUser = context.User.SingleOrDefault(x => x.Id == user.Id);

                if (databaseUser == null)
                {
                    return;
                }

                databaseUser.Name = user.Name;
                context.SaveChanges();
            }
        }
    }
}
