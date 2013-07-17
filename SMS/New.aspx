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
            <asp:RadioButtonList ID="rblSMSLanguage" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">English</asp:ListItem>
                <asp:ListItem>Arabic</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            <label>
                Message</label>
            <asp:TextBox ID="txtText" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvText" runat="server" ControlToValidate="txtText"
                ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </p>
        <!--
        <p>
            <label>
                Template</label>
            <asp:DropDownList ID="ddlTemplate" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvTemplate" runat="server" ControlToValidate="ddlTemplate"
                ForeColor="#FF3300" SetFocusOnError="True" InitialValue="0">*</asp:RequiredFieldValidator>
        </p>
        -->
        <p>
            <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" CssClass="btn btn-save" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel"
                CssClass="btn btn-cancel" OnClick="btnCancel_Click" />
        </p>
        <div class="alert alert-success" id="duplicateSmsDiv" runat="server">
            <h4>
            SMS for this policy has been sent alread !.
            <asp:Button ID="btnSendDuplicate" runat="server" OnClick="btnSendDuplicate_Click" Text="Send Anyway..." CssClass="btn btn-save" />
             </h4>
            <div class="clear">
            </div>
        </div>
    </fieldset>
</asp:Content>
