// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentControllerTests.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The document controller test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Tests.Controllers
{
    #region

    using System;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The document controller test.
    /// </summary>
    public class DocumentControllerTests
    {
        /// <summary>
        /// The document.
        /// </summary>
        private Document document;

        /// <summary>
        /// The document controller.
        /// </summary>
        private IDocumentController documentController;

        /// <summary>
        /// The document entity repository.
        /// </summary>
        private DocumentEntityRepository documentEntityRepository;

        /// <summary>
        /// The average balance.
        /// </summary>
        [Test]
        public void AverageBalance()
        {
            this.documentController = new DocumentController();
            var list = this.documentEntityRepository.ReadAllList();
            var test = this.documentController.CalculateAverageBalance(list);
            Assert.AreEqual(test, 100);
        }

        /// <summary>
        /// The average balance v 2.
        /// </summary>
        [Test]
        public void AverageBalanceV2()
        {
            var list = this.documentEntityRepository.ReadAllList();
            var test = this.documentController.CalculateAverageBalance(list);
            Assert.AreEqual(test, 100);
        }

        /// <summary>
        /// The calculate tax.
        /// </summary>
        [Test]
        public void Calculatetax()
        {
            this.documentController = new DocumentController();
            var test = this.documentController.CalculateTax(this.document);
            Assert.AreEqual(test, 4);
        }

        /// <summary>
        /// The calculate tax v 2.
        /// </summary>
        [Test]
        public void CalculatetaxV2()
        {
            var test = this.documentController.CalculateTax(this.document);
            Assert.AreEqual(test, 4);
        }

        /// <summary>
        /// The setup tests.
        /// </summary>
        [SetUp]
        public void SetupTests()
        {
            this.document = new Document { Name = "mitsos", Balance = 10 };
            this.documentController = new DocumentControllerV2();
            this.documentEntityRepository = new DocumentEntityRepository();
        }
    }
}