<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Users_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h3 class="right">
    <a href="Index.aspx">Back</a> 
  </h3>
  <div class="clear"></div>
<fieldset>
      <legend>Edit User</legend>
          <asp:HiddenField ID="hdnCurrentUserName" runat="server" Visible="False" />
      <p>
          <label>User Name</label>
    <asp:TextBox ID="txtUserName" runat="server" MaxLength="45"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                    ControlToValidate="txtUserName" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
      <label>Status</label>
    <asp:DropDownList ID="ddlStatus" runat="server">
      <asp:ListItem Value="0">Select</asp:ListItem>
      <asp:ListItem Value="Active">Active</asp:ListItem>
      <asp:ListItem Value="InActive">Inactive</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" 
                    ControlToValidate="ddlStatus" ForeColor="#FF3300" SetFocusOnError="True" 
                    InitialValue="0">*</asp:RequiredFieldValidator>
      </p>
       <p>
        <label>Can Search</label>
          <asp:CheckBox ID="ckbSearch" runat="server" />
      </p>
      <p>
          <asp:HiddenField ID="hdnUserId" runat="server" />
          <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save"  CssClass="btn btn-save"/>
      <asp:Button ID="btnCancel" runat="server" CausesValidation="False"  Text="Cancel"  
              CssClass="btn btn-cancel" onclick="btnCancel_Click" />
               </p>
</fieldset>
</asp:Content>

