// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyEntityRepositoryTests.cs" company="">
//   
// </copyright>
// <summary>
//   The compnay entity repositorytests.
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
    /// The compnay entity repositorytests.
    /// </summary>
    [TestFixture]
    public class CompanyEntityRepositoryTests
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
        /// The document entity repository.
        /// </summary>
        private DocumentEntityRepository documentEntityRepository;

        /// <summary>
        /// The company entity repository.
        /// </summary>
        private CompanyEntityRepository companyEntityRepository;


        /// <summary>
        /// The create.
        /// </summary>
        [Test]
        public void Create()
        {
            this.companyEntityRepository.Create(this.company);
            var test = this.companyEntityRepository.ReadOne(this.company.Id);
            Assert.AreEqual(test.Code , this.company.Code);
            this.companyEntityRepository.Delete(this.company.Id);
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        [Test]
        public void ReadAllList()
        {
            var list = this.companyEntityRepository.ReadAllList();
            Assert.AreEqual(list.Count , 3);
        }

        /// <summary>
        /// The read one.
        /// </summary>
        [Test]
        public void ReadOne()
        {
            var test = this.companyEntityRepository.ReadOne(this.company.Id);
            Assert.AreEqual(test.Code , this.company.Code);
        }

        /// <summary>
        /// The read one query.
        /// </summary>
        [Test]
        public void ReadOneQuery()
        {
            var context = new DataBaseContext();
            var test = this.companyEntityRepository.ReadAllQuery(context);
            var doc = test.ToList().Find(x => x.Id == this.company.Id);
            Assert.AreEqual(doc.Code , this.company.Code);
            context.Dispose();
        }

        /// <summary>
        /// The setup test.
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            this.companyEntityRepository = new CompanyEntityRepository();
            this.documentEntityRepository = new DocumentEntityRepository();

            var context = new DataBaseContext();

            this.document = new Document
            {
                Name = "AlexDocumentation" ,
                Code = "AD" ,
                Balance = 100 ,
                Updated = DateTime.Now ,
                Deleted = DateTime.Now
            };

            var companyQuery = this.companyEntityRepository.ReadAllQuery(context);
            this.company = companyQuery.SingleOrDefault(x => x.Code == "ATC")
                           ?? this.companyEntityRepository.Create(
                               new Company
                               {
                                   Name = "AlexTestCompany" ,
                                   Code = "ATC" ,
                                   Active = true ,
                                   Updated = DateTime.Now ,
                                   Deleted = DateTime.Now,
                                   TaxId = "123456789"
                               });

            this.companyEntityRepository.Create(this.company);
            this.company = this.companyEntityRepository.ReadAllList().SingleOrDefault(x => x.Id == this.company.Id);
            this.document.Company = this.company;
            this.documentEntityRepository.Create(this.document);
            this.document = this.documentEntityRepository.ReadOne(this.document.Id);
            
            context.Dispose();
        }

        /// <summary>
        /// The update.
        /// </summary>
        [Test]
        public void Update()
        {
            this.company.Code = "abc";
            this.company.Name = "Mitsos";
            this.companyEntityRepository.Update(this.company);
            var newCompany = this.companyEntityRepository.ReadOne(this.company.Id);

            Assert.IsNotNull(newCompany);
            Assert.AreEqual(newCompany.Code , "abc");
            Assert.AreEqual(newCompany.Name , "Mitsos");
            Assert.AreEqual(
                newCompany.Updated.Value.ToString("dd/MM/yyyy hh:mm:ss") ,
                DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }
       
        /// <summary>
        /// The link.
        /// </summary>
        [Test]
        public void Unlink()
        {
            var documentToBeUnlinked = this.company.Documents.SingleOrDefault(mydocument => mydocument.Id == this.document.Id);
            if (documentToBeUnlinked != null)
            {
                this.companyEntityRepository.Unlink(documentToBeUnlinked.Id);
            }
            var test = this.documentEntityRepository.ReadOne(documentToBeUnlinked.Id);
            Assert.IsNull(test.Company);
        }

        [TearDown]
        public void CleanupTest()
        {
            if (this.documentEntityRepository.ReadOne(this.document.Id) != null)
            {
                this.documentEntityRepository.Delete(this.document.Id);
            }

            if (this.companyEntityRepository.ReadOne(this.company.Id) != null)
            {
                this.companyEntityRepository.Delete(this.company.Id);
            }

        }
    }
}