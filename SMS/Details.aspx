<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Details.aspx.cs" Inherits="SMS_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        span
        {
            font-weight: bold;
            margin-right: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset>
        <asp:HiddenField ID="hdnFldSMSId" runat="server" />
        <legend>Sent SMS Details</legend>
        <p>
            <span>Sent At</span>
            <%= DateTimeHelper.ConvertToString(sms.Created_At.ToString()) %>
        </p>
        <p>
            <span>Claim Number:</span>
            <%= sms.Claim_Number %>
        </p>
        <p>
            <span>Policy Number:</span>
            <%= sms.Policy_Number %>
        </p>
        <p>
            <span>TP ID:</span>
            <%= sms.TP_ID %>
        </p>
        <p>
            <span>TP Name:</span>
            <%= sms.TP_Name %>
        </p>
        <p>
            <span>Mobile:</span>
            <%= sms.Mobile_Number %>
        </p>
        <p>
            <span>Email:</span>
            <%= sms.Email %>
        </p>
        <p>
            <span>Send By</span>
            <%= sms.tbl_Users.User_Name %>
        </p>
        <p>
            <span>Language:</span>
            <%= sms.SMS_Language %>
        </p>
        <p>
            <span>SMS Response Code:</span>
            <%= sms.SMS_Code %>
        </p>
        <p>
            <span>SMS Response:</span>
            <%= sms.SMS_Code_Decode %>
        </p>
        <p>
            <span>Text:</span>
            <br />
            <%= sms.Text %>
        </p>
        <asp:Button ID="btnResend" runat="server" Text="Resend" OnClientClick="return confirm('Are you sure?')"
            CssClass="btn btn-success" OnClick="btnResend_Click" />
        <h3>
            <a href="Index.aspx">Back</a></h3>
    </fieldset>
    <fieldset>
        <legend>Events</legend>
        <asp:GridView ID="gvEvents" runat="server" ShowHeader="true" AutoGenerateColumns="false" EmptyDataText="No Records" CssClass="table table-bordered">
            <Columns>
                <asp:TemplateField HeaderText="Created At">
                    <ItemTemplate>
                        <asp:Label ID="lblCreatedAt" runat="server" Text='<%# Eval("Created_At") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Event">
                    <ItemTemplate>
                        <asp:Label ID="lblEvant" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
