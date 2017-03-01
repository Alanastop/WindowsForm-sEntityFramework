// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportDesighnerForm.aspx.cs" company="Data Communication">
//   DC Tutorial
// </copyright>
// <summary>
//   The report desighner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.IO;
    using System.Web.UI;

    using DcProgrammimgTutorialWebForm.Reports;

    using DevExpress.XtraReports.Web;

    #endregion

    /// <summary>
    /// The report designer.
    /// </summary>
    public partial class ReportDesighner : Page
    {
        private const string CloseScript = @"<script language='javascript'> PropertiesFormCloseFunction() </script>";

        /// <summary>
        /// The as px report designer 1_ save report layout.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ASPxReportDesigner1_SaveReportLayout(object sender, SaveReportLayoutEventArgs e)
        {
            var stream = new MemoryStream();
            var chosenField = this.Request.QueryString["ChosenField"];
            stream.Write(e.ReportLayout, 0, e.ReportLayout.Length);
            if (chosenField == "Company")
            {
                this.Session["Layout"] = stream;
            }
            else if (chosenField == "Document")
            {
                this.Session["documentLayout"] = stream;
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
            this.ClientScript.RegisterStartupScript(typeof(Page), "CLOSEACTIONS" , CloseScript , false);

            if (!this.IsPostBack && !this.IsCallback)
            {
                var chosenField = this.Request.QueryString["ChosenField"];
                if (chosenField == "Company")
                {
                    var report = new XtraReport1();
                    var layout = this.Session["Layout"];
                    if (layout != null)
                    {
                        report.LoadLayout((Stream)layout);
                    }

                    this.report.Text = "Company";

                    this.ASPxReportDesigner1.OpenReport(report);
                }
                else if (chosenField == "Document")
                {
                    var report = new XtraDocumentsReport();
                    var layout = this.Session["DocumentLayout"];
                    if (layout != null)
                    {
                        report.LoadLayout((Stream)layout);
                    }

                    this.report.Text = "Document";

                    this.ASPxReportDesigner1.OpenReport(report);
                }
            }
        }
    }
}