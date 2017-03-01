// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompaniesPropertiesForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The companies properties form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net.Mail;
    using System.Web.UI;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Controllers.Interface;
    using DcProgrammingTutorial.Lib.DBContext;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    using DevExpress.Web;

    #endregion

    /// <summary>
    /// The companies properties form.
    /// </summary>
    public partial class CompaniesPropertiesForm : Page
    {
        /// <summary>
        /// The close script.
        /// </summary>
        private const string CloseScript = @"<script language='javascript'> PropertiesFormCloseFunction() </script>";

        /// <summary>
        /// The java script script.
        /// </summary>
        private const string SubmitScript = @"<script language='javascript'> PropertiesFormSubmitFunction() </script>";

        /// <summary>
        /// The company.
        /// </summary>
        private Company company;

        /// <summary>
        /// The entity company controller.
        /// </summary>
        private EntityCompanyController entityCompanyController;

        /// <summary>
        /// The entity document controller.
        /// </summary>
        private IEntityController<Document> entityDocumentController;

        /// <summary>
        /// The documents grid view html row prepared.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DocumentsGridViewHtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("Company") != null)
            {
                e.Row.Font.Bold = true;
            }
        }

        /// <summary>
        /// The page_ init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            var companyId = Convert.ToInt32(this.Request.QueryString["companyId"]);

            List<Document> documentList;
            if (!this.Page.IsPostBack)
            {
                if (companyId == 0)
                {
                    this.company = new Company();

                    this.activeDirectoryPassword.Visible = false;
                    this.receiverEmailTextBox.Visible = false;
                    this.sendEmailButton.Visible = false;
                }
                else
                {
                    this.entityCompanyController = new EntityCompanyController(new VatCalculation());
                    this.company = this.entityCompanyController.GetEntity(companyId);
                }

                this.Session["company"] = this.company;

                this.nameTextBox.Text = this.company.Name;
                this.taxIdTextBox.Text = this.company.TaxId;
                this.codeTextBox.Text = this.company.Code;

                this.createdTextBox.Text = this.company.Created.ToString(CultureInfo.InvariantCulture);

                this.createdByTextBox.Text = this.company.CreatedBy;
                this.updatedTextBox.Text = this.company.Updated.ToString();
                this.updatedByTextBox.Text = this.company.UpdatedBy;
                this.entityDocumentController = new EntityDocumentController();

                documentList =
                    this.entityDocumentController.Repository.ReadAllQuery(new DataBaseContext())
                        .Where(x => (x.Company == null) || (x.Company.Id == this.company.Id))
                        .OrderBy(x => x.Company == null)
                        .ToList();
            }
            else
            {
                documentList = this.Session["documents"] as List<Document>;
            }

            this.Session["documents"] = documentList;
            this.DocumentsGridView.DataSource = documentList;
            this.DocumentsGridView.DataBind();
            this.DocumentsGridView.Width = 415;
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ClientScript.RegisterStartupScript(typeof(Page), "CLOSEACTIONS", CloseScript, false);

                if (!this.Page.IsPostBack)
                {
                    var documentList = this.Session["documents"] as List<Document>;

                    Debug.Assert(documentList != null, "documentList != null");
                    foreach (var document in documentList)
                    {
                        if (document.Company != null)
                        {
                            this.DocumentsGridView.Selection.SelectRowByKey(document.Id);
                        }
                    }
                }
                else
                {
                    this.company = this.Session["company"] as Company;
                }
            }
            catch (SqlException ex)
            {
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }
        }

        /// <summary>
        /// The save or update method.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
             Justification = "Reviewed. Suppression is OK here.")]
        protected void propertiesbutton_OnClick(object sender, EventArgs e)
        {
            this.entityCompanyController = new EntityCompanyController(new VatCalculation());
            this.entityDocumentController = new EntityDocumentController();
            try
            {
                this.divErrorMessage.InnerHtml = string.Empty;
                var localCompany = this.Session["company"] as Company;

                if (localCompany == null)
                {
                    return;
                }

                localCompany.Code = this.codeTextBox.Text;
                if (string.IsNullOrEmpty(this.taxIdTextBox.Text))
                {
                    this.divErrorMessage.InnerHtml = "Please enter a Tax Id";
                    return;
                }

                if (string.IsNullOrEmpty(this.nameTextBox.Text))
                {
                    this.divErrorMessage.InnerHtml = "Please add a name first";
                    return;
                }

                localCompany.Name = this.nameTextBox.Text;
                localCompany.TaxId = this.taxIdTextBox.Text;
                this.entityCompanyController.CreateOrUpdateEntity(localCompany);
                this.ClientScript.RegisterStartupScript(typeof(Page), "CLOSEWINDOW", SubmitScript, false);

                var selectedFieldValues = this.DocumentsGridView.GetSelectedFieldValues(this.DocumentsGridView.KeyFieldName);
                var documentsGridViewList = this.Session["documents"] as List<Document>;

                for (var i = 0; i < this.DocumentsGridView.VisibleRowCount; i++)
                {
                    if (documentsGridViewList != null && !selectedFieldValues.Contains(documentsGridViewList[i].Id))
                    {
                        this.entityCompanyController.Unlink(documentsGridViewList[i].Id);
                    }
                    else
                    {
                        if (documentsGridViewList != null)
                        {
                            documentsGridViewList[i].Company = localCompany;
                            this.entityDocumentController.CreateOrUpdateEntity(documentsGridViewList[i]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }
        }

        /// <summary>
        /// The send email button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected async void SendEmailButtonOnClick(object sender, EventArgs e)
        {
            var localCompany = this.Session["company"] as Company;
            this.entityCompanyController = new EntityCompanyController(new VatCalculation());

            try
            {
                await
                    this.entityCompanyController.SendEmailWithDocumentsAsync(
                        this.entityCompanyController.ReadCompanyDocumentsToStream,
                        localCompany,
                        this.receiverEmailTextBox.Text,
                        this.activeDirectoryPassword.Text);

                this.receiverEmailTextBox.Text = string.Empty;
            }
            catch (Exception ex)
                when (
                    ex is SmtpFailedRecipientException || ex is SmtpException || ex is ArgumentNullException
                    || ex is FormatException)
            {
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }
        }

        /// <summary>
        /// The tax id text box_ on text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
             Justification = "Reviewed. Suppression is OK here.")]
        protected void taxIdTextBox_OnTextChanged(object sender, EventArgs e)
        {
            this.divErrorMessage.InnerHtml = string.Empty;
            var localCompany = this.Session["company"] as Company;
            if (localCompany != null)
            {
                localCompany.TaxId = this.taxIdTextBox.Text;
                this.entityCompanyController = new EntityCompanyController(new VatCalculation());
                var isValid = this.entityCompanyController.IsValid(localCompany.TaxId);
                if (!isValid)
                {
                    this.divErrorMessage.InnerHtml = "Please enter a valid Tax Id";
                }
            }
        }
    }
}