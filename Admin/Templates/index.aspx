<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="Admin_Templates_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>
        Templates
    </h3>
    <table class="table table-bordered">
        <tr>
            <td>
                Type
                <br />
                <asp:DropDownList ID="ddlNewType" runat="server">
                    <asp:ListItem>SMS</asp:ListItem>
                    <asp:ListItem>Bulk_SMS</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Name
                <br />
                <asp:TextBox ID="txtNewName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewName" runat="server" ControlToValidate="txtNewName"
                    ValidationGroup="new_template" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            <td>
                Text
                <br />
                <asp:TextBox ID="txtTextNew" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTel" runat="server" ControlToValidate="txtTextNew"
                    ValidationGroup="new_template" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add New Template" OnClick="AddNewTemplate"
                    ValidationGroup="new_template" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvTemplates" runat="server" AutoGenerateColumns="false" ShowFooter="true"
        OnRowEditing="EditTemplate" OnRowUpdating="UpdateTemplate" OnRowCancelingEdit="CancelEdit"
        EmptyDataText="No Templates" CssClass="table table-bordered">
        <Columns>
            <asp:TemplateField HeaderText="Langauage">
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="hdnFldType" runat="server" Value='<%# Eval("Type") %>' />
                    <asp:HiddenField ID="hdnFldId" runat="server" Value='<%# Eval("Id") %>' />
                    <asp:DropDownList ID="ddlType" runat="server" ValidationGroup="edit_template">
                        <asp:ListItem>SMS</asp:ListItem>
                        <asp:ListItem>BULK_SMS</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ValidationGroup="edit_template" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Text">
                <ItemTemplate>
                    <asp:Label ID="lblText" runat="server" Text='<%# Eval("Text")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtText" runat="server" Text='<%# Eval("Text")%>' TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvText" runat="server" ControlToValidate="txtText"
                        ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
