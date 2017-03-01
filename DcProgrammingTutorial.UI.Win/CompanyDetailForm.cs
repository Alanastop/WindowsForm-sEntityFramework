// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyDetailForm.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The company detail form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.UI.Win
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Media;
    using System.Threading;
    using System.Windows.Forms;

    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.UI.Win.Properties;

    using Lib.Controllers;

    #endregion

    /// <summary>
    /// The company detail form.
    /// </summary>
    public partial class CompanyDetailForm : Form
    {
        /// <summary>
        /// The company.
        /// </summary>
        private readonly Company company;

        /// <summary>
        /// The company controller.
        /// </summary>
        private readonly EntityCompanyController companyController;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDetailForm"/> class.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>       
        public CompanyDetailForm(Company company)
        {
            this.companyController = new EntityCompanyController(new VatCalculation());
            if (company == null)
            {
                throw new ArgumentNullException($@"Company is null");
            }

            this.InitializeComponent();
            this.company = company;

            if (company == null)
            {
                throw new ArgumentNullException($"Company cannot be null");
            }
            else
            {
                this.companyIdValueTextBox.Text = company.Id.ToString();
                this.companyCodeValueTextBox.Text = company.Code;
                this.companyNameValueTextBox.Text = company.Name;
                this.companyTaxIdValueMaskedTextBox.Text = company.TaxId;
                this.companyCreationDateValueTextBox.Text =
                    company.Created.ToString(CultureInfo.CurrentCulture);
                this.company = company;
            }
        }

        /// <summary>
        /// The company detail form_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CompanyDetailFormLoad(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.company.Documents.ToList();
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
            this.company.Name = this.companyNameValueTextBox.Text;
            if (this.company.Name == string.Empty)
            {
                SystemSounds.Beep.Play();
                this.warningLabel.Text = @"You have to put a name first..!!!";
                MessageBox.Show(Resources.DocumentDetailForm_SaveButtonClick_Document_must_have_a_valid_name);
                return;
            }

            this.company.TaxId = this.companyTaxIdValueMaskedTextBox.Text;

            if (this.company.TaxId == string.Empty)
            {
                SystemSounds.Beep.Play();
                this.warningLabel.Text = @"You have to put a Tax Id.";
                MessageBox.Show($@"The Tax Id is null");
                return;
            }

            if (!this.companyController.IsValid(this.company.TaxId))
            {
                SystemSounds.Beep.Play();
                this.warningLabel.Text = @"You have to put a Valid Tax Id.";
                MessageBox.Show($@"You have entered an invalid Tax Id");
                this.companyTaxIdValueMaskedTextBox.Clear();
                return;
            }

            this.company.Code = this.companyCodeValueTextBox.Text;

            try
            {
                this.companyController.CreateOrUpdateEntity(this.company);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    Resources.DocumentDetailForm_SaveButtonClick_Could_not_create_the_document + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show($@"The company name is null" + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }

             this.company.OnCompanyAddedToList();
             this.company.OnCompanyUpdated();
            this.Close();
        }

        /// <summary>
        /// The unlink button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UnlinkButtonClick(object sender, EventArgs e)
        {
            var listOfDocumentsToBeUnlinked = new List<Document>();
            var documentToBeUnlinked = new Document();

            var gridView1 = this.dataGridView1;
            if (gridView1 == null)
            {
                return;
            }

            gridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView1.MultiSelect = true;

            foreach (DataGridViewRow row in gridView1.Rows)
            {
                if (row.Cells["CheckColumn"].ValueType != typeof(bool) || row.Cells["CheckColumn"].Value == null
                    || !(bool)row.Cells["CheckColumn"].Value)
                {
                    continue;
                }
                    
                documentToBeUnlinked = row.DataBoundItem as Document;
                listOfDocumentsToBeUnlinked.Add(documentToBeUnlinked);
            }

            if (documentToBeUnlinked != null)
            {
                foreach (var mydocument in listOfDocumentsToBeUnlinked)
                {
                    this.companyController.Unlink(mydocument.Company, mydocument);
                }
            }

            var companies = this.companyController.GetEntity(this.company.Id);
            this.dataGridView1.DataSource = companies.Documents.ToList();
            this.company.OnCompanyAddedToList();
            this.company.OnCompanyUpdated();
        }

        /// <summary>
        /// The SendEmailButtonClick button.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SendEmailButtonClick(object sender, EventArgs e)
        {
            try
            {
                var sendEmailThread =
                    new Thread(() => this.companyController.SendEmailWithDocuments(this.companyController.ReadCompanyDocumentsToStream, this.company, "anastopoulos_a@datacomm.gr"));
                sendEmailThread.Start();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(@"There is no selected Company or the mail is invalid");
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }
        }

        /// <summary>
        /// The company tax id value masked text box validated.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CompanyTaxIdValueMaskedTextBoxValidated(object sender, EventArgs e)
        {
            this.company.TaxId = this.companyTaxIdValueMaskedTextBox.Text;
            if (this.companyController.IsValid(this.company.TaxId))
            {
                this.warningLabel.Text = string.Empty;
                return;
            }

            SystemSounds.Beep.Play();
            this.warningLabel.Text = @"You have to put a Valid Tax Id.";
            MessageBox.Show($@"You have entered an invalid Tax Id");
            this.companyTaxIdValueMaskedTextBox.Clear();
        }

        /// <summary>
        /// The company name value text box validated.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CompanyNameValueTextBoxValidated(object sender, EventArgs e)
        {
            if (this.companyNameValueTextBox.Text == string.Empty)
            {
                SystemSounds.Beep.Play();
                this.warningLabel.Text = @"You have to put a name first..!!!";
                MessageBox.Show(Resources.DocumentDetailForm_SaveButtonClick_Document_must_have_a_valid_name);
            }
            else
            {
                this.warningLabel.Text = string.Empty;
            }
        }
    }
}