<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebForm.Master" AutoEventWireup="true" CodeBehind="DocumentsWebForm.aspx.cs" Inherits="DcProgrammimgTutorialWebForm.DocumentsWebForm" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" TagName="ToolbarExport" Src="~/ToolbarExport.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<link href="CssFiles/Header.css" rel="stylesheet" />
   

	<div class="container leftside-container" style="width: 100%">
		<div class="row">
			<div class="col-lg-5 col-sm-12 col-xs-5">
				<input type="button" id="createDocumentButton" tooltip="Creates a new Document" class="theme" runat="server" value="Create Document" onclick="showModalPopUp(this, 'DocumentPropertiesForm.aspx?documentId=')" />
			</div>
			<div class="col-lg-1 col-sm-12 col-xs-1" style="height: 10px;">
			</div>
			<div class="col-lg-5 col-sm-12 col-xs-5">
				<asp:Button ToolTip="Deletes the selected Document" CssClass="theme" runat="server" Text="Delete Document"  OnClick="DeleteDocumentClick"></asp:Button>
			</div>
		</div>
		<div class="row">
			<div class="col-lg-12" style="height: 10px;">
			</div>
		</div>
		<div class="row">
			<div class="col-lg-5 col-sm-12 col-xs-5">
				<label>Average:</label>
			</div>
			<div class="col-lg-1 col-sm-12 col-xs-1" style="height: 10px">
			</div>
			<div class="col-lg-5 push-lg-2 col-sm-12 col-xs-5">
				<asp:TextBox Width="100%" ID="TextBox9" ClientIDMode="Static" runat="server" CssClass="averageInput" ReadOnly="True"></asp:TextBox>
			  
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


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
	     <dx:ToolbarExport runat="server" ID="ToolbarExport" ExportItemTypes="Pdf,Xls,Xlsx,Rtf,Csv" OnItemClick="ToolbarExportItemClick" />

		<dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="DocumentGridView"></dx:ASPxGridViewExporter>
		 <dx:ASPxGridView ID="DocumentGridView" runat="server" AutoGenerateColumns="False" ClientInstanceName="DocumentGridView" KeyFieldName="Id" Theme="PlasticBlue" EnableTheming="True" OnClientLayout="DocumentGridView_OnClientLayout">

			<ClientSideEvents CustomButtonClick="function(s, e) {
			if(e.buttonID == &#39;editButton&#39;){
var rowId = s.GetRowKey(e.visibleIndex);
var link = &quot;DocumentPropertiesForm.aspx?documentId=&quot;;
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
				 <dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="3" Visible="False">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="4">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Balance" VisibleIndex="5">
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
		<asp:GridView ID="GridView1" ClientIDMode="Static" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="mytable gridview">
			<Columns>
				<asp:TemplateField HeaderText="Select">
					<ItemTemplate>
						<asp:CheckBox ID="selectRow" runat="server"></asp:CheckBox>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Edit" ShowHeader="False">
					<ItemTemplate>
						<asp:LinkButton ID="editLinkButton" runat="server" OnClientClick="return showModalPopUp(this, 'DocumentPropertiesForm.aspx?documentId=')">
						  <img src="Images/edit.png" style="width: 45px; display: block;text-align: center" alt="No image to display"></img>
						</asp:LinkButton>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Id">
					<HeaderStyle CssClass="hiddencol" />
					<FooterStyle CssClass="hiddencol" />
					<ItemStyle CssClass="hiddencol" />
					<EditItemTemplate>
						<asp:TextBox runat="server" Text='<%# Bind("Id") %>' ID="TextBox1"></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:HiddenField runat="server" Value='<%# Bind("Id") %>' ID="Label2"></asp:HiddenField>
					</ItemTemplate>
					<HeaderStyle CssClass="content-td" />
					<ItemStyle CssClass="content-td" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Company Name">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label1" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Name">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label3" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle CssClass="content-td" />
					<ItemStyle CssClass="content-td" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Code">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label4" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle CssClass="content-td" />
					<ItemStyle CssClass="content-td" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Balance">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Balance") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label5" runat="server" Text='<%# Bind("Balance") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle CssClass="content-td" />
					<ItemStyle CssClass="content-td" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Created">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Created") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label6" runat="server" Text='<%# Bind("Created") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle CssClass="content-td" />
					<ItemStyle CssClass="content-td" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Created By">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label7" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle CssClass="content-td" />
					<ItemStyle CssClass="content-td" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Updated">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Updated") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label8" runat="server" Text='<%# Bind("Updated") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle CssClass="content-td" />
					<ItemStyle CssClass="content-td" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Updated By">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("UpdatedBy") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label9" runat="server" Text='<%# Bind("UpdatedBy") %>'></asp:Label>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
			<HeaderStyle BackColor="#294163" Font-Bold="True" ForeColor="White" />
			<PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
			<RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
			<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
			<SortedAscendingCellStyle BackColor="#FFF1D4" />
			<SortedAscendingHeaderStyle BackColor="#B95C30" />
			<SortedDescendingCellStyle BackColor="#F1E5CE" />
			<SortedDescendingHeaderStyle BackColor="#93451F" />
		</asp:GridView>
        <div>
            <input type="button" id="reportButton" tooltip="Creates a new Company" class="theme" runat="server" value="Report Viewer" onclick="showModalReportViewer('ReportForm.aspx?Type=Document')" />
        </div>
	</div>
</asp:Content>
