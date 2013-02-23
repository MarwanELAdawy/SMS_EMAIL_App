using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var currentUserId = CurrentUser.Id();
        string currentPassword = StringHelper.MD5Hash(txtCurrentPassword.Text.Trim());
        var user = _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.Id == currentUserId).First();
        if (currentPassword != user.Password) {
            Session["ErrorMessage"] = "You current password is in correct!";
            return;
        }
        var password = StringHelper.MD5Hash(txtPassword.Text.Trim());
        user.Password = password;
        user.Updated_At = DateTime.Now;
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Successfully changed your password!";
        Response.Redirect(CurrentUser.GetRedirectPath(CurrentUser.Role()));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(CurrentUser.GetRedirectPath(CurrentUser.Role()));
    }
}