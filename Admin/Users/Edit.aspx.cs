using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class Admin_Users_Edit : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
            hdnUserId.Value = Request.QueryString["id"];
            var userId = int.Parse(hdnUserId.Value);
            var user = _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.Id == userId).Where(x => x.Role != "Admin").FirstOrDefault();
            if (user == null) {
                Session["ErrorMessage"] = "You are not authorizrd to acces this user!";
                Response.Redirect("Index.aspx");
                return;
            }
            txtUserName.Text = user.User_Name;
            ddlStatus.SelectedValue = user.Status;
            hdnCurrentUserName.Value = user.User_Name;
            ckbSearch.Checked = user.Can_Search;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var userName = txtUserName.Text.Trim();
        if (hdnCurrentUserName.Value != txtUserName.Text.Trim()) {
            var count = _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.User_Name == userName).Count();
            if (count > 0) {
                Session["ErrorMessage"] = "User with the user name already exists!";
                return;
            }
        }
        var userId = int.Parse(hdnUserId.Value);
        var user = _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.Id == userId).First();
        user.User_Name = userName;
        user.Status = ddlStatus.SelectedValue;
        user.Updated_At = DateTime.Now;
        user.Can_Search = ckbSearch.Checked;
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Successfully updated the user!";
        Response.Redirect("index.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}