<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="ReportForm.aspx.cs" Inherits="DcProgrammimgTutorialWebForm.ReportForm" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.XtraReports.Web" Assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportForm</title>
    <link href="CssFiles/Header.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <script src="Scripts/Scripts.js"></script>
    <script src="Scripts/ValidationScript.js"></script>
    <%--<script type="text/javascript">
        window.onbeforeunload = function () {
            if (window.opener !== null && !window.opener.closed) {
                var element = document.activeElement;
                if (element != undefined && element.classList.contains("editButtonClass")) {
                    return;
                }

                //var bcgDiv = document.getElementById("divBackground");
                //bcgDiv.style.display = "none";
                window.opener.location.href = window.opener.location.href;
                window.close();
            }
        }
    </script>--%>
</head>
    <body id="themeId" class="form lightThemeClass">
        <form id="form1" runat="server">
            <div>
                <asp:Button CssClass="editButtonClass" ID='Button1' runat="server" Text="Edit Report" OnClick="Button1_OnClick" />  
            </div>
            <div>
                <dx:ASPxWebDocumentViewer ID='ASPxWebDocumentViewer1' runat="server"></dx:ASPxWebDocumentViewer>
            </div>
            <div id="divBackground" class="freeze">
	        </div>
        </form>
    
    </body>
</html>

