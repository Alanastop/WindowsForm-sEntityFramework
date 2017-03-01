// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompaniesWebForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The companies web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Web.UI.WebControls;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Helpers;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    using DevExpress.Export;
    using DevExpress.Web;
    using DevExpress.XtraPrinting;

    using Page = System.Web.UI.Page;

    #endregion

    /// <summary>
    /// The companies web form.
    /// </summary>
    public partial class CompaniesWebForm : Page
    {
        /// <summary>
        /// The function call.
        /// </summary>
        protected readonly string FuncCall =
            @"<script language='javascript'>window.location.href = window.location.href;</script>";

        /// <summary>
        /// The entity company controller.
        /// </summary>
        private EntityCompanyController entityCompanyController;

        /// <summary>
        /// The entity profile controller.
        /// </summary>
        private EntityProfileController entityProfileController;

        /// <summary>
        /// The company grid view client layout.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void CompanyGridViewClientLayout(object sender, ASPxClientLayoutArgs e)
        {
            this.entityProfileController = new EntityProfileController();
            var user = this.Session["user"] as User;
            if (user != null)
            {
                try
                {
                    var currentProfile = this.entityProfileController.GetProfile(
                                             user.Id,
                                             "CompanyGridView",
                                             ProfileType.GridView)
                                         ?? new Profile
                                                {
                                                    UserId = user.Id,
                                                    ProfileType = ProfileType.GridView,
                                                    ViewId = "CompanyGridView"
                                                };

                    currentProfile.Customization = this.CompanyGridView.SaveClientLayout();
                    this.entityProfileController.CreateOrUpdateEntity(currentProfile);
                }
                catch (SqlException ex)
                {
                    Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
                }
            }
        }

        /// <summary>
        /// The delete company_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteCompanyClick(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.CompanyGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = @"There are no companies to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.CompanyGridView.GetSelectedFieldValues(
                    this.CompanyGridView.KeyFieldName,
                    "Name");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a company first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var companyName = row[1].ToString();
                    var company = new Company { Id = id, Name = companyName };
                    try
                    {
                        this.entityCompanyController.DeleteEntity(company);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = @"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $@"'{company.Name}', ";
                        this.CompanyGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException ex)
                    {
                        Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
                        return;
                    }
                }

                errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                this.Session["errorMessage"] = errorlabel.Text;
                this.ClientScript.RegisterStartupScript(typeof(Page), "CLOSEWINDOW", this.FuncCall);
            }
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
            this.entityCompanyController = new EntityCompanyController(new VatCalculation());
            if (!this.Page.IsPostBack)
            {
                this.entityProfileController = new EntityProfileController();
                var user = this.Session["user"] as User;

                if (user != null)
                {
                    try
                    {
                        var currentProfile = this.entityProfileController.GetProfile(
                            user.Id,
                            "CompanyGridView",
                            ProfileType.GridView);
                        if (currentProfile != null)
                        {
                            this.CompanyGridView.LoadClientLayout(currentProfile.Customization);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
                    }
                }
            }

            try
            {
                if ((this.Session["SearchedCompanyList"] == null) && (this.searchTaxIdTextBox.Text == string.Empty))
                {
                    this.CompanyGridView.DataSource = this.entityCompanyController.RefreshEntities();
                    this.CompanyGridView.DataBind();
                }
                else
                {
                    this.CompanyGridView.DataSource = this.Session["SearchedCompanyList"];
                    this.CompanyGridView.DataBind();
                }
            }
            catch (SqlException ex)
            {
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }

            var errorlabel = this.Master?.FindControl("form1")?.FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = (string)this.Session["errorMessage"];
                this.Session["errorMessage"] = string.Empty;
            }
        }

        /// <summary>
        /// The search by tax id click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void SearchByTaxIdClick(object sender, EventArgs e)
        {
            try
            {
                var searchedtaxId = this.searchTaxIdTextBox.Text;
                this.entityCompanyController = new EntityCompanyController(new VatCalculation());
                var searchedList = this.entityCompanyController.SearchCompaniesByTaxId(searchedtaxId);
                this.Session["SearchedCompanyList"] = searchedList;
                this.CompanyGridView.DataSource = searchedList;
                this.CompanyGridView.DataBind();
            }
            catch (SqlException ex)
            {
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }
        }

        /// <summary>
        /// The toolbar export item click.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Returns an ArgumentOutOfRangeException.
        /// </exception>
        protected void ToolbarExportItemClick(object source, ExportItemClickEventArgs e)
        {
            switch (e.ExportType)
            {
                case DemoExportFormat.Pdf:
                    this.gridExport.WritePdfToResponse();
                    break;
                case DemoExportFormat.Xls:
                    this.gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
                    break;
                case DemoExportFormat.Xlsx:
                    this.gridExport.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
                    break;
                case DemoExportFormat.Rtf:
                    this.gridExport.WriteRtfToResponse();
                    break;
                case DemoExportFormat.Csv:
                    this.gridExport.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}