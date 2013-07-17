<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="Bulk_SMS_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>
        Bulk SMS
    </h3>
    <table class="table table-bordered">
        <tr>
            <td>
                File
                <input type="file" id="smsFile" name="smsFile" />
            </td>
            <td>
                Template
                <asp:DropDownList ID="ddlTemplate" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name"
                    DataValueField="Id" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTemplate" runat="server" ControlToValidate="ddlTemplate"
                    ForeColor="#FF3300" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SMS_EMAIL_DBConnectionString %>"
                    SelectCommand="SELECT [Id], [Name] FROM [tbl_Templates] WHERE ([Type] = @Type) ORDER BY [Created_At]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Bulk_SMS" Name="Type" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvSMS" runat="server" AutoGenerateColumns="false" ShowFooter="true"
        EmptyDataText="No Records" CssClass="table table-bordered">
        <Columns>
            <asp:TemplateField HeaderText="Id">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created At">
                <ItemTemplate>
                    <asp:Label ID="lblCreatedAt" runat="server" Text='<%# Eval("CreatedAt")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Input File">
                <ItemTemplate>
                    <asp:LinkButton ID="lkBtnInputDownload" runat="server" onclick="lkBtnInputDownload_Click" CausesValidation="false" CommandArgument='<%# Eval("Id") %>' ><%# Eval("InputFileName") %></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Output File">
                <ItemTemplate>
                    <asp:LinkButton ID="lkBtnOutputDownload" runat="server" onclick="lkBtnOutputDownload_Click" CausesValidation="false" CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("Visible") %>' ><%# Eval("OutputFileName") %></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
