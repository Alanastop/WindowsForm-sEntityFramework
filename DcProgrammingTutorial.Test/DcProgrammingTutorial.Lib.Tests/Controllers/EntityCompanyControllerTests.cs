// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityCompanyControllerTests.cs" company="">
//   
// </copyright>
// <summary>
//   The entity company controller tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Tests.Controllers
{
    #region

    using System;
    using System.Net.Mail;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    using NUnit.Framework;

    #endregion

    /// <summary>
    /// The entity company controller tests.
    /// </summary>
    class EntityCompanyControllerTests
    {
        /// <summary>
        /// The company.
        /// </summary>
        private Company company;

        /// <summary>
        /// The company controller.
        /// </summary>
        private EntityCompanyController companyController;

        /// <summary>
        /// The clear company.
        /// </summary>
        [TearDown]
        public void ClearCompany()
        {
            this.companyController.DeleteEntity(this.company);
        }

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="vat">
        /// The vat.
        /// </param>
        [TestCase("144966262")]
        public void IsValid(string vat)
        {
            this.companyController = new EntityCompanyController(new VatCalculation());
            var temp = this.companyController.IsValid(vat);
            Assert.AreEqual(true, temp);
        }

        /// <summary>
        /// The is valid not.
        /// </summary>
        /// <param name="vat">
        /// The vat.
        /// </param>
        [TestCase("123456789")]
        [TestCase("12345678")]
        [TestCase("1234567890")]
        [TestCase("abcdefghi")]
        public void IsValidNot(string vat)
        {
            this.companyController = new EntityCompanyController(new VatCalculation());
            var temp = this.companyController.IsValid(vat);
            Assert.AreEqual(false, temp);
        }

        /// <summary>
        /// The search companies by tax id.
        /// </summary>
        /// <param name="vat">
        /// The vat.
        /// </param>
        [TestCase("094222211")]
        public void SearchCompaniesByTaxId(string vat)
        {
            this.companyController = new EntityCompanyController(new VatCalculation());
            var companyList = this.companyController.SearchCompaniesByTaxId(vat);
            foreach (var company in companyList)
            {
                Assert.AreEqual(company.TaxId, vat);
            }
        }

        /// <summary>
        /// The search companies by tax id false.
        /// </summary>
        /// <param name="vat">
        /// The vat.
        /// </param>
        [TestCase("ghhffhg")]
        public void SearchCompaniesByTaxIdFalse(string vat)
        {
            this.companyController = new EntityCompanyController(new VatCalculation());
            var companyList = this.companyController.SearchCompaniesByTaxId(vat);
            Assert.AreEqual(companyList.Count, 0);
        }

        /// <summary>
        /// The search companies by tax id null.
        /// </summary>
        [Test]
        public void SearchCompaniesByTaxIdNull()
        {
            string vat = null;
            this.companyController = new EntityCompanyController(new VatCalculation());
            var companyList = this.companyController.SearchCompaniesByTaxId(vat);
            Assert.AreEqual(companyList, string.Empty);
        }

        /// <summary>
        /// The search companies by tax id short.
        /// </summary>
        /// <param name="vat">
        /// The vat.
        /// </param>
        [TestCase("09422")]
        public void SearchCompaniesByTaxIdShort(string vat)
        {
            this.companyController = new EntityCompanyController(new VatCalculation());
            var companyList = this.companyController.SearchCompaniesByTaxId(vat);
            foreach (var company in companyList)
            {
                Assert.AreEqual(company.TaxId.Contains("09422"), true);
            }
        }

        [Test]
        public void EmailTestEmpty()
        {
            var exp =
                Assert.Throws<ArgumentNullException>(() => this.companyController.SendEmailWithDocuments(this.companyController.ReadCompanyDocumentsToStream , this.company , "" , ""));
            Assert.That(exp.Message , Is.EqualTo("Value cannot be null."));
        }

        [Test]
        public void EmailTestWrong()
        {
            var exp =
                Assert.Throws<SmtpFailedRecipientException>(() => this.companyController.SendEmailWithDocuments(this.companyController.ReadCompanyDocumentsToStream , this.company , "dad@dd.com" , "1"));
            Assert.That(exp.Message , Is.EqualTo("Mailbox unavailable. The server response was: 5.7.1 Unable to relay"));
        }

        [Test]
        public void EmailTestWrongFormat()
        {
            var exp =
                Assert.Throws<FormatException>(() => this.companyController.SendEmailWithDocuments(this.companyController.ReadCompanyDocumentsToStream , this.company , "dad@.,k.l,.ergcvjyfyu" , "1"));
            Assert.That(exp.Message , Is.EqualTo("An invalid character was found in the mail header: '.'."));
        }

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.company = new Company
                               {
                                   Name = "TestCompany",
                                   TaxId = "094222211",
                                   Code = string.Empty,
                                   Created = DateTime.Now,
                                   Active = false
                               };
            this.companyController = new EntityCompanyController(new VatCalculation());
            this.companyController.CreateOrUpdateEntity(this.company);
        }
    }
}