using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.Text.RegularExpressions;

public partial class SMS_New : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        var phoneNumber = "966" + txtMobile.Text.Trim();
        var message = txtText.Text.ToString().Trim();
        MyWebRequest myRequest = new MyWebRequest("http://www.jawalbsms.com/HttpSMSProvider.aspx", "POST", "username=acig111&password=1234&mobile="+phoneNumber+"&unicode=E&message="+message+"&sender=Acig");
        var sms_code = myRequest.GetResponse();
        var sms_code_decode = StringHelper.ConvertResponseCode(sms_code);
        
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var currentUserId = CurrentUser.Id();
        var claimNumber = long.Parse(txtClaimNumber.Text);
        var email = new tbl_Emails_SMS { Claim_Number = claimNumber, Policy_Number = txtPolicyNumber.Text, TP_Name = txtTpName.Text, Email = txtEmail.Text, Mobile_Number = phoneNumber, Text = txtText.Text, Type = "SMS", SMS_Code = sms_code, SMS_Code_Decode = sms_code_decode, SMS_Language = rblSMSLanguage.SelectedValue, User_Id = currentUserId, Created_At = DateTime.Now };
        _sms_EMAIL_DB_Entities.AddTotbl_Emails_SMS(email);
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Please check SMS status !";
        
        Response.Redirect("Index.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}