<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Admin_Users_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h3 class="left">
    All Users
  </h3>
<h3 class="right">
    <a href="New.aspx">New</a> 
  </h3>
  <div class="clear"></div>
  <hr />
    <asp:GridView ID="gvUsers" runat="server" AllowPaging="True" CssClass="table table-bordered" 
        Width="100%" EmptyDataText="No Users!" 
        onpageindexchanging="gvUsers_PageIndexChanging" 
        onrowdatabound="gvUsers_RowDataBound" PageSize="30">
    </asp:GridView>
</asp:Content>

