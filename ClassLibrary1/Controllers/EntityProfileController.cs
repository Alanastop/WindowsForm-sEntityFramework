// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityProfileController.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The entity profile controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories;
    using DcProgrammingTutorial.Lib.Repositories.Interface;

    /// <summary>
    /// The entity profile controller.
    /// </summary>
    public class EntityProfileController : IEntityController<Profile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityProfileController"/> class.
        /// </summary>
        public EntityProfileController()
        {
            this.Repository = new ProfileEntityRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Profile> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Profile"/>.
        /// </returns>
        public Profile CreateOrUpdateEntity(Profile entity)
        {
            if (entity.Id == 0)
            {
                entity = this.Repository.Create(entity);
            }
            else
            {
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
        /// Returns an ArgumentNullException
        /// </exception> 
        public void DeleteEntity(Profile entity)
        {
            if (entity.Id > 0)
            {
                this.Repository.Delete(entity.Id);
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
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<Profile> RefreshEntities()
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
        /// The <see cref="Profile"/>.
        /// </returns>
        public Profile GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// Returns the profile.
        /// </summary>
        /// <param name="userId">
        /// The user Id.
        /// </param>
        /// <param name="viewId">
        /// The view Id.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// </returns>
        public Profile GetProfile(int userId, string viewId, ProfileType type)
        {
            using (var context = new DataBaseContext())
            {
                return this.Repository.ReadAllQuery(context).SingleOrDefault(x => x.UserId == userId && x.ViewId == viewId && x.ProfileType == type);
            }
        }
    }
}
