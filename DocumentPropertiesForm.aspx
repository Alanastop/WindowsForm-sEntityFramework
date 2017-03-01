<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentPropertiesForm.aspx.cs" Inherits="DcProgrammimgTutorialWebForm.DocumentPropertiesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DocumentPropertiesForm</title>
    <link href="CssFiles/Header.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <script src="Scripts/ThemeQuery.js"></script>
    <script src="Scripts/ValidationScript.js"></script>
    <script src="Scripts/Scripts.js"></script>
    <script src="Scripts/Highlight.js"></script>
    <script src="Scripts/ThemeQuery.js"></script>
    <script src="Scripts/decimals.js"></script>
</head>
<body id="themeId" class="form lightThemeClass">

    <form id="form1" runat="server">

        

        <h1 style="font-family: initial; font-size: 25px; text-align: center">Document Properties Form</h1>
        <br />
        <div style="font-size: medium; color: red; text-align: left; vertical-align: bottom" id="divErrorMessage" runat="server"></div>
        <div style="max-width: 400px">


            <div class="container" style="width: 100%">

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" runat="server" Text="Company Name:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:DropDownList ID="companyNameDropDown" runat="server" onchange="valueChange(this);">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="nameLabel" runat="server" Text="Name:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox CssClass="myTextBox" ID="nameTextBox" runat="server" onchange="validation(this); valueChange(this);"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="codeLabel" runat="server" Text="Code:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="codeTextBox" runat="server" onchange="valueChange(this);"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="Label1" runat="server" Text="Balance:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox TextMode="Number" step="0.01" CssClass="decimal" ID="balanceTextBox" runat="server" OnLoad="BalanceTextBoxOnLoad" OnTextChanged="balanceTextBox_OnTextChanged" AutoPostBack="True" onchange="checkBalancePostBack(); valueChange(this);"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="createdLabel" runat="server" Text="Created:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="createdTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="createdBy" runat="server" Text="Created By:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="createdByTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="updatedLabel" runat="server" Text="Updated:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="updatedTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="updatedByLabel" runat="server" Text="Updated By:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="updatedByTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <asp:Label CssClass="mylabel" ID="taxLabel" runat="server" Text="Tax:"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="taxTextBox" Enabled="False" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-xs-12">
                        <asp:TextBox ID="greenTextBox" Enabled="False" runat="server" CssClass="hidden"></asp:TextBox>
                    </div>
                </div>

            </div>


            <div style="position: absolute; bottom: 0;" class="divTable">
                <div class="divTableBody">
                    <div class="divTableRow">
                        <div class="divDocumentPropertiesTableCell">&nbsp;</div>
                    </div>
                    <div class="divTableRow">
                        <div style="text-align: right; padding-right: 10px;" class="divDocumentPropertiesTableCell">
                            &nbsp;
            <asp:Button ID="Button1" CssClass="propertiesOKButton theme" runat="server" OnClientClick="return documentSubmitClick();" OnClick="PropertiesButtonOnClick" Text="Save"/>
                            <input type="submit" class="propertiesCancelButton theme" value="Close" onclick="window.close();"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    

</body>
</html>

