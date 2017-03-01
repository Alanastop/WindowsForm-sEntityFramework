<%@ Page Title="" Language="C#" MasterPageFile="MasterWebForm.Master" AutoEventWireup="true" CodeBehind="CompaniesWebForm.aspx.cs" Inherits="DcProgrammimgTutorialWebForm.CompaniesWebForm" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Src="ToolbarExport.ascx" TagName="ToolbarExport" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">




	<div class="container" style="width: 100%">
		<br />
		<br />
		<br />
		<div class="row">
			<div class="col-lg-5 col-sm-12 col-xs-5">
				<input type="button" id="createCompany" tooltip="Creates a new Company" class="theme" runat="server" value="Create Company" onclick="showModalPopUp(this, 'CompaniesPropertiesForm.aspx?companyId=')" />
			</div>
			<div class="col-lg-2 col-sm-12 col-xs-2" style="height: 10px">
			</div>
			<div class="col-lg-5 col-sm-12 col-xs-5">
				<input type="button" runat="server" tooltip="Deletes the selected Company" class="theme" value="Delete Company" onserverclick="DeleteCompanyClick" />
			</div>
		</div>
		<div class="row">
			<div class="col-lg-12" style="height: 10px;">
			</div>
		</div>
	</div>
	<div id="divBackground" class="freeze">
	</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div style="text-align: center">
		<asp:Button ID="Button1" runat="server" CssClass="theme" Text="Search By TaxId" OnClick="SearchByTaxIdClick" />
		<asp:TextBox ID="searchTaxIdTextBox" TextMode="Number" runat="server" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
	</div>
	<br />
	<div>
		 <dx:ToolbarExport runat="server" ID="ToolbarExport" ExportItemTypes="Pdf,Xls,Xlsx,Rtf,Csv" OnItemClick="ToolbarExportItemClick" />

		<dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="CompanyGridView"></dx:ASPxGridViewExporter>
		<dx:ASPxGridView ID="CompanyGridView" runat="server" AutoGenerateColumns="False" ClientInstanceName="CompanyGridView" KeyFieldName="Id" Theme="PlasticBlue" EnableTheming="True" OnClientLayout="CompanyGridViewClientLayout">

			<ClientSideEvents CustomButtonClick="function(s, e) {
			if(e.buttonID == &#39;editButton&#39;){
var rowId = s.GetRowKey(e.visibleIndex);
var link = &quot;CompaniesPropertiesForm.aspx?companyId=&quot;;
 popUpObj = window.open(link + rowId,
		&quot;ModalPopUp&quot;,
		&quot;toolbar=no,&quot; +
		&quot;scrollbars=yes,&quot; +
		&quot;location=no,&quot; +
		&quot;statusbar=no,&quot; +
		&quot;menubar=no,&quot; +
		&quot;resizable=yes,&quot; +
		&quot;width=470px,&quot; +
		&quot;height=450&quot;
	);

	LoadModalDiv();
	popUpObj.focus();
}

}"></ClientSideEvents>

			<Settings ShowFilterRow="True" ShowGroupPanel="True" />
			<Columns>

				<dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0" ButtonRenderMode="Image">
				</dx:GridViewCommandColumn>
				<dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
					<CustomButtons>
						<dx:GridViewCommandColumnCustomButton ID="editButton">
							<Image Url="Images/edit.png" ToolTip="Edit"></Image>
						</dx:GridViewCommandColumnCustomButton>
					</CustomButtons>
				</dx:GridViewCommandColumn>
				<dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="3" Visible="False">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="4">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="TaxId" VisibleIndex="5">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="6">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="7">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Updated" VisibleIndex="8">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UpdatedBy" VisibleIndex="11">
				</dx:GridViewDataTextColumn>
			</Columns>

			<Paddings Padding="0px" />
			<Border BorderWidth="0px" />
			<BorderBottom BorderWidth="1px" />

		</dx:ASPxGridView>
		<div>
			<input type="button" id="reportButton" tooltip="Creates a new Company" class="theme" runat="server" value="Report Viewer" onclick="showModalReportViewer('ReportForm.aspx?Type=Company')" />
		</div>
	</div>

	<p>
	</p>

</asp:Content>
