// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWebForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The main web form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.Web.UI;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    using DevExpress.DashboardWeb;

    #endregion

    /// <summary>
    /// The main web form 1.
    /// </summary>
    public partial class MainWebForm1 : Page
    {
        // private Document document;

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
            var dashboard = new Dashboard2();
            this.ASPxDashboardViewer1.DashboardSource = dashboard;
            this.ASPxDashboardViewer1.DataLoading += this.AsPxDashboardViewer1OnDataLoading;
        }

        /// <summary>
        /// The as px dashboard viewer 1 on data loading.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AsPxDashboardViewer1OnDataLoading(object sender , DataLoadingWebEventArgs e)
        {
            var entityDocumentController = new EntityDocumentController();
            var documentList = entityDocumentController.RefreshEntities();
            var emptyCompany = new Company { Name = "Orphan Documents" };
            foreach (var document in documentList)
                if (document.CompanyName == string.Empty)
                {
                    document.Company = emptyCompany;
                }

            e.Data = documentList;
        }
    }
}