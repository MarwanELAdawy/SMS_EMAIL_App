<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="New.aspx.cs" Inherits="Emails_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
 <legend>Send Email</legend>      
  <p>
  <label>Claim Number</label>
    <asp:TextBox ID="txtClaimNumber" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvClaimNumber" runat="server" 
                    ControlToValidate="txtClaimNumber" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revClaimNumber" runat="server" ForeColor="#FF3300" ValidationExpression="\d+" 
                    ControlToValidate="txtClaimNumber" SetFocusOnError="True">Only numbers are allowed !</asp:RegularExpressionValidator>
      </p>
      <p>
  <label>Policy Number</label>
    <asp:TextBox ID="txtPolicyNumber" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPolicyNumber" runat="server" 
                    ControlToValidate="txtPolicyNumber" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
      <label>TP Id</label>
    <asp:TextBox ID="txtTPID" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvTPID" runat="server" 
                    ControlToValidate="txtTPID" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
  <label>TP Name</label>
    <asp:TextBox ID="txtTpName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvTpName" runat="server" 
                    ControlToValidate="txtTpName" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
  <label>Mobile Number</label>
    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revMobile" runat="server" ForeColor="#FF3300" ValidationExpression="\d*"
                    ControlToValidate="txtMobile" SetFocusOnError="True">Please enter valid phone number !</asp:RegularExpressionValidator>
      </p>
      <p>
      <label>Subject</label>
    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" 
                    ControlToValidate="txtSubject" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
  <label>Email</label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" 
                    ControlToValidate="txtEmail" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revEmail" runat="server" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
                    ControlToValidate="txtEmail" SetFocusOnError="True">Please enter valid email !</asp:RegularExpressionValidator>
      </p>
      <p>
      <label>Body</label>
          <asp:TextBox ID="txtText" runat="server" TextMode="MultiLine"></asp:TextBox>
      <asp:RequiredFieldValidator ID="rfvText" runat="server" 
                    ControlToValidate="txtText" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
          <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" Text="Send"  CssClass="btn btn-save"/>
      <asp:Button ID="btnCancel" runat="server" CausesValidation="False"  Text="Cancel"  
              CssClass="btn btn-cancel" onclick="btnCancel_Click" />
              </p>
</fieldset>
</asp:Content>

