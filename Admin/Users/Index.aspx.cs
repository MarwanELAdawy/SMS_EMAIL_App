using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.Data;

public partial class Admin_Users_Index : System.Web.UI.Page
{
    SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDataToGridView();
    }
    protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsers.PageIndex = e.NewPageIndex;
        BindDataToGridView();
    }

    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;

        LinkButton lb;
        lb = new LinkButton();
        lb.CommandArgument = e.Row.Cells[3].Text;
        lb.CommandName = "NumClick";
        lb.Text = "Edit";
        lb.PostBackUrl = "Edit.aspx?id=" + e.Row.Cells[3].Text;
        e.Row.Cells[3].Controls.Add((Control)lb);

        lb = new LinkButton();
        lb.CommandArgument = e.Row.Cells[4].Text;
        lb.CommandName = "NumClick";
        lb.Text = "Change Password";
        lb.PostBackUrl = "ChangePassword.aspx?id=" + e.Row.Cells[4].Text;
        e.Row.Cells[4].Controls.Add((Control)lb);
    }

    protected void BindDataToGridView()
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("Created At", typeof(string)));
        dt.Columns.Add(new DataColumn("User Name", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dt.Columns.Add(new DataColumn("Edit", typeof(string)));
        dt.Columns.Add(new DataColumn("Change Password", typeof(string)));

        foreach (var x in _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.Role != "Admin").OrderBy(x => x.Created_At).ToList())
        {
            dr = dt.NewRow();
            dr["Created At"] = DateTimeHelper.ConvertToString(x.Created_At.ToString());
            dr["User Name"] = x.User_Name;
            dr["Status"] = x.Status;
            dr["Edit"] = x.Id;
            dr["Change Password"] = x.Id;
            dt.Rows.Add(dr);
        }

        gvUsers.DataSource = dt;
        gvUsers.DataBind();
    }
}