using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class Admin_Users_New : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var userName = txtUserName.Text.Trim();
        if (_sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.User_Name == userName).FirstOrDefault() != null)
        {
            Session["ErrorMessage"] = "User with same user name already exists!";
            return;
        }
        var password = StringHelper.MD5Hash(txtPassword.Text.Trim());
        var currentTime = DateTime.Now ;
        var user = new tbl_Users { User_Name = userName, Password = password, Role = "Normal_User", Status = ddlStatus.SelectedValue, Sign_In_Count = 0, Created_At = currentTime, Updated_At = currentTime };
        _sms_EMAIL_DB_Entities.AddTotbl_Users(user);
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMEssage"] = "Successfully created a new user";
        Response.Redirect("Index.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}