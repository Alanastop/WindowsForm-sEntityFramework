// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportForm.aspx.cs" company="Data Communication">
//   Dc Tutorial
// </copyright>
// <summary>
//   The report form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.IO;
    using System.Web.UI;

    using DcProgrammimgTutorialWebForm.Reports;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Helpers;

    #endregion

    /// <summary>
    /// The report form.
    /// </summary>
    public partial class ReportForm : Page
    {
        private const string CloseScript = @"<script language='javascript'> PropertiesFormCloseFunction() </script>";

        /// <summary>
        /// The button 1_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            var chosenField = this.Session["ChosenFild"]; // Better way than session??
            this.Response.Redirect("ReportDesighnerForm.aspx?ChosenField=" + chosenField);
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
            this.ClientScript.RegisterStartupScript(typeof(Page) , "CLOSEACTIONS" , CloseScript , false);

            if (!this.IsPostBack)
            {
                var test = this.Request.QueryString["Type"];

                if (test == "Company")
                {
                    this.Session["ChosenFild"] = "Company";
                    var report = new XtraReport1();
                    var entityCompanyController = new EntityCompanyController(new VatCalculation());
                    var companyList = this.Session["SearchedCompanyList"];
                    var layout = this.Session["Layout"];
                    if (layout != null)
                    {
                        report.LoadLayout((Stream)layout);
                    }

                    if (companyList == null)
                    {
                        companyList = entityCompanyController.RefreshEntities();
                    }

                    report.DataSource = companyList;
                    
                    this.ASPxWebDocumentViewer1.OpenReport(report);
                }
                else if (test == "Document")
                {
                    this.Session["ChosenFild"] = "Document";
                    var report = new XtraDocumentsReport();
                    var entityDocumentController = new EntityDocumentController();
                    var layout = this.Session["documentLayout"];
                    if (layout != null)
                    {
                        report.LoadLayout((Stream)layout);
                    }

                    var documentsList = entityDocumentController.RefreshEntities();
                    report.DataSource = documentsList;
                    this.ASPxWebDocumentViewer1.OpenReport(report);
                }
            }
        }
    }
}