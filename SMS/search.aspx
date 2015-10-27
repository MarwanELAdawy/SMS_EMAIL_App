<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="SMS_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="updateProgress" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/ajax-loader.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 45%; left: 41%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="searchUpdatePane" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>Search </legend>
                <table class="table table-bordered">
                    <tr>
                        <th>Mobile Number</th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ControlToValidate="txtMobileNumber"
                                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobileNumber" runat="server" ControlToValidate="txtMobileNumber"
                                    ForeColor="#FF3300" SetFocusOnError="True" ValidationExpression="^[0-9]+$">Enter in Correct Format</asp:RegularExpressionValidator>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="gvUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h3 class="left">
                Search Data
            </h3>
           
            <div class="clear">
            </div>
            <hr />
            <asp:GridView ID="gvSMS" runat="server" AllowPaging="True" CssClass="table table-bordered"
                Width="100%" EmptyDataText="No Sent SMS!" OnPageIndexChanging="gvSMS_PageIndexChanging"
                OnRowDataBound="gvSMS_RowDataBound" PageSize="30">
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

