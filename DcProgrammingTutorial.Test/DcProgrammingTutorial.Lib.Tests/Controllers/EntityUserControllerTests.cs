// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityUserControllerTests.cs" company="">
//   
// </copyright>
// <summary>
//   The entity user controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Tests.Controllers
{
    #region

    using System.Data.Entity.Infrastructure;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The entity user controller.
    /// </summary>
    [TestFixture]
    public class EntityUserControllerTests
    {
        /// <summary>
        /// The entity profile controller.
        /// </summary>
        private EntityProfileController entityProfileController;

        /// <summary>
        /// The entity user controller.
        /// </summary>
        private EntityUserController entityUserController;

        /// <summary>
        /// The profile.
        /// </summary>
        private Profile profile;

        /// <summary>
        /// The user.
        /// </summary>
        private User user;

        /// <summary>
        /// The clear.
        /// </summary>
        [TearDown]
        public void Clear()
        {
            this.entityUserController.DeleteEntity(this.user);
        }

        /// <summary>
        /// The get user by user name.
        /// </summary>
        [Test]
        public void GetUserByUserName()
        {
            var test = this.entityUserController.GetUserByUserName(this.user.Name);
            Assert.AreEqual(test.Name, this.user.Name);
        }

        /// <summary>
        /// The get user by user null name.
        /// </summary>
        [Test]
        public void GetUserByUserNullName()
        {
            var test = this.entityUserController.GetUserByUserName(null);
            Assert.IsNull(test);
        }

        /// <summary>
        /// The get user by user wrong name.
        /// </summary>
        [Test]
        public void GetUserByUserWrongName()
        {
            var test = this.entityUserController.GetUserByUserName("Mitsos");
            Assert.IsNull(test);
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntity()
        {
           var currentUser = new User()
            {
                Name = "Kitsos",
                Code = "DGV" 
            };

            this.entityUserController.CreateOrUpdateEntity(currentUser);
            var test = this.entityUserController.GetUserByUserName(currentUser.Name);
            Assert.AreEqual(test.Name, currentUser.Name);
            this.entityUserController.DeleteEntity(currentUser);
        }

        /// <summary>
        /// The create or update entity 2.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntityCreateException()
        {
            var currentUser = new User()
            {
                Name = null,
                Code = "DGV"
            };

            this.entityUserController.CreateOrUpdateEntity(currentUser);
            var test = this.entityUserController.GetUserByUserName(currentUser.Name);
            Assert.IsNull(test);
        }

        /// <summary>
        /// The create or update entity 2.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntityException()
        {
            this.user.Name = null;
            var test = this.entityUserController.GetUserByUserName(this.user.Name);
            Assert.IsNull(test);
        }

        /// <summary>
        /// The create or update entity update.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntityUpdate()
        {
            this.user.Name = "Tasos";
            this.entityUserController.CreateOrUpdateEntity(this.user);
            var test = this.entityUserController.GetUserByUserName(this.user.Name);
            Assert.AreEqual(test.Name, "Tasos");
        }

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.user = new User() { Name = "Alex", Code = "Al" };
            this.entityUserController = new EntityUserController();
            var currentUser = this.entityUserController.CreateOrUpdateEntity(this.user);
            this.profile = new Profile()
                               {
                                   ProfileType = ProfileType.GridView,
                                   ViewId = "CompanyGridView",
                                   Code = "CGV",
                                   UserId = currentUser.Id,
                                   Customization = string.Empty
                               };
            this.entityProfileController = new EntityProfileController();
            this.entityProfileController.CreateOrUpdateEntity(this.profile);
        }
    }
}