<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="New.aspx.cs" Inherits="SMS_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        #MainContent_rblSMSLanguage
        {
            margin-left: 9px;
            width: 221px;
        }
        #MainContent_rblSMSLanguage td label
        {
            margin-left: 5px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <legend>Send SMS</legend>
        <p>
            <label>
                Claim Number</label>
            <asp:TextBox ID="txtClaimNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvClaimNumber" runat="server" ControlToValidate="txtClaimNumber"
                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <label>
                Policy Number</label>
            <asp:TextBox ID="txtPolicyNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPolicyNumber" runat="server" ControlToValidate="txtPolicyNumber"
                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <label>
                TP Id</label>
            <asp:TextBox ID="txtTPID" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTPID" runat="server" ControlToValidate="txtTPID"
                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <label>
                TP Name</label>
            <asp:TextBox ID="txtTpName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTpName" runat="server" ControlToValidate="txtTpName"
                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <label>
                Mobile Number</label>
            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile"
                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revMobile" runat="server" ForeColor="#FF3300"
                ValidationExpression="\d{9}" ControlToValidate="txtMobile" SetFocusOnError="True">Please enter valid phone number !</asp:RegularExpressionValidator>
        </p>
        <p>
            <label>
                Email</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </p>
        <p>
            <label>
                Template</label>
            <asp:DropDownList ID="ddlTemplate" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvTemplate" runat="server" ControlToValidate="ddlTemplate"
                ForeColor="#FF3300" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" CssClass="btn btn-save" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel"
                CssClass="btn btn-cancel" OnClick="btnCancel_Click" />
        </p>
    </fieldset>
</asp:Content>
