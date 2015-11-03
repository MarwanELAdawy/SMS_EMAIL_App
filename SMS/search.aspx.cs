using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMS_EMAIL_DB_Model;

public partial class SMS_search : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    string _mobileNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CurrentUser.CanSearch())
        {
            Response.Redirect("index.aspx");
            return;
        }
        if (!IsPostBack)
        {
            BindDataToGridView();
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
    }

    protected void BindDataToGridView()
    {
        _mobileNumber = txtMobileNumber.Text.Trim();
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("Sent At", typeof(string)));
        dt.Columns.Add(new DataColumn("Text", typeof(string)));
        dt.Columns.Add(new DataColumn("Sent To", typeof(string)));
        dt.Columns.Add(new DataColumn("Sent By", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));

        var _data = from s in _sms_EMAIL_DB_Entities.tbl_Emails_SMS
                    join u in _sms_EMAIL_DB_Entities.tbl_Users
                    on s.User_Id equals u.Id
                    where s.Mobile_Number.Contains(_mobileNumber)
                    orderby s.Created_At descending
                    select new
                    {
                        Sent_At = s.SMS_Sent_At,
                        Sent_To = s.Mobile_Number,
                        Message = s.Text,
                        Sent_By = u.User_Name,
                        Status = s.SMS_Code_Decode
                    };


        foreach (var x in _data)
        {
            dr = dt.NewRow();
            dr["Sent At"] = x.Sent_At.ToString();
            dr["Sent To"] = x.Sent_To;
            dr["Sent By"] = x.Sent_By;
            dr["Text"] = x.Message;
            dr["Status"] = x.Status;
            dt.Rows.Add(dr);
        }
        gvSMS.DataSource = dt;
        gvSMS.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindDataToGridView();
        gvUpdatePanel.Update();
    }
}