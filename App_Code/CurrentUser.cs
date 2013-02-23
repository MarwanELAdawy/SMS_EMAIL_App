using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SMS_EMAIL_DB_Model;

/// <summary>
/// Summary description for CurrentUser
/// </summary>
public static class CurrentUser
{
	public static int Id() {
        var cookie = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
        //return int.Parse(HttpContext.Current.Session["currentUserId"].ToString());
        return int.Parse(cookie.Split('#')[1].ToString());
    }

    public static string Role() {
        var cookie = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
        return cookie.Split('#')[0];
    }

    public static string GetRedirectPath(string role) {
        String returnUrl1 = "";
        if (role == "Admin")
        {
            returnUrl1 = "/SMS_EMAIL_App/Admin/Users/Index.aspx";
        }
        else if (role == "Normal_User")
        {
            returnUrl1 = "/SMS_EMAIL_App/Emails/Index.aspx";
        }
        return returnUrl1;
    }


    public static tbl_Users DBUser() {
        SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var currentUserId = CurrentUser.Id();
        var user = _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.Id == currentUserId).First();
        return user;
    }
}