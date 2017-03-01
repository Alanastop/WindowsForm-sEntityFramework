// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainListForm.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.UI.Win
{
    #region

    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.UI.Win.Properties;

    #endregion

    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class MainListForm : Form
    {
        /// <summary>
        /// The document name empty message.
        /// </summary>
        private const string DocumentNullMessage = "Document cannot be empty!";

        /// <summary>
        /// The entity company controller.
        /// </summary>
        private EntityCompanyController entityCompanyController;

        /// <summary>
        /// The document controller.
        /// </summary>
        private DocumentController entityDocumentController;

        /// <summary>
        /// The entity type.
        /// </summary>
        private Type entityType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainListForm"/> class.
        /// </summary>
        public MainListForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The button average tax_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CalculateAverageBalanceButtonClick(object sender, EventArgs e)
        {
            try
            {
                var averageBalance =
                    this.entityDocumentController.CalculateAverageBalance(
                        this.entityDocumentController.RefreshEntities());
                this.averageBalanceValueTextBox.Text = averageBalance.ToString(CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException exp)
            {
                MessageBox.Show(exp.Message);
                var time = DateTime.Now;
                Logger.AddLog(DocumentNullMessage, ErrorTypes.Error, time);
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
            var currentDocument = this.dataGridView.CurrentRow?.DataBoundItem as Document;

            try
            {
                var tax = this.entityDocumentController.CalculateTax(currentDocument);
                this.taxValueTextBox.Text = tax.ToString(CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
                var time = DateTime.Now;
                Logger.AddLog(DocumentNullMessage, ErrorTypes.Error, time);
            }
        }

        /// <summary>
        /// The company refresh grid.
        /// </summary>
        /// <param name="myCompanies">
        /// The my companies.
        /// </param>
        private void CompanyRefreshGrid(Company myCompanies)
        {
            try
            {
                this.dataGridView.DataSource = this.entityCompanyController.RefreshEntities();
                myCompanies.CompanyUpdated -= this.CompanyRefreshGrid;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(Resources.MainListForm_RefreshGrid_Could_not_refresh_the_list + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Warning, DateTime.Now);
            }
        }

        /// <summary>
        /// The create button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CreateButtonClick(object sender, EventArgs e)
        {
            if (this.entityType == typeof(Company))
            {
                var currentCompany = new Company();
                currentCompany.CompanyUpdated += this.CompanyRefreshGrid;
                var companyDetailForm = new CompanyDetailForm(currentCompany);
                companyDetailForm.Show();
            }

            if (this.entityType == typeof(Document))
            {
                var currentDocument = new Document();
                currentDocument.DocumentUpdated += this.DocumentRefreshGrid;
                currentDocument.DocumentAddedToList -= this.DocumentAddedToListEvent;
                currentDocument.DocumentAddedToList += this.DocumentAddedToListEvent;
                var documentDetailForm = new DocumentDetailForm(currentDocument);
                documentDetailForm.Show();
            }
        }

        /// <summary>
        /// The delete button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            this.averageBalanceValueTextBox.Clear();

            try
            {
                if (this.dataGridView.RowCount == 0)
                {
                    MessageBox.Show(Resources.MainListForm_DeleteDocumentButtonClick_Our_list_is_empty);
                    return;
                }

                var documentToBeDeleted = this.dataGridView?.CurrentRow?.DataBoundItem as Document;
                if (documentToBeDeleted != null)
                {
                    this.entityDocumentController.DeleteEntity(documentToBeDeleted);
                    return;
                }

                var companyToBeDeleted = this.dataGridView?.CurrentRow?.DataBoundItem as Company;
                if (companyToBeDeleted != null)
                {
                    this.entityCompanyController.DeleteEntity(companyToBeDeleted);
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    Resources.MainListForm_DeleteDocumentButtonClick_The_selected_document_couldn_t_be_deleted
                    + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show($@"The document is already deleted or you cant delete it {exception.Message}");
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }
            finally
            {
                this.RefreshDatasource();
            }
        }

        /// <summary>
        /// The document added to list.
        /// </summary>
        private void DocumentAddedToListEvent()
        {
            try
            {
                var list = new BindingList<Document>();
                foreach (var document1 in this.entityDocumentController.RefreshEntities())
                {
                    list.Add(document1);
                }

                this.averageBalanceValueTextBox.Text =
                    this.entityDocumentController.CalculateAverageBalance(list).ToString(CultureInfo.InvariantCulture);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    Resources.MainListForm_DocumentAddedToListEvent_Could_not_calculate_the_balance + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Warning, DateTime.Now);
            }
        }

        /// <summary>
        /// The data grid view 1_ cell mouse double click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DocumentDataGridViewCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.taxValueTextBox.Clear();

            try
            {
                var currentDocument = this.dataGridView?.CurrentRow?.DataBoundItem as Document;
                if (currentDocument != null)
                {
                    currentDocument = this.entityDocumentController.GetEntity(currentDocument.Id);
                    currentDocument.DocumentAddedToList -= this.DocumentAddedToListEvent;
                    currentDocument.DocumentAddedToList += this.DocumentAddedToListEvent;
                    currentDocument.DocumentUpdated += this.DocumentRefreshGrid;

                    var detailForm = new DocumentDetailForm(currentDocument);
                    detailForm.Show();
                    return;
                }

                var currentCompany = this.dataGridView?.CurrentRow?.DataBoundItem as Company;
                if (currentCompany != null)
                {
                    currentCompany = this.entityCompanyController.GetEntity(currentCompany.Id);
                    currentCompany.CompanyUpdated += this.CompanyRefreshGrid;

                    var companydetailForm = new CompanyDetailForm(currentCompany);
                    companydetailForm.Show();
                }
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                var time = DateTime.Now;
                Logger.AddLog(exception.Message, ErrorTypes.Error, time);
            }
        }

        /// <summary>
        /// The refresh grid.
        /// </summary>
        /// <param name="myDocuments">
        /// Refreshes the Grid
        /// </param>
        private void DocumentRefreshGrid(Document myDocuments)
        {
            try
            {
                this.RefreshDatasource();
                myDocuments.DocumentUpdated -= this.DocumentRefreshGrid;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(Resources.MainListForm_RefreshGrid_Could_not_refresh_the_list + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Warning, DateTime.Now);
            }
        }

        /// <summary>
        /// The entities combo box selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void EntitiesComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            this.entityDocumentController = new EntityDocumentController();
            if (this.entitiesComboBox.SelectedIndex == 0)
            {
                this.createButton.Text = @"Create Company";
                this.deleteButton.Text = @"Delete Company";
                this.calculateAverageBalanceButton.Enabled = false;
                this.calculateTaxButton.Enabled = false;
                this.averageBalanceValueTextBox.Visible = false;
                this.taxValueTextBox.Visible = false;
                this.entityType = typeof(Company);
            }

            if (this.entitiesComboBox.SelectedIndex == 1)
            {
                this.createButton.Text = @"Create Document";
                this.deleteButton.Text = @"Delete Document";
                this.calculateAverageBalanceButton.Enabled = true;
                this.calculateTaxButton.Enabled = true;
                this.averageBalanceValueTextBox.Visible = true;
                this.taxValueTextBox.Visible = true;
                this.entityType = typeof(Document);
            }

            this.RefreshDatasource();
        }

        /// <summary>
        /// The exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                this.entityDocumentController.RefreshEntities()
                    .ToList()
                    .ForEach(newDocument => newDocument.DocumentAddedToList -= this.DocumentAddedToListEvent);
            }
            catch (SqlException exception)
            {
                Logger.AddLog(exception.Message, ErrorTypes.Warning, DateTime.Now);
            }

            this.Close();
        }

        /// <summary>
        /// The form 1_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainListFormLoad(object sender, EventArgs e)
        {
            this.entityCompanyController = new EntityCompanyController(new VatCalculation());
            this.entitiesComboBox.SelectedIndex = 1;
            try
            {
                this.entityType = typeof(Document);
                this.RefreshDatasource();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    Resources.MainListForm_MainListFormLoad_Could_not_read_from_database + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Warning, DateTime.Now);
            }
        }

        /// <summary>
        /// The refresh click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RefreshClick(object sender, EventArgs e)
        {
            this.RefreshDatasource();
        }

        /// <summary>
        /// The Refresh data source method.
        /// </summary>
        private void RefreshDatasource()
        {
            try
            {
                if (this.entityType == typeof(Document))
                {
                    this.dataGridView.DataSource = this.entityDocumentController.RefreshEntities();
                }

                if (this.entityType == typeof(Company))
                {
                    this.dataGridView.DataSource = this.entityCompanyController.RefreshEntities();
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(
                    Resources.MainListForm_MainListFormLoad_Could_not_read_from_database + exception.Message);
                Logger.AddLog(exception.Message, ErrorTypes.Error, DateTime.Now);
            }
        }
    }
}