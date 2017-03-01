<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDesighnerForm.aspx.cs" Inherits="DcProgrammimgTutorialWebForm.ReportDesighner" %>

<%@ Register Assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CssFiles/Header.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <script src="Scripts/Scripts.js"></script>
    <script src="Scripts/ValidationScript.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="report" Enabled="False" CssClass="hidden" runat="server" ></asp:TextBox>
        <dx:ASPxReportDesigner ID=ASPxReportDesigner1 runat="server" OnSaveReportLayout="ASPxReportDesigner1_SaveReportLayout">
            <ClientSideEvents ExitDesigner='function(s, e) {
              
	var report = document.getElementById(&#039;report&#039;);
	var reportValue = report.value;
	localStorage.setItem(&#039;preventExit&#039;, true);
	window.location = "ReportForm.aspx?Type="+ reportValue;
}' ></ClientSideEvents>
        </dx:ASPxReportDesigner>
    </div>
    </form>
</body>
</html>
