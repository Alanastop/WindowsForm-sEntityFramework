namespace DcProgrammingTutorial.Lib.Tests.Repositories
{
    using System;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories;

    using NUnit.Framework;

    /// <summary>
    /// The entity provider test.
    /// </summary>
    [TestFixture]
    public class EntityProviderTests
    {
        /// <summary>
        /// The entity provider.
        /// </summary>
        private OldEntityRepository oldEntityRepository;

        /// <summary>
        /// The document.
        /// </summary>
        private Document document;

        /// <summary>
        /// The company.
        /// </summary>
        private Company company;

        /// <summary>
        /// The document null.
        /// </summary>
        private Document documentNull;

        /// <summary>
        /// The setup test.
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            this.oldEntityRepository = new OldEntityRepository();
            this.document = new Document
                                {
                                    Name = "Kwstas",
                                    Code = "TestCode",
                                    Balance = 100,
                                    Updated = DateTime.Now,
                                    Deleted = DateTime.Now
                                };
            this.documentNull = new Document
            {
                Name = "Kwstas" ,
                Code = "TestCodeNuull" ,
                Balance = 100 ,
                Updated = null ,
                Deleted = null
            };
            this.company = new Company
                               {
                                   Name = "TestCompany",
                                   Code = "TC",
                                   Active = true,
                                   Updated = DateTime.Now,
                                   Deleted = DateTime.Now
                               };

            this.oldEntityRepository.DeleteCompany(this.company.Code);
            this.oldEntityRepository.CreateCompany(this.company);
            this.company = this.oldEntityRepository.ReadAllCompanies().SingleOrDefault(x => x.Code == this.company.Code);
           
            this.document.Company = this.company;
            this.documentNull.Company = this.company;
            this.oldEntityRepository.CreateDocument(this.document);
            this.oldEntityRepository.CreateDocument(this.documentNull);
            this.document = this.oldEntityRepository.ReadOneDocument(this.document);
            this.documentNull = this.oldEntityRepository.ReadOneDocument(this.documentNull);
        }


        [Test]
        public void ReadAllDocuments()
        {
            var test = this.oldEntityRepository.ReadAllDocuments();
            Assert.AreEqual(test.DocumentList.Count, 2);
        }
        

        [Test]
        public void ReadAllDocumentsUpdated()
        {
            
            this.document.Name = "pantofles";
            this.oldEntityRepository.UpdateDocument(this.document);
            var values = this.oldEntityRepository.ReadAllDocuments();
            Assert.AreEqual(values.DocumentList.Count, 2);
            Assert.IsNotNull(values.DocumentList.SingleOrDefault(x => x.Code == this.document.Code).Deleted);
        }

        [Test]
        public void ReadAllDocumentsCompanies()
        {
            this.oldEntityRepository.CompanyList.Add(this.company);
            var values = this.oldEntityRepository.ReadAllDocuments();
            Assert.AreEqual(values.DocumentList.FirstOrDefault().Company.Code, this.company.Code);
            Assert.IsNotNull(values.DocumentList.FirstOrDefault().Company.Updated);
        }

        [TestCase("2016-10-10")]
        [TestCase("")]
        public void CreateDocument(string dateString)
        {
            DateTime? date = null;
            if (!string.IsNullOrEmpty(dateString))
            {
                date = DateTime.Parse(dateString);
            }
            

            var myDocument = new Document
                                 {
                                     Name = "Alex",
                                     Code = "papaki",
                                     Balance = 100,
                                     Updated = date ,
                                     Deleted = date,
                                     Company = this.company
                                 };
            this.oldEntityRepository.CreateDocument(myDocument);
            Assert.AreEqual(
                this.oldEntityRepository.ReadOneDocument(myDocument).Name,
                "Alex");
            var myDocumentToBeDeleted = this.oldEntityRepository.ReadOneDocument(myDocument);
            this.oldEntityRepository.DeleteDocument(myDocumentToBeDeleted);
        }
        
        [Test]
        public void DeleteDocument()
        {

            this.oldEntityRepository.DeleteDocument(this.document);

            Assert.AreEqual(
                this.oldEntityRepository.ReadAllDocuments().DocumentList.Count,
                1);
        }

        [Test]
        public void ReadAllCompanies()
        {
            Assert.AreEqual(this.oldEntityRepository.ReadAllCompanies().Count, 4);
        }

        [Test]
        public void UpdateDocument()
        {
            this.document.Name = "Manos";
            this.oldEntityRepository.UpdateDocument(this.document);
            Assert.AreEqual(this.document.Name, "Manos");
        }
    }
}
