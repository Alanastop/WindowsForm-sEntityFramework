// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityCompanyController.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The entity company controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;

    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Repositories;
    using DcProgrammingTutorial.Lib.Repositories.Interface;

    #endregion

    /// <summary>
    /// The entity company controller.
    /// </summary>
    public class EntityCompanyController : ICompanyController, IEntityController<Company>
    {
        /// <summary>
        /// The read company documents to stream.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate",
             Justification = "Reviewed. Suppression is OK here.")]
        public Func<Company, MemoryStream> ReadCompanyDocumentsToStream = (company) =>
            {
                if (company == null)
                {
                    throw new ArgumentNullException();
                }

                var count = 0;
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"The Company {company.Name} has {company.Documents.Count} Documents");
                stringBuilder.AppendLine($"Name;{company.Name}");
                stringBuilder.AppendLine($"Code;{company.Code}");
                stringBuilder.AppendLine($"Tax Id;{company.TaxId}");
                stringBuilder.AppendLine($"Created;{company.Created}");
                stringBuilder.AppendLine($"Created By;{company.CreatedBy}");
                stringBuilder.AppendLine($"Updated;{company.Updated}");
                stringBuilder.AppendLine($"Updated By;{company.UpdatedBy}");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(";Id;Name;Code;Balance;Created;Created By;Updated;Updated By");

                foreach (var document in company.Documents)
                {
                    stringBuilder.AppendLine(
                        $"{count};{document.Id};{document.Name};{document.Code};{document.Balance};{document.Created};{document.CreatedBy};{document.Updated};{document.UpdatedBy}");
                    count++;
                }

                var windowsEncoding = Encoding.GetEncoding(1253);
                return new MemoryStream(windowsEncoding.GetBytes(stringBuilder.ToString()));
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCompanyController"/> class.
        /// </summary>
        /// <param name="calculations">
        /// The calculations.
        /// </param>
        public EntityCompanyController(IIsValidCalculations calculations)
        {
            this.Repository = new CompanyEntityRepository();
            this.IsValidCalculations = calculations;
        }

        /// <summary>
        /// Gets or sets the is valid calculations interface.
        /// </summary>
        public IIsValidCalculations IsValidCalculations { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Company> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        public Company CreateOrUpdateEntity(Company entity)
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
        /// <exception cref="NotImplementedException">
        /// The Company list is Empty.
        /// </exception>
        public void DeleteEntity(Company entity)
        {
            if (entity.Id > 0)
            {
                this.Repository.Delete(entity.Id, Environment.UserName);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Gets one Company.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        public Company GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="toCalculate">
        /// The to Calculate.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsValid(string toCalculate)
        {
            return this.IsValidCalculations.Calculate(toCalculate);
        }

        /// <summary>
        /// The link.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        public Company Link(Company company)
        {
            return company.Id == 0 ? null : company;
        }

        /// <summary>
        /// Refreshes the companies list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Company}"/>.
        /// </returns>
        public IList<Company> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }

        /// <summary>
        /// The search companies by tax id.
        /// </summary>
        /// <param name="taxId">
        /// The tax id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Company> SearchCompaniesByTaxId(string taxId)
        {
            using (var context = new DataBaseContext())
            {
                return this.Repository.ReadAllQuery(context).Where(x => x.TaxId.Contains(taxId)).ToList();
            }
        }

        /// <summary>
        /// This Method sends email with the selected company and the documents inside.
        /// </summary>
        /// <param name="func">
        /// The function to send email.
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
        public void SendEmailWithDocuments(Func<Company, MemoryStream> func, Company company, string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException();
            }

            var memoryStream = func.Invoke(company);
            var attachment = new Attachment(memoryStream, $"{company.Name}_Documents.csv");
            var mail = new MailMessage(Environment.UserName + "@datacomm.gr", email)
                           {
                               Subject = "Email with Company and documents",
                               IsBodyHtml = true
                           };

            mail.Attachments.Add(attachment);
            mail.Body = $@" Company's {company.Name} properties:  <br /> " + $"Name: &#09 &#09  {company.Name}<br />"
                        + $"Code: &#09 &#09 {company.Code}<br />" + $"Tax Id: &#09 {company.TaxId}<br />"
                        + $"Created: &#09 {company.Created}<br />" + $"Created By: &#09 {company.CreatedBy}<br />"
                        + $"Updated: &#09 {company.Updated}<br />" + $"Updated By: &#09 {company.UpdatedBy}";
            var smtp = new SmtpClient
                           {
                               Host = "webmail.datacomm.gr",
                               Credentials = new NetworkCredential(Environment.UserName + "@datacomm.gr", password),
                               Port = 25,
                               EnableSsl = true
                           };
            smtp.Send(mail);
        }

        /// <summary>
        /// The send email with documents.
        /// </summary>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public void SendEmailWithDocuments(Func<Company, MemoryStream> func, Company company, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException();
            }

            try
            {
                var memoryStream = func.Invoke(company);
                var attachment = new Attachment(memoryStream, $"{company.Name}_Documents.csv");
                var mail = new MailMessage("andreadakis_k@datacomm.gr", email)
                               {
                                   Subject = "Email with Company and documents",
                                   IsBodyHtml = true
                               };

                mail.Attachments.Add(attachment);
                var smtp = new SmtpClient
                               {
                                   Host = "webmail.datacomm.gr",
                                   Credentials = new NetworkCredential("andreadakis_k@datacomm.gr", "data"),
                                   Port = 25,
                                   EnableSsl = true
                               };
                smtp.Send(mail);
            }
            catch (SmtpFailedRecipientException ex)
            {
                Trace.TraceInformation("Property: {0} ", ex.StackTrace);
            }
        }

        /// <summary>
        /// The send email with documents async.
        /// </summary>
        /// <param name="func">
        /// The func.
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
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task SendEmailWithDocumentsAsync(Func<Company, MemoryStream> func, Company company, string email, string password)
        {
            this.SendEmailWithDocuments(func, company, email, password);
        }

        /// <summary>
        /// The un link one or many documents from company.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Unlink(int id)
        {
            var entityRepository = this.Repository as CompanyEntityRepository;
            entityRepository?.Unlink(id);
        }

        /// <summary>
        /// The unlink.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        public void Unlink(Company company, Document document)
        {
            var entityRepository = this.Repository as CompanyEntityRepository;
            entityRepository?.Unlink(company, document);
        }
    }
}