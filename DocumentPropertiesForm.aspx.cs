// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentPropertiesForm.aspx.cs" company="data Communication">
//   DC Tutorial
// </copyright>
// <summary>
//   The document properties form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    #endregion

    /// <summary>
    /// The document properties form.
    /// </summary>
    public partial class DocumentPropertiesForm : Page
    {
        /// <summary>
        /// The java script script.
        /// </summary>
        private const string SubmitScript = @"<script language='javascript'> PropertiesFormSubmitFunction() </script>";

        /// <summary>
        /// The close script.
        /// </summary>
        private const string CloseScript = @"<script language='javascript'> PropertiesFormCloseFunction() </script>";

        /// <summary>
        /// The document.
        /// </summary>
        private Document document;

        /// <summary>
        /// The document id.
        /// </summary>
        private int documentId;

        /// <summary>
        /// The entity company controller.
        /// </summary>
        private EntityCompanyController entityCompanyController;

        /// <summary>
        /// The entity document controller.
        /// </summary>
        private EntityDocumentController entityDocumentController;

        /// <summary>
        /// The balance text box_ on text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
             Justification = "Reviewed. Suppression is OK here.")]
        protected void balanceTextBox_OnTextChanged(object sender, EventArgs e)
        {
            var localDocument = new Document();
            this.entityDocumentController = new EntityDocumentController();

            localDocument.Balance = string.IsNullOrEmpty(this.balanceTextBox.Text)
                                        ? 0
                                        : Convert.ToDouble(this.balanceTextBox.Text, CultureInfo.InvariantCulture);
            this.taxTextBox.Text = Convert.ToString(
                this.entityDocumentController.CalculateTax(localDocument),
                CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The balance text box on load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BalanceTextBoxOnLoad(object sender, EventArgs e)
        {
            var localDocument = new Document();
            this.entityDocumentController = new EntityDocumentController();
            localDocument.Balance = string.IsNullOrEmpty(this.balanceTextBox.Text)
                                        ? 0
                                        : Convert.ToDouble(this.balanceTextBox.Text, CultureInfo.InvariantCulture);
            this.taxTextBox.Text = Convert.ToString(
                this.entityDocumentController.CalculateTax(localDocument),
                CultureInfo.InvariantCulture);
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
            this.ClientScript.RegisterStartupScript(typeof(Page), "CLOSEACTIONS", CloseScript, false);
            this.documentId = Convert.ToInt32(this.Request.QueryString["documentId"]);

            if (!this.Page.IsPostBack)
            {
                this.entityCompanyController = new EntityCompanyController(new VatCalculation());

                var list = this.entityCompanyController.RefreshEntities();
                list.Insert(0, new Company());
                this.Session["Companies"] = list;
                this.companyNameDropDown.DataSource = this.Session["Companies"];
                this.companyNameDropDown.DataTextField = "Name";
                this.companyNameDropDown.DataValueField = "Id";
                this.companyNameDropDown.DataBind();

                this.entityDocumentController = new EntityDocumentController();

                if (this.documentId == 0)
                {
                    this.document = new Document();
                }
                else
                {
                    this.Session["document"] = this.entityDocumentController.GetEntity(this.documentId);
                    this.document = (Document)this.Session["document"];
                }

                this.nameTextBox.Text = this.document.Name;
                this.codeTextBox.Text = this.document.Code;
                this.balanceTextBox.Text = this.document.Balance.ToString(CultureInfo.InvariantCulture);
                this.createdTextBox.Text = this.document.Created.ToString(CultureInfo.InvariantCulture);
                this.companyNameDropDown.SelectedValue = this.document.CompanyName;
                this.createdByTextBox.Text = this.document.CreatedBy;
                this.updatedTextBox.Text = this.document.Updated.ToString();
                this.updatedByTextBox.Text = this.document.UpdatedBy;
                if (this.document.Company != null)
                {
                    var item = this.companyNameDropDown.Items.FindByValue(this.document.Company.Id.ToString());
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
            else
            {
                var selectedItemValue = this.companyNameDropDown.SelectedItem.Value;
                this.companyNameDropDown.DataSource = this.Session["Companies"];
                this.companyNameDropDown.DataTextField = "Name";
                this.companyNameDropDown.DataValueField = "Id";
                this.companyNameDropDown.DataBind();
                var item = this.companyNameDropDown.Items.FindByValue(selectedItemValue);
                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }

        /// <summary>
        /// The save or update button.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void PropertiesButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                var localDocument = this.Session["document"] as Document;
                var companyList = this.companyNameDropDown.DataSource as List<Company>;

                if (this.documentId == 0)
                {
                    localDocument = new Document();
                }

                if (localDocument != null)
                {
                    localDocument.Name = this.nameTextBox.Text;
                    localDocument.Code = this.codeTextBox.Text;
                    localDocument.Balance = string.IsNullOrEmpty(this.balanceTextBox.Text)
                                                ? 0
                                                : Convert.ToDouble(this.balanceTextBox.Text, CultureInfo.InvariantCulture);

                    if (companyList != null)
                    {
                        var companyTemp =
                            companyList.SingleOrDefault(x => x.Id == Convert.ToInt32(this.companyNameDropDown.SelectedItem.Value));
                        localDocument.Company = companyTemp?.Id == 0 ? null : companyTemp;
                    }

                    if (string.IsNullOrEmpty(this.nameTextBox.Text))
                    {
                        this.divErrorMessage.InnerHtml = "Please add a name first";
                        return;
                    }

                    this.entityDocumentController = new EntityDocumentController();
                    this.entityDocumentController.CreateOrUpdateEntity(localDocument);
                }

                this.ClientScript.RegisterStartupScript(typeof(Page), "SUBMITACTIONS", SubmitScript, false);
            }
            catch (SqlException ex)
            {
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }
        }
    }
}