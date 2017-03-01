// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityUserController.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The entity user controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories;
    using DcProgrammingTutorial.Lib.Repositories.Interface;

    /// <summary>
    /// The entity user controller.
    /// </summary>
    public class EntityUserController : IEntityController<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityUserController"/> class.
        /// </summary>
        public EntityUserController()
        {
            this.Repository = new UserEntityRepository();
        }


        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<User> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User CreateOrUpdateEntity(User entity)
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
        /// Returns an ArgumentNullException.
        /// </exception>
        public void DeleteEntity(User entity)
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
        public IList<User> RefreshEntities()
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
        /// The <see cref="User"/>.
        /// </returns>
        public User GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The search users by user name.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public User GetUserByUserName(string userName)
        {
            using (var context = new DataBaseContext())
            {
                return this.Repository.ReadAllQuery(context).SingleOrDefault(user => user.Name == userName);
            }
        }
    }
}
