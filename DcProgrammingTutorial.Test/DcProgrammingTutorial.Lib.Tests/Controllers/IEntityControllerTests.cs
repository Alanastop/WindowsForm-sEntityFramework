// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityControllerTests.cs" company="Data Communication">
//   DC Tutorial
// </copyright>
// <summary>
//   The i entity controller tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Tests.Controllers
{
    #region

    using System;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The i entity controller tests.
    /// </summary>
    [TestFixture]
    class IEntityControllerTests
    {
        /// <summary>
        /// The company.
        /// </summary>
        private Company company;

        /// <summary>
        /// The document.
        /// </summary>
        private Document document;

        /// <summary>
        /// The entity controller.
        /// </summary>
        private IEntityController<Document> entityController;

        /// <summary>
        /// The cleanup test.
        /// </summary>
        [TearDown]
        public void CleanupTest()
        {
            using (var context = new DataBaseContext())
            {
                var dbDocument = context.Document.Find(this.document.Id);
                if (dbDocument != null)
                {
                    context.Document.Remove(dbDocument);
                }

                var dbCompany = context.Company.Find(this.company.Id);
                if (dbCompany != null)
                {
                    context.Company.Remove(dbCompany);
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        [Test]
        public void CreateOrUpdateEntity()
        {
            using (var context = new DataBaseContext())
            {
                var doc = new Document { Name = "Kitsos", Code = "abc" };
                doc = this.entityController.CreateOrUpdateEntity(doc);

                var dbDocument = context.Document.Find(doc.Id);
                Assert.IsNotNull(dbDocument);
                Assert.AreEqual(dbDocument.Name, "Kitsos");
                Assert.IsNull(dbDocument.Updated);
                context.Document.Remove(dbDocument);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The setup test.
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            using (var context = new DataBaseContext())
            {
                this.company = new Company { Name = "Microsft", Code = "bcd" };
                context.Company.Add(this.company);
                this.document = new Document
                                    {
                                        Code = "abc",
                                        Name = "Alex",
                                        Balance = 108,
                                        Created = DateTime.Now,
                                        CreatedBy = Environment.UserName,
                                        Company = this.company
                                    };
                context.Document.Add(this.document);
                context.SaveChanges();
            }

            this.entityController = new EntityDocumentController();
        }

        /// <summary>
        /// The update entity.
        /// </summary>
        [Test]
        public void UpdateEntity()
        {
            using (var context = new DataBaseContext())
            {
                this.document.Name = "Giwrgos";
                this.entityController.CreateOrUpdateEntity(this.document);
                var dbDocument = context.Document.Find(this.document.Id);

                Assert.AreEqual(dbDocument.Name, "Giwrgos");
                Assert.AreEqual(
                    dbDocument.Updated.Value.ToString("dd/MM/yyyy hh:mm"),
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                context.Document.Remove(dbDocument);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The update entity ignoreing company.
        /// </summary>
        [Test]
        public void UpdateEntityIgnoreingCompany()
        {
            using (var context = new DataBaseContext())
            {
                this.document.Name = "Giwrgos";
                this.entityController.CreateOrUpdateEntity(this.document);
                var dbDocument = context.Document.Include("Company").SingleOrDefault(x => x.Id == this.document.Id);

                Assert.AreEqual(dbDocument.Name, "Giwrgos");
                Assert.AreEqual(
                    dbDocument.Updated.Value.ToString("dd/MM/yyyy hh:mm"),
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                Assert.AreNotEqual(dbDocument.Company.Name, "DC");
                context.Document.Remove(dbDocument);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The update entity throwin null argument exception.
        /// </summary>
        [Test]
        public void UpdateEntityThrowinNullArgumentException()
        {
            using (var context = new DataBaseContext())
            {
                var doc = new Document { Name = string.Empty, Code = "abc" };

                Assert.Throws<ArgumentNullException>(
                    () => this.entityController.CreateOrUpdateEntity(doc));
                var dbDocument = context.Document.Find(doc.Id);
                Assert.IsNull(dbDocument);
            }
        }
    }
}