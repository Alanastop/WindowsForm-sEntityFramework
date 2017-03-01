// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentDetailForm.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The form 2.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.UI.Win
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.UI.Win.Properties;

    #endregion

    /// <summary>
    /// The form 2.
    /// </summary>
    public partial class DocumentDetailForm : Form
    {
        /// <summary>
        /// The company controller.
        /// </summary>
        private readonly EntityCompanyController companyController;

        /// <summary>
        /// The temp 1.
        /// </summary>
        private readonly Document document;

        /// <summary>
        /// The my controller.
        /// </summary>
        private readonly DocumentController documentController;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentDetailForm"/> class.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        public DocumentDetailForm(Document document)
        {
            
            if (document == null)
            {
                throw new ArgumentNullException($"Our list is empty");
            }

            this.documentController = new EntityDocumentController();

            this.companyController = new EntityCompanyController(new VatCalculation());
            this.InitializeComponent();
            this.document = document;
            this.document.DocumentAddedToList -= this.CalculateTaxEvent;
            this.document.DocumentAddedToList += this.CalculateTaxEvent;
            try
            {
                var list = this.companyController.Repository.ReadAllList();
                this.comboBox1.DataSource = list;
                list.Insert(0, new Company());
                this.comboBox1.DisplayMember = "Name";
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    Resources.DocumentDetailForm_DocumentDetailForm_Could_not_read_the_companies_from_database
                    + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }

            if (document == null)
            {
                throw new ArgumentNullException($"Document cannot be null");
            }

            if (document.Id == 0)
            {
                this.comboBox1.BackColor = Color.Red;
            }
            else
            {
                if (document.Company == null)
                {
                    this.comboBox1.SelectedIndex = 0;
                }
                else
                {
                    this.comboBox1.SelectedItem = "Name";
                    this.comboBox1.Text = this.document.Company?.Name ?? string.Empty;
                }
                
                this.documentIdValueTextBox.Text = document.Id.ToString();
                this.documentCodeValueTextBox.Text = document.Code;
                this.documentNameValueTextBox.Text = document.Name;
                this.documentBalanceValueTextBox.Text = document.Balance.ToString(CultureInfo.CurrentCulture);
                this.documentCreationDateValueTextBox.Text = document.Created.ToString(CultureInfo.CurrentCulture);
                this.document = document;
            }
        }

        /// <summary>
        /// The button tax evaluation_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CalculateTaxButtonClick(object sender, EventArgs e)
        {
            this.taxValueTextBox.Text =
                this.documentController.CalculateTax(this.document).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The calculate tax event.
        /// </summary>
        private void CalculateTaxEvent()
        {
            this.taxValueTextBox.Text =
                this.documentController.CalculateTax(this.document).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The close form 2_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CloseDocumentDetailFormButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The link document to company button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void LinkDocumentToCompanyButtonClick(object sender, EventArgs e)
        {
            this.document.Company = this.companyController.Link(this.comboBox1.SelectedItem as Company);
        }

        /// <summary>
        /// The save button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SaveButtonClick(object sender, EventArgs e)
        {
            this.document.Name = this.documentNameValueTextBox.Text;

            if (this.document.Name == string.Empty)
            {
                this.warningLabel.Text = $@"You have to give a valid name first!!";
                MessageBox.Show(Resources.DocumentDetailForm_SaveButtonClick_Document_must_have_a_valid_name);
                return;
            }

            this.document.Code = this.documentCodeValueTextBox.Text;
            this.document.Balance = (double)this.documentBalanceValueTextBox.Value;
        
            try
            {
                this.documentController.CreateOrUpdateEntity(this.document);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    Resources.DocumentDetailForm_SaveButtonClick_Could_not_create_the_document + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show($@"The document name is null" + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }

            this.document.OnDocumentAddedToList();
            this.document.OnDocumentUpdated();
            this.Close();
        }
    }
}