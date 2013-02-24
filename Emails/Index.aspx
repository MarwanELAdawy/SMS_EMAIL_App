<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Emails_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h3 class="left">
    Sent Emails
  </h3>
<h3 class="right">
    <a href="New.aspx">New</a> 
  </h3>
  <div class="clear"></div>
  <hr />
    <asp:GridView ID="gvEmails" runat="server" AllowPaging="True" CssClass="table table-bordered" 
        Width="100%" EmptyDataText="No Send Emails!" 
        onpageindexchanging="gvEmails_PageIndexChanging" 
        onrowdatabound="gvEmails_RowDataBound" PageSize="30">
    </asp:GridView>
</asp:Content>

