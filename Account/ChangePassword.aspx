<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <fieldset>
      <legend>Change Your Password</legend>
      <p>
      <label>Current Password</label>
          <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server" 
                    ControlToValidate="txtCurrentPassword" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
      <label>New Password</label>
          <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                    ControlToValidate="txtPassword" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revPassword" runat="server" 
                    ForeColor="#FF3300" ValidationExpression=".{6}.*" 
                    ControlToValidate="txtPassword" SetFocusOnError="True">Minimum Password length should be 6</asp:RegularExpressionValidator>
      </p>
      <p>
          <label>Confirm Password</label>
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" 
                    ControlToValidate="txtConfirmPassword" ForeColor="#FF3300" 
                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="cvConfirmPassword" runat="server" 
                    ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                    ForeColor="#FF3300" SetFocusOnError="True">Should Match New Password</asp:CompareValidator>
      </p>
      <p>
          <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save"  CssClass="btn btn-save"/>
      <asp:Button ID="btnCancel" runat="server" CausesValidation="False"  Text="Cancel"  
              CssClass="btn btn-cancel" onclick="btnCancel_Click" />
              </p>
</fieldset>
</asp:Content>

