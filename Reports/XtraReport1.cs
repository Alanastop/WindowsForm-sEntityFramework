using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DcProgrammimgTutorialWebForm.Reports
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            
            InitializeComponent();
        }

        private void xrLabel5_BeforePrint(object sender , System.Drawing.Printing.PrintEventArgs e)
        {
            this.DetailsLabel.Text = this.DetailReport.DrillDownExpanded ? "Hide Documents" : "Show Documents";
        }
    }
}
