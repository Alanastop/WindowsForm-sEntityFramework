// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICompanyController.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The CompanyController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers.Interface
{
    using System;
    using System.IO;

    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    /// <summary>
    /// The CompanyController interface.
    /// </summary>
    public interface ICompanyController
    {
        /// <summary>
        /// The un link one or many documents from company.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Unlink(int id);

        /// <summary>
        /// The unlink.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        void Unlink(Company company, Document document);

        /// <summary>
        /// The link.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        Company Link(Company company);

        /// <summary>
        /// The send email with documents.
        /// </summary>
        /// <param name="func">
        /// The function.
        /// </param>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        void SendEmailWithDocuments(Func<Company, MemoryStream> func, Company company, string email, string password);

        /// <summary>
        /// The send email with documents.
        /// </summary>
        /// <param name="func">
        /// The function.
        /// </param>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        void SendEmailWithDocuments(Func<Company, MemoryStream> func, Company company, string email);

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="calculateFunc">
        /// The calculate function.
        /// </param>
        /// <param name="toCalculate">
        /// The to calculate.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsValid(string toCalculate);

        IIsValidCalculations IsValidCalculations { get; set; }
    }
}