using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class SMS_New : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var currentUserId = CurrentUser.Id();
        var claimNumber = int.Parse(txtClaimNumber.Text);
        var email = new tbl_Emails_SMS { Claim_Number = claimNumber, Policy_Number = txtPolicyNumber.Text, TP_Name = txtTpName.Text, Email = txtEmail.Text, Mobile_Number = txtMobile.Text, Text = txtText.Text, Type = "SMS", User_Id = currentUserId, Created_At = DateTime.Now };
        _sms_EMAIL_DB_Entities.AddTotbl_Emails_SMS(email);
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Successfully send a SMS !";
        Response.Redirect("Index.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}