// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentsWebForm.aspx.cs" company="Data Communication">
//   DC Tutorial
// </copyright>
// <summary>
//   The documents web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Web.UI.WebControls;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    using DevExpress.Export;
    using DevExpress.Web;
    using DevExpress.XtraPrinting;

    using Document = DcProgrammingTutorial.Lib.Model.Persistent.Document;
    using Page = System.Web.UI.Page;

    #endregion

    /// <summary>
    /// The documents web form.
    /// </summary>
    public partial class DocumentsWebForm : Page
    {
        /// <summary>
        /// The function call.
        /// </summary>
        protected readonly string FuncCall =
            @"<script language='javascript'>window.location.href = window.location.href;</script>";

        /// <summary>
        /// The entity document controller.
        /// </summary>
        private EntityDocumentController entityDocumentController;

        /// <summary>
        /// The entity profile controller.
        /// </summary>
        private EntityProfileController entityProfileController;

        /// <summary>
        /// The delete document_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteDocumentClick(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                var firstRun = true;

                if (this.DocumentGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = @"There are no documents to delete";
                }

                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.DocumentGridView.GetSelectedFieldValues(
                    this.DocumentGridView.KeyFieldName,
                    "Name");

                if (selectedRowKeys == null || selectedRowKeys.Count == 0)
                {
                    errorlabel.Text = @"Please select a company first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var documentName = row[1].ToString();
                    var document = new Document { Id = id, Name = documentName };
                    try
                    {
                        this.entityDocumentController.DeleteEntity(document);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = @"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $@"'{document.Name}', ";
                        this.DocumentGridView.Selection.UnselectRow(id);
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
            this.entityDocumentController = new EntityDocumentController();
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
                            "DocumentGridView",
                            ProfileType.GridView);
                        if (currentProfile != null)
                        {
                            this.DocumentGridView.LoadClientLayout(currentProfile.Customization);
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
                var documentList = this.entityDocumentController.RefreshEntities();

                this.DocumentGridView.DataSource = documentList;
                this.DocumentGridView.DataBind();


                var averageBalance = Math.Round(this.entityDocumentController.CalculateAverageBalance(documentList), 2);
                this.TextBox9.Text = Convert.ToString(averageBalance, CultureInfo.InvariantCulture);
            }
            catch (Exception ex) when (ex is SqlException || ex is ArgumentNullException)
            {
                Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
            }

            var errorlabel = this.Master?.FindControl("form1")?.FindControl("divErrorMessage") as Label;
            if (errorlabel == null)
            {
                return;
            }

            errorlabel.Text = (string)this.Session["errorMessage"];
            this.Session["errorMessage"] = string.Empty;
        }

        /// <summary>
        /// The document grid view_ on client layout.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DocumentGridView_OnClientLayout(object sender, ASPxClientLayoutArgs e)
        {
            this.entityProfileController = new EntityProfileController();
            var user = this.Session["user"] as User;
            if (user != null)
            {
                try
                {
                    var currentProfile = this.entityProfileController.GetProfile(
                                                            user.Id,
                                                            "DocumentGridView",
                                                            ProfileType.GridView)
                                                        ?? new Profile
                                                        {
                                                            UserId = user.Id,
                                                            ProfileType = ProfileType.GridView,
                                                            ViewId = "DocumentGridView"
                                                        };

                    currentProfile.Customization = this.DocumentGridView.SaveClientLayout();
                    this.entityProfileController.CreateOrUpdateEntity(currentProfile);
                }
                catch (SqlException ex)
                {
                    Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
                }
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