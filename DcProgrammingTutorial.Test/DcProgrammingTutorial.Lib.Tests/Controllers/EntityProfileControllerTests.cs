using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcProgrammingTutorial.Lib.Tests.Controllers
{
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    /// <summary>
    /// The entity profile controller tests.
    /// </summary>
    [TestFixture]
    public class EntityProfileControllerTests
    {
        /// <summary>
        /// The profile.
        /// </summary>
        private Profile profile;

        /// <summary>
        /// The user.
        /// </summary>
        private User user;

        /// <summary>
        /// The entity user controller.
        /// </summary>
        private EntityUserController entityUserController;

        /// <summary>
        /// The entity profile controller.
        /// </summary>
        private EntityProfileController entityProfileController;

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

        /// <summary>
        /// The get profile.
        /// </summary>
        [Test]
        public void GetEntity()
        {
            var test = this.entityProfileController.GetEntity(this.profile.Id);
            Assert.AreEqual(test.ViewId, this.profile.ViewId);
        }

        /// <summary>
        /// The get profile null.
        /// </summary>
        [Test]
        public void GetEntityNul()
        {
            var test = this.entityProfileController.GetEntity(0);
            Assert.IsNull(test);
        }

        /// <summary>
        /// The get profile null.
        /// </summary>
        [Test]
        public void GetEntityWrongId()
        {
            var test = this.entityProfileController.GetEntity(10000000);
            Assert.IsNull(test);
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntity()
        {
            var currentUser = this.entityUserController.CreateOrUpdateEntity(this.user);
            var currentProfile = new Profile()
                                     {
                                         ProfileType = ProfileType.GridView,
                                         ViewId = "DocumentGridView",
                                         Code = "DGV",
                                         UserId = currentUser.Id,
                                         Customization = string.Empty
                                     };

            var test = this.entityProfileController.CreateOrUpdateEntity(currentProfile);
            Assert.AreEqual(test.ViewId, currentProfile.ViewId);
            this.entityProfileController.DeleteEntity(currentProfile);
        }

        /// <summary>
        /// The create or update entity 2.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntity2()
        {
            this.profile.UserId = 0;
            Assert.Throws<DbUpdateException>(() => this.entityProfileController.CreateOrUpdateEntity(this.profile));
        }

        /// <summary>
        /// The create or update entity update.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntityUpdate()
        {
            this.profile.Code = "DGV2";
            this.entityProfileController.CreateOrUpdateEntity(this.profile);
            var test = this.entityProfileController.GetEntity(this.profile.Id);
            Assert.AreEqual(test.Code, "DGV2");
        }

        /// <summary>
        /// The get profile.
        /// </summary>
        [Test]
        public void GetProfile()
        {
            var test = this.entityProfileController.GetProfile(this.user.Id, this.profile.ViewId, ProfileType.GridView);
            Assert.AreEqual(test.ViewId, this.profile.ViewId);
        }

        /// <summary>
        /// The get profile null id.
        /// </summary>
        [Test]
        public void GetProfileNullId()
        {
            var test = this.entityProfileController.GetProfile(0, this.profile.ViewId, ProfileType.GridView);
            Assert.IsNull(test);
        }

        /// <summary>
        /// The get profile wrong id.
        /// </summary>
        [Test]
        public void GetProfileWrongId()
        {
            var test = this.entityProfileController.GetProfile(100000000, this.profile.ViewId, ProfileType.GridView);
            Assert.IsNull(test);
        }


        /// <summary>
        /// The clear.
        /// </summary>
        [TearDown]
        public void Clear()
        {
            this.entityUserController.DeleteEntity(this.user);
        }
    }
}
