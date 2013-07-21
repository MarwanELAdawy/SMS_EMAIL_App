using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.Data;

public partial class SMS_Index : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataToGridView();
            BindSearchFieldDdl();
            UpdateTextBoxAndRfv(false, false);
        }
    }
    protected void gvSMS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSMS.PageIndex = e.NewPageIndex;
        BindDataToGridView();
    }
    protected void gvSMS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;
        LinkButton lb;
        lb = new LinkButton();
        lb.CausesValidation = false;
        lb.CommandArgument = e.Row.Cells[4].Text;
        lb.CommandName = "NumClick";
        lb.Text = "Details";
        lb.PostBackUrl = "Details.aspx?id=" + e.Row.Cells[4].Text;
        e.Row.Cells[4].Controls.Add((Control)lb);
    }

    protected void BindDataToGridView()
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("Sent At", typeof(string)));
        dt.Columns.Add(new DataColumn("Sent To", typeof(string)));
        dt.Columns.Add(new DataColumn("Sent By", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dt.Columns.Add(new DataColumn("Details", typeof(string)));

        IQueryable<tbl_Emails_SMS> ls;
        List<tbl_Emails_SMS> list;
        if (CurrentUser.Role() == "Admin")
        {
            ls = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Type == "SMS");
        }
        else
        {
            var currentUserId = CurrentUser.Id();
            ls = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Type == "SMS").Where(x => x.User_Id == currentUserId);
        }

        switch (ddlSearchField.SelectedValue)
        {
            case "Mobile Number":
                ls = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Mobile_Number.Contains(txtField.Text));
                break;
            case "Date":
                var date = txtSentDate.Text;
                var startDate = DateTime.Parse(date + " 00:00:00");
                var endDate = DateTime.Parse(date + " 23:59:59");
                ls = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.SMS_Sent_At >= startDate).Where(x => x.SMS_Sent_At <= endDate);
                break;
            case "Sent By":
                ls = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.tbl_Users.User_Name.Contains(txtField.Text));
                break;
            default: break;
        }
        list = ls.OrderByDescending(x => x.Created_At).ToList();

        foreach (var x in list)
        {
            dr = dt.NewRow();
            dr["Sent At"] = x.SMS_Sent_At.ToString();
            dr["Sent To"] = x.Mobile_Number;
            dr["Sent By"] = x.tbl_Users.User_Name;
            dr["Status"] = x.SMS_Code_Decode;
            dr["Details"] = x.Id;
            dt.Rows.Add(dr);
        }
        gvSMS.DataSource = dt;
        gvSMS.DataBind();
    }

    protected void BindSearchFieldDdl()
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        DataTable table = new DataTable();
        table.Columns.Add("Text");
        table.Columns.Add("Value");
        DataRow dr;
        List<string> lst = new List<string> { "None / All", "Mobile Number", "Date" };
        if (CurrentUser.Role() == "Admin")
        {
            lst.Add("Sent By");
        }
        foreach (var x in lst)
        {
            dr = table.NewRow();
            dr["Value"] = x;
            dr["Text"] = x;
            table.Rows.Add(dr);
        }
        ddlSearchField.DataSource = table;
        ddlSearchField.DataTextField = table.Columns["Text"].ColumnName;
        ddlSearchField.DataValueField = table.Columns["Value"].ColumnName;
        ddlSearchField.AutoPostBack = true;
        ddlSearchField.DataBind();
        ddlSearchField.SelectedIndexChanged += new System.EventHandler(BindCategories);
    }

    protected void ddlSearchField_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchField.SelectedValue == "None / All")
        {
            UpdateTextBoxAndRfv(false, false);
        }
        else if (ddlSearchField.SelectedValue == "Date")
        {
            UpdateTextBoxAndRfv(false, true);
        }
        else
        {
            UpdateTextBoxAndRfv(true, false);
        }
    }

    private void BindCategories(object sender, EventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindDataToGridView();
        gvUpdatePanel.Update();
    }

    protected void UpdateTextBoxAndRfv(bool first, bool second)
    {
        txtField.Visible = first;
        rfvField.Enabled = first;
        txtSentDate.Visible = second;
        rfvSentDate.Enabled = second;
    }
}