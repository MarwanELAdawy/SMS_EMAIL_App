<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Emails_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
    span{
     font-weight : bold;
     margin-right: 3px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
 <legend>Sent Email Details</legend>      
 <p>
  <span>Sent At</span>
  <%= DateTimeHelper.ConvertToString(email.Created_At.ToString()) %>
  </p>
  <p>
  <span>Send By</span>
  <%= email.tbl_Users.User_Name %>
  </p>
  <p>
    <span>Claim Number:</span>
    <%= email.Claim_Number %>
  </p>
  <p>
  <span>Policy Number:</span>
  <%= email.Policy_Number %>
  </p>
  <p>
  <span>TP Name:</span>
  <%= email.TP_Name %>
  </p>
  <p>
  <span>Mobile:</span>
  <%= email.Mobile_Number %>
  </p>
  <p>
  <span>Email:</span>
  <%= email.Email %>
  </p>
  <p>
  <span>Subject:</span>
  <%= email.Email_Subject %>
  </p>
  <p>
  <span>Body:</span>
  <br />
  <%= email.Text %>
  </p>
  <h3><a href="Index.aspx">Back</a></h3>
  </fieldset>
</asp:Content>

