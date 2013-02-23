﻿<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <fieldset class="login" style="float:right;width:39%;margin-right:94px;height:360px;">
      <legend>Log in</legend>
      <div>
      <div class="alert alert-danger" runat="server" id="errorDiv">
    <h4>Invalid login !</h4>
  </div>
      <p>
          <asp:Label ID="lblErrorMsg" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
      </p>
      <p>
          <asp:Label ID="lblUserName" runat="server" Text="Login Id" 
              AssociatedControlID="txtUserName"></asp:Label>
          <asp:TextBox ID="txtUserName" runat="server" MaxLength="45"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
              ControlToValidate="txtUserName" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
          <asp:Label ID="lblPassword" runat="server" Text="Password" 
              AssociatedControlID="txtPassword"></asp:Label>
          <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="45"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
              ControlToValidate="txtPassword" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
      </p>
      <p>
          <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
              Text="Sign in" CssClass="btn btn-primary" />
      </p>
      </div>
    </fieldset>
    <div class="clear"></div>
</asp:Content>