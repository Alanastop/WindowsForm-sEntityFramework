<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testdashboard.aspx.cs" Inherits="DcProgrammimgTutorialWebForm.Testdashboard" %>

<%@ Register Assembly="DevExpress.Dashboard.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxDashboard ID=ASPxDashboard1 runat="server" DashboardStorageFolder="~/App_Data"></dx:ASPxDashboard>
    </div>
    </form>
</body>
</html>
