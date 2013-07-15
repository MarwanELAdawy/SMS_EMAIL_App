using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class Emails_Details : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    public tbl_Emails_SMS email;
    protected void Page_Load(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var emailId = long.Parse(Request.QueryString["id"]);
        if(CurrentUser.Role() == "Admin"){
            email = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Id == emailId).First();
        } else{
            var currentUserId = CurrentUser.Id();
            email = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Id == emailId).Where(x => x.User_Id == currentUserId).FirstOrDefault();
            if (email == null) {
                Response.Redirect("NotAuthorized.aspx");
                return;
            }
        }
    }
}