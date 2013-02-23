using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class Admin_Users_ChangePassword : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            hdnUserId.Value = Request.QueryString["id"];
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var userId = int.Parse(hdnUserId.Value);
        var password = StringHelper.MD5Hash(txtPassword.Text.Trim());
        var user = _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.Id == userId).First();
        user.Password = password;
        user.Updated_At = DateTime.Now;
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Successfully changed password!";
        Response.Redirect("Index.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}