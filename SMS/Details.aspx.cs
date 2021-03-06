﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class SMS_Details : System.Web.UI.Page
{
    protected SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities;
    public tbl_Emails_SMS sms;
    tbl_Events tEvent;
    protected void Page_Load(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var smsId = long.Parse(Request.QueryString["id"]);
        if (CurrentUser.Role() == "Admin")
        {
            sms = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Id == smsId).First();
        }
        else
        {
            var currentUserId = CurrentUser.Id();
            sms = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Id == smsId).Where(x => x.User_Id == currentUserId).FirstOrDefault();
            if (sms == null)
            {
                Response.Redirect("NotAuthorized.aspx");
                return;
            }
        }
        hdnFldSMSId.Value = smsId.ToString();
        btnResend.Visible = sms.SMS_Code_Decode != "Success";
        gvEvents.DataSource = sms.tbl_Events;
        gvEvents.DataBind();
    }

    protected void btnResend_Click(object sender, EventArgs e)
    {
        _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var smsId = long.Parse(hdnFldSMSId.Value);
        sms = _sms_EMAIL_DB_Entities.tbl_Emails_SMS.Where(x => x.Id == smsId).First();
        var phone = sms.Mobile_Number;
        var message = sms.Text;
        var sms_code = SmsSender.Send(phone, message);
        var sms_code_decode = StringHelper.ConvertResponseCode(sms_code);
        sms.SMS_Code = sms_code;
        sms.SMS_Code_Decode = sms_code_decode;
        sms.SMS_Sent_At = DateTime.Now;
        _sms_EMAIL_DB_Entities.SaveChanges();
        tEvent = new tbl_Events {
            Created_At = DateTime.Now,
            Code = sms_code,
            Status = sms_code_decode,
            Email_Sms_Id = sms.Id
        };
        _sms_EMAIL_DB_Entities.AddTotbl_Events(tEvent);
        _sms_EMAIL_DB_Entities.SaveChanges();
        Session["NoticeMessage"] = "Please check SMS status !";
        Response.Redirect("Details.aspx?id=" + smsId.ToString());
    }

}