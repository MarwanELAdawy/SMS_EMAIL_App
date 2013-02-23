using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.Data;

public partial class Emails_Index : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDataToGridView();
    }
    protected void gvEmails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmails.PageIndex = e.NewPageIndex;
        BindDataToGridView();
    }
    protected void gvEmails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;
        LinkButton lb;
        lb = new LinkButton();
        lb.CommandArgument = e.Row.Cells[3].Text;
        lb.CommandName = "NumClick";
        lb.Text = "Details";
        lb.PostBackUrl = "Details.aspx?id=" + e.Row.Cells[3].Text;
        e.Row.Cells[3].Controls.Add((Control)lb);
    }

    protected void BindDataToGridView() {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("Sent At", typeof(string)));
        dt.Columns.Add(new DataColumn("Sent To", typeof(string)));
        dt.Columns.Add(new DataColumn("Sent By", typeof(string)));
        dt.Columns.Add(new DataColumn("Details", typeof(string)));

        List<tbl_Emails_SMS> list;
        if (CurrentUser.Role() == "Admin"){
            list = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Type == "Email").OrderByDescending(x => x.Created_At).ToList();
        }
        else {
            var currentUserId = CurrentUser.Id();
            list = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Type == "Email").Where(x => x.User_Id == currentUserId).OrderByDescending(x => x.Created_At).ToList();
        }

        foreach (var x in list)
        {
            dr = dt.NewRow();
            dr["Sent At"] = DateTimeHelper.ConvertToString(x.Created_At.ToString());
            dr["Sent To"] = x.Email;
            dr["Sent By"] = x.tbl_Users.User_Name;
            dr["Details"] = x.Id;
            dt.Rows.Add(dr);
        }

        gvEmails.DataSource = dt;
        gvEmails.DataBind();
    }

}