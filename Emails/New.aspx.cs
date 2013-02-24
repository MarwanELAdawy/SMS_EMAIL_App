using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class Emails_New : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var currentUserId = CurrentUser.Id();
        var claimNumber = long.Parse(txtClaimNumber.Text);
        var email = new tbl_Emails_SMS { Claim_Number = claimNumber, Policy_Number = txtPolicyNumber.Text, TP_Name = txtTpName.Text, Email = txtEmail.Text, Text = txtText.Text, Type = "Email", User_Id = currentUserId, Created_At = DateTime.Now, Mobile_Number = txtMobile.Text, Email_Subject = txtSubject.Text };
        _sms_EMAIL_DB_Entities.AddTotbl_Emails_SMS(email);
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Successfully send an email !";
        Mailer.SendMailMessage(txtEmail.Text.ToString().Trim(), "", "", txtSubject.Text.ToString().Trim(), txtText.Text.ToString().Trim());
        Response.Redirect("Index.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}