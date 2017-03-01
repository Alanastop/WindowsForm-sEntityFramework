<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompaniesPropertiesForm.aspx.cs" Inherits="DcProgrammimgTutorialWebForm.CompaniesPropertiesForm" Async="true" %>

<%@ Register TagPrefix="dxwgv" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dxe" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CompaniesPropertiesForm</title>
    <link href="CssFiles/Header.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <script src="Scripts/ThemeQuery.js"></script>
    <script src="Scripts/ValidationScript.js"></script>
    <script src="Scripts/Highlight.js"></script>
    <link href="CssFiles/Header.css" rel="stylesheet" />
    
</head>
<body id="themeId" class="form lightThemeClass">

   
    <form id="form1" runat="server">
        <asp:ScriptManager EnablePageMethods="True" runat="server"></asp:ScriptManager>
        <script src="Scripts/Scripts.js"></script>

        <h1 style="font-family: initial; font-size: 25px; text-align: center">Company Properties Form</h1>
        <br />
        <div style="font-size: medium; color: red; text-align: left; vertical-align: bottom" id="divErrorMessage" runat="server"></div>
        <div style="max-width: 400px">


            <div class="container" style="width: 100%">

                <div class="row">
                    <div class="col-xs-5">
                        <asp:Label CssClass="mylabel" runat="server" Text="Name:"></asp:Label>
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox ID="nameTextBox" runat="server" onchange="validation(this); valueChange(this);"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-5">
                        <asp:Label CssClass="mylabel" ID="codeLabel" runat="server" Text="Code:"></asp:Label>
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox ID="codeTextBox" runat="server" onchange="valueChange(this);"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-5">
                        <asp:Label runat="server" CssClass="mylabel" ID="taxIdLabel" Text="Tax Id:"></asp:Label>
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox runat="server" ID="taxIdTextBox" onchange="taxIdValidation(this.value); valueChange(this);" AutoPostBack="False" MaxLength="9"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-5">
                        <asp:Label CssClass="mylabel" ID="createdLabel" runat="server" Text="Created:"></asp:Label>
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox ID="createdTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-5">
                        <asp:Label CssClass="mylabel" ID="createdBy" runat="server" Text="Created By:"></asp:Label>
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox ID="createdByTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-5">
                        <asp:Label CssClass="mylabel" ID="updatedLabel" runat="server" Text="Updated:"></asp:Label>
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox ID="updatedTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-5">
                        <asp:Label CssClass="mylabel" ID="updatedByLabel" runat="server" Text="Updated By:"></asp:Label>
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox ID="updatedByTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-5">
                        <input type="button" runat="server" ID="sendEmailButton" class="mybutton sendEmailButton" onclick="checkSendMailPostBack();" OnServerClick="SendEmailButtonOnClick" value="Send Email" />
                    </div>
                    <div class="col-xs-5">
                        <asp:TextBox ID="receiverEmailTextBox" TextMode="Email" Placeholder="Enter a mail" Enabled="True" runat="server"></asp:TextBox>
                        <asp:TextBox ID="activeDirectoryPassword" Placeholder="Enter you mail's password" TextMode="Password" Enabled="True" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <asp:TextBox ID="greenTextBox" Enabled="False" CssClass="hidden" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>

            <br />
            <dx:ASPxGridView ID="DocumentsGridView" runat="server" AutoGenerateColumns="False" ClientInstanceName="CompanyGridView" KeyFieldName="Id" Theme="PlasticBlue" EnableTheming="True" OnHtmlRowPrepared="DocumentsGridViewHtmlRowPrepared" EnableRowsCache="False">
                <ClientSideEvents SelectionChanged="function(s, e) {
}" />
                <SettingsBehavior AllowSelectByRowClick="True" />
                <Columns>
                    <dx:GridViewCommandColumn  SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Name="Id" FieldName="Id" VisibleIndex="3" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Balance" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>

                </Columns>
            </dx:ASPxGridView>
        </div>

        <div style="position: absolute;" class="divTable">
            <div class="divTableBody">
                <div class="divTableRow">
                    <div class="divDocumentPropertiesTableCell">&nbsp;</div>
                </div>
                <div class="divTableRow">
                    <div style="text-align: right; padding-right: 10px;" class="divDocumentPropertiesTableCell">
                        &nbsp;
            <asp:Button ID="propertiesbutton" ClientIDMode="Static" CssClass="propertiesOKButton theme" runat="server" OnClientClick="return companySubmitClick();" OnClick="propertiesbutton_OnClick" Text="Save" />
                        <input type="button" class="propertiesCancelButton theme" value="Close" onclick="window.close();" />
                    </div>
                </div>
            </div>
        </div>

    </form>

</body>
</html>
