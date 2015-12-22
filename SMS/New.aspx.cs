using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.Text.RegularExpressions;
using System.Data;

public partial class SMS_New : System.Web.UI.Page
{
    SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    tbl_Templates tpl;
    tbl_Events tEvent;
    tbl_Emails_SMS email;
    long id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            duplicateSmsDiv.Visible = false;
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var phoneNumber = "966" + txtMobile.Text.Trim();
            //id = long.Parse(ddlTemplate.SelectedValue);
            using (_sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities())
            {
                var count = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Mobile_Number == phoneNumber).Count();
                if (count == 0)
                {
                    sendSMS(phoneNumber);
                    Response.Redirect("Index.aspx");
                    return;
                }
            }
            btnSend.Visible = false;
            duplicateSmsDiv.Visible = true;
        }
    }

    protected void btnSendDuplicate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var phoneNumber = "966" + txtMobile.Text.Trim();
            using (_sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities())
            {
                sendSMS(phoneNumber);
            }
            Response.Redirect("Index.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }

    void sendSMS(string phoneNumber)
    {
        var message = txtText.Text.ToString().Trim();
        var unicode = rblSMSLanguage.SelectedValue == "English" ? "E" : "U";
        var sms_code = SmsSender.Send(phoneNumber, message);
        var sms_code_decode = StringHelper.ConvertResponseCode(sms_code);

        var currentUserId = CurrentUser.Id();
        email = new tbl_Emails_SMS
        {
            Claim_Number = txtClaimNumber.Text,
            Policy_Number = txtPolicyNumber.Text,
            TP_Name = txtTpName.Text,
            Email = txtEmail.Text,
            Mobile_Number = phoneNumber,
            Text = message,
            //Text = tpl.Text,
            Type = "SMS",
            SMS_Code = sms_code,
            SMS_Code_Decode = sms_code_decode,
            //SMS_Language = tpl.Language,
            SMS_Language = rblSMSLanguage.SelectedValue,
            User_Id = currentUserId,
            Created_At = DateTime.Now,
            SMS_Sent_At = DateTime.Now,
            TP_ID = txtTPID.Text,
            Template_Id = id
        };
        _sms_EMAIL_DB_Entities.AddTotbl_Emails_SMS(email);
        _sms_EMAIL_DB_Entities.SaveChanges();
        tEvent = new tbl_Events
        {
            Created_At = DateTime.Now,
            Code = sms_code,
            Status = sms_code_decode,
            Email_Sms_Id = email.Id
        };
        _sms_EMAIL_DB_Entities.AddTotbl_Events(tEvent);
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Please check SMS status !";
    }
}