<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="Admin_Templates_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>
        Templates
    </h3>
    <asp:GridView ID="gvTemplates" runat="server" AutoGenerateColumns="false" ShowFooter="true"
        OnRowEditing="EditTemplate" OnRowUpdating="UpdateTemplate" OnRowCancelingEdit="CancelEdit"
        EmptyDataText="No Templates" CssClass="table table-bordered">
        <Columns>
            <asp:TemplateField HeaderText="Langauage">
                <ItemTemplate>
                    <asp:Label ID="lblLnaguage" runat="server" Text='<%# Eval("Language")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="hdnFldLanguage" runat="server" Value='<%# Eval("Language") %>' />
                    <asp:HiddenField ID="hdnFldId" runat="server" Value='<%# Eval("Id") %>' />
                    <asp:DropDownList ID="ddlLanguage" runat="server" ValidationGroup="edit_template">
                        <asp:ListItem>Arabic</asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlLanguageNew" runat="server" ValidationGroup="new_template">
                        <asp:ListItem>Arabic</asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
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
                <FooterTemplate>
                    <asp:TextBox ID="txtTextNew" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTel" runat="server" ControlToValidate="txtTextNew" ValidationGroup="new_template"
                        ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <FooterTemplate>
                    <asp:Button ID="btnAdd" runat="server" Text="Add New Template" OnClick="AddNewTemplate" ValidationGroup="new_template" CssClass="btn btn-primary" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
