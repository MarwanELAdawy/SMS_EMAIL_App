<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="Bulk_SMS_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <script type="text/javascript">
     $(function () {
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);

         function endRequestHandler(sender, args) {
             $(".sent-date").datepicker({
                 constrainInput: true,
                 dateFormat: "dd-mm-yy",
                 changeMonth: true,
                 changeYear: true
             });

             $(".sent-date").attr("readonly", true);
         }
     });
    </script>
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
                        <td>
                            <label>
                                Search Field</label>
                            <asp:DropDownList ID="ddlSearchField" runat="server" OnSelectedIndexChanged="ddlSearchField_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <label>
                                Value</label>
                            <asp:TextBox ID="txtSentDate" runat="server" CssClass="sent-date"></asp:TextBox>
                            <asp:TextBox ID="txtField" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSentDate" runat="server" ControlToValidate="txtSentDate"
                                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfvField" runat="server" ControlToValidate="txtField"
                                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
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
                Sent BULK SMS
            </h3>
            <h3 class="right">
                <a href="index.aspx" class="right btn btn-info">Home</a>
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

