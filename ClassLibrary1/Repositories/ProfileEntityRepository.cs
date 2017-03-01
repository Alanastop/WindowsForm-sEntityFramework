// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileEntityRepository.cs" company="Data Communication">
// DcProgrammingTutorial  
// </copyright>
// <summary>
//   The profile entity repository.
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
    /// The profile entity repository.
    /// </summary>
    public class ProfileEntityRepository : IEntityRepository<Profile>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <returns>
        /// The <see cref="Profile"/>.
        /// </returns>
        public Profile Create(Profile profile)
        {
            using (var context = new DataBaseContext())
            {
                context.Profile.Add(profile);
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

            return profile;
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
                var profile = context.Profile.SingleOrDefault(x => x.Id == id);
                if (profile == null)
                {
                    throw new ArgumentNullException();
                }

                context.Profile.Remove(profile);
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
        ///  Returns an NotImplementedException.
        /// </exception>
        public void Delete(int id, string createdBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"></see>
        ///     .
        /// </returns>
        public IList<Profile> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Profile.Include("User").ToList();
            }
        }

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Profile> ReadAllQuery(DataBaseContext context)
        {
            return context.Profile.Include("User");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Profile"/>.
        /// </returns>
        public Profile ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var profile = context.Profile.Include("User").SingleOrDefault(x => x.Id == id);
                return profile;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        public void Update(Profile profile)
        {
            using (var context = new DataBaseContext())
            {
                var databaseProfile = context.Profile.SingleOrDefault(x => x.Id == profile.Id);

                if (databaseProfile == null)
                {
                    return;
                }

                databaseProfile.ProfileType = profile.ProfileType;
                databaseProfile.Customization = profile.Customization;
                databaseProfile.ViewId = profile.ViewId;
                databaseProfile.Code = profile.Code;
                databaseProfile.UserId = profile.UserId;
                context.SaveChanges();
            }
        }
    }
}
