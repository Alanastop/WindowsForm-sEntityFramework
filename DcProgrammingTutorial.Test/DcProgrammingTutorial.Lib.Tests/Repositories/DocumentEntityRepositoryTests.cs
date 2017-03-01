// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentEntityRepositoryTests.cs" company="">
//   
// </copyright>
// <summary>
//   The document entity provider tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Tests.Repositories
{
    #region

    using System;
    using System.Linq;

    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The document entity provider tests.
    /// </summary>
    [TestFixture]
    public class DocumentEntityRepositoryTests
    {
        /// <summary>
        /// The company.
        /// </summary>
        private Company company;

        /// <summary>
        /// The company entity provider.
        /// </summary>
        private CompanyEntityRepository companyEntityRepository;

        /// <summary>
        /// The document.
        /// </summary>
        private Document document;

        /// <summary>
        /// The document entity provider.
        /// </summary>
        private DocumentEntityRepository documentEntityRepository;

        /// <summary>
        /// The document null.
        /// </summary>
        private Document documentNull;

        /// <summary>
        /// The cleanup test.
        /// </summary>
        [TearDown]
        public void CleanupTest()
        {
            if (this.documentEntityRepository.ReadOne(this.document.Id) != null) this.documentEntityRepository.Delete(this.document.Id);

            if (this.documentEntityRepository.ReadOne(this.documentNull.Id) != null) this.documentEntityRepository.Delete(this.documentNull.Id);

            if (this.companyEntityRepository.ReadOne(this.company.Id) != null) this.companyEntityRepository.Delete(this.company.Id);
        }

        /// <summary>
        /// The create.
        /// </summary>
        [Test]
        public void Create()
        {
            var doc = new Document()
                          {
                              Name = "KwstasNew",
                              Code = "KwstasNew Document",
                              Balance = 100,
                              Updated = DateTime.Now,
                              Deleted = DateTime.Now
                          };
            this.documentEntityRepository.Create(doc);
            var doc2 = this.documentEntityRepository.ReadOne(this.document.Id);
            Assert.AreEqual(this.document.Name, doc2.Name);
            this.documentEntityRepository.Delete(doc.Id);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        [Test]
        public void Delete()
        {
            this.documentEntityRepository.Delete(this.document.Id);
            Assert.IsNull(this.documentEntityRepository.ReadOne(this.document.Id));
        }

        /// <summary>
        /// The delete null.
        /// </summary>
        [Test]
        public void DeleteNullDocument()
        {
            this.document.Id = 0;
            var ex =
                Assert.Throws<ArgumentNullException>(
                    () => this.documentEntityRepository.Delete(this.document.Id, "andreadakis_k"));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null."));
        }

        /// <summary>
        /// The delete null with name.
        /// </summary>
        [Test]
        public void DeleteNullWithName()
        {
            var exp =
                Assert.Throws<ArgumentNullException>(() => this.documentEntityRepository.Delete(0, "andreadakis_k"));
            Assert.That(exp.Message, Is.EqualTo("Value cannot be null."));
        }

        /// <summary>
        /// The delete.
        /// </summary>
        [Test]
        public void DeleteWithName()
        {
            this.documentEntityRepository.Delete(this.document.Id, "andreadakis_k");
            Assert.IsNull(this.documentEntityRepository.ReadOne(this.document.Id));
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        [Test]
        public void ReadAllList()
        {
            var list = this.documentEntityRepository.ReadAllList();
            Assert.AreEqual(list.Count, 42);
        }

        /// <summary>
        /// The read one.
        /// </summary>
        [Test]
        public void ReadOne()
        {
            var test = this.documentEntityRepository.ReadOne(this.document.Id);
            Assert.AreEqual(test.Code, "Kwstas Document");
        }

        /// <summary>
        /// The read one query.
        /// </summary>
        [Test]
        public void ReadOneQuery()
        {
            var context = new DataBaseContext();
            var test = this.documentEntityRepository.ReadAllQuery(context);
            var doc = test.ToList().Find(x => x.Id == this.document.Id);
            Assert.AreEqual(doc.Code, this.document.Code);
            context.Dispose();
        }

        [Test]
        public void Update()
        {
            this.document.Balance = 180;
            this.document.Code = "abc";
            this.document.Name = "Mitsos";

            this.documentEntityRepository.Update(this.document);
            var dbDocument = this.documentEntityRepository.ReadOne(this.document.Id);
            Assert.IsNotNull(dbDocument);
            Assert.AreEqual(dbDocument.Balance , 180);
            Assert.AreEqual(dbDocument.Code , "abc");
            Assert.AreEqual(dbDocument.Name , "Mitsos");
            Assert.AreEqual(dbDocument.Updated.Value.ToString("dd/MM/yyyy hh:mm:ss") , DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));

        }

        /// <summary>
        /// The update null.
        /// </summary>
        [Test]
        public void UpdateNull()
        {

            this.document = null;
            

            var ex = Assert.Throws<NullReferenceException>(() => this.documentEntityRepository.Update(this.document));
            Assert.That(ex.Message, Is.EqualTo("Non-static method requires a target."));
        }



        /// <summary>
        /// The setup test.
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            this.documentEntityRepository = new DocumentEntityRepository();
            this.companyEntityRepository = new CompanyEntityRepository();

            this.document = new Document
                                {
                                    Name = "Kwstas",
                                    Code = "Kwstas Document",
                                    Balance = 100,
                                    Updated = DateTime.Now,
                                    Deleted = DateTime.Now
                                };
            this.documentNull = new Document
                                    {
                                        Name = "Kwstas",
                                        Code = "TestCodeNuull",
                                        Balance = 100,
                                        Updated = null,
                                        Deleted = null
                                    };

            var context = new DataBaseContext();

            var companyQuery = this.companyEntityRepository.ReadAllQuery(context);
            this.company = companyQuery.SingleOrDefault(x => x.Code == "KostasCode")
                           ?? this.companyEntityRepository.Create(
                               new Company
                                   {
                                       Name = "KostasTestCompany",
                                       Code = "KostasCode",
                                       Active = true,
                                       Updated = DateTime.Now,
                                       Deleted = DateTime.Now
                                   });

            // this.companyEntityRepository.Create(this.company);
            // this.company = this.companyEntityRepository.ReadAllList().SingleOrDefault(x => x.Id == this.company.Id);
            this.documentEntityRepository.Create(this.document);

            // this.documentEntityRepository.Create(this.documentNull);
            // this.document = this.documentEntityRepository.ReadOne(this.document.Id);
            // this.documentNull = this.documentEntityRepository.ReadOne(this.documentNull.Id);
            context.Dispose();
        }
       
    }
}