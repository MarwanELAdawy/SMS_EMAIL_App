﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMS_EMAIL_DB_Model;

public partial class SMS_search : MasterApp
{
    string _mobileNumber;
    int _searchUserId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CurrentUser.CanSearch())
        {
            Response.Redirect("index.aspx");
            return;
        }
        if (!IsPostBack)
        {
            BindDdlUsersRoot(ddlUser);
        }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
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
        _searchUserId = int.Parse(ddlUser.SelectedValue);
        using (_entity = GetEntity())
        {
            var _data = from s in _entity.tbl_Emails_SMS
                        join u in _entity.tbl_Users
                        on s.User_Id equals u.Id
                        orderby s.Created_At descending
                        select new
                        {
                            Sent_At = s.SMS_Sent_At,
                            Sent_To = s.Mobile_Number,
                            Text = s.Text,
                            Sent_By = u.User_Name,
                            Sent_By_Id = u.Id,
                            Status = s.SMS_Code_Decode
                        };
            if (_searchUserId != 0)
            {
                _data = _data.Where(x => x.Sent_By_Id == _searchUserId);
            }
            if (!string.IsNullOrEmpty(_mobileNumber))
            {
                _data = _data.Where(x => x.Sent_To.Contains(_mobileNumber));
            }
            gvSMS.DataSource = _data;
            gvSMS.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindDataToGridView();
        gvUpdatePanel.Update();
    }
}