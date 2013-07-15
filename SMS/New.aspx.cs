﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.Text.RegularExpressions;
using System.Data;

public partial class SMS_New : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    protected tbl_Templates tpl;
    protected long id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDdl();
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        var phoneNumber = "966" + txtMobile.Text.Trim();
        //id = long.Parse(ddlTemplate.SelectedValue);
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        //tpl = _sms_EMAIL_DB_Entities.tbl_Templates.Where(x => x.Id == id).First();
        //var message =  tpl.Text.Trim();
        var message = txtText.Text.ToString().Trim();
        //var unicode = tpl.Language == "English" ? "E" : "U";
        var unicode = rblSMSLanguage.SelectedValue == "English" ? "E" : "U";
        if (unicode == "U")
        {
            //message = StringHelper.StringToHexCode(message);
        }

        MyWebRequest myRequest = new MyWebRequest("http://www.jawalbsms.ws/api.php/sendsms?", "POST", "user=acig111&pass=1234&to=" + phoneNumber + "&message=" + message + "&sender=Acig");

        var sms_code = myRequest.GetResponse();
        var sms_code_decode = StringHelper.ConvertResponseCode(sms_code);

        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var currentUserId = CurrentUser.Id();
        var email = new tbl_Emails_SMS { 
            Claim_Number = txtClaimNumber.Text,
            Policy_Number = txtPolicyNumber.Text,
            TP_Name = txtTpName.Text,
            Email = txtEmail.Text,
            Mobile_Number = phoneNumber, 
            Text = txtText.Text,
            //Text = tpl.Text,
            Type = "SMS",
            SMS_Code = sms_code, 
            SMS_Code_Decode = sms_code_decode,
            //SMS_Language = tpl.Language,
            SMS_Language = rblSMSLanguage.SelectedValue,
            User_Id = currentUserId,
            Created_At = DateTime.Now,
            TP_ID = txtTPID.Text,
            TemplateId = id
        };
        _sms_EMAIL_DB_Entities.AddTotbl_Emails_SMS(email);
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Please check SMS status !";

        Response.Redirect("Index.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }


    private void BindCategories(object sender, EventArgs e)
    {
    }

    protected void BindDdl()
    {
        //_sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        //var lst = _sms_EMAIL_DB_Entities.tbl_Templates.OrderByDescending(x => x.CreatedAt).ToList();
        //DataTable table = new DataTable();
        //table.Columns.Add("Text");
        //table.Columns.Add("Value");
        //DataRow dr;
        //dr = table.NewRow();
        //dr["Text"] = "Select";
        //dr["Value"] = "0";
        //table.Rows.Add(dr);
        //foreach (var x in lst)
        //{
        //    dr = table.NewRow();
        //    dr["Text"] = x.Text;
        //    dr["Value"] = x.Id;
        //    table.Rows.Add(dr);
        //}
        //ddlTemplate.DataSource = table;
        //ddlTemplate.DataTextField = table.Columns["Text"].ColumnName;
        //ddlTemplate.DataValueField = table.Columns["Value"].ColumnName;
        //ddlTemplate.DataBind();
        //ddlTemplate.SelectedIndexChanged += new System.EventHandler(BindCategories);
    }
}