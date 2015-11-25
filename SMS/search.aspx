<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="search.aspx.cs" Inherits="SMS_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);

            function endRequestHandler(sender, args) {
                AddDatePicker();
            }

            function AddDatePicker() {
                $(".sent-date").datepicker({
                    constrainInput: true,
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true
                });

                $(".sent-date").attr("readonly", true);
            }
            AddDatePicker();
        });
    </script>
    <style type="text/css">
        .table-data th:nth-child(3), .table-data td:nth-child(3)
        {
            max-width: 100px;
            white-space: nowrap;
            overflow-x: scroll;
        }
        .table-data th:nth-child(1), .table-data th:nth-child(2), .table-data th:nth-child(6), 
        .table-data td:nth-child(1), .table-data td:nth-child(2), .table-data td:nth-child(6)
        {
            max-width: 35px;
        }
        .table-data th:nth-child(5), .table-data td:nth-child(5), 
        .table-data th:nth-child(4), .table-data td:nth-child(4),
        .table-data th:nth-child(7), .table-data td:nth-child(7)
        {
            max-width: 25px;
        }
        .table-data th:nth-child(1), .table-data th:nth-child(2), .table-data th:nth-child(4), .table-data td:nth-child(1), .table-data td:nth-child(2), .table-data td:nth-child(4)
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="updateProgress" runat="server">
        <progresstemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/ajax-loader.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 45%; left: 41%;" />
            </div>
        </progresstemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="searchUpdatePane" runat="server" UpdateMode="Conditional">
        <contenttemplate>
            <fieldset>
                <legend>Search </legend>
                <table class="table table-bordered">
                    <tr>
                        <th>User</th>
                        <th>Mobile Number</th>
                        <th>Claim Number</th>
                        <th>Policy Number</th>
                        <th>SMS Sent Date</th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlUser" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtClaimNumber" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPolicyNumber" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSMSSentAt" runat="server" CssClass="sent-date"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </contenttemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="gvUpdatePanel" runat="server" UpdateMode="Conditional">
        <contenttemplate>
            <h3 class="left">
                Search Data
            </h3>
           
            <div class="clear">
            </div>
            <hr />
               <asp:GridView ID="gvSMS" runat="server" CssClass="table table-striped table-bordered table-data" AutoGenerateColumns="False" 
               AllowPaging="True" OnPageIndexChanging="OnPaging" EmptyDataText="No Records" PageSize="20">
                   <Columns>
                       <asp:TemplateField HeaderText="Policy Number">
                           <ItemTemplate>
                               <asp:Label ID="lblPolicyNumber" runat="server" Text='<%# Eval("Policy_Number")%>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Claim Number">
                           <ItemTemplate>
                               <asp:Label ID="lblClaimNumber" runat="server" Text='<%# Eval("Claim_Number")%>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                           <asp:TemplateField HeaderText="Text">
                           <ItemTemplate>
                               <asp:Label ID="lblText" runat="server" Text='<%# Eval("Text")%>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField> 
                       <asp:TemplateField HeaderText="Sent To">
                           <ItemTemplate>
                               <asp:Label ID="lblSentTo" runat="server" Text='<%# Eval("Sent_To")%>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Sent By">
                           <ItemTemplate>
                               <asp:Label ID="lblSentBy" runat="server" Text='<%# Eval("Sent_By")%>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Sent At">
                           <ItemTemplate>
                               <asp:Label ID="lblSentAt" runat="server" Text='<%# Eval("Sent_At")%>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="SMS Status">
                           <ItemTemplate>
                               <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
               </asp:GridView>
        </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
