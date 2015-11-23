using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using SMS_EMAIL_DB_Model;
using System.Web.Security;

public class MasterApp : DdlBinding
{
    protected string _fileName, _filePath;
    protected void ErrorRedirect(string path, string message)
    {
        Session["ErrorMessage"] = message;
        Response.Redirect(path);
    }

    protected void SuccessRedirect(string path, string message)
    {
        Session["NoticeMessage"] = message;
        Response.Redirect(path);
    }

    protected void AssignUserId()
    {
        if (_userId == 0)
        {
            _userId = CurrentUser.Id();
        }
    }

    protected void AssignCurrentDateTime()
    {
        _currentDateTime = DateTime.Now;
    }

    protected void AssignUserIdAndCurrentDateTime()
    {
        AssignUserId();
        AssignCurrentDateTime();
    }

    protected string SetLogin(tbl_Users user)
    {
        FormsAuthentication.SetAuthCookie(user.User_Name, false);
        FormsAuthenticationTicket ticket1 =
           new FormsAuthenticationTicket(
                1,                                   // version
                user.User_Name,   // get username  from the form
                DateTime.Now,                        // issue time is now
                DateTime.Now.AddHours(11),         // expires in 10 minutes
                false,      // cookie is not persistent
                user.Role + "#" + user.Id.ToString()
                );
        HttpCookie cookie1 = new HttpCookie(
          FormsAuthentication.FormsCookieName,
          FormsAuthentication.Encrypt(ticket1));
        Response.Cookies.Add(cookie1);
        string returnUrl = CurrentUser.GetRedirectPath(user.Role);
        return returnUrl;
    }

    protected void SetLogout()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
        cookie1.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie1);
        HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
        cookie2.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie2);
        FormsAuthentication.RedirectToLoginPage();
    }

    protected void TransmitFile()
    {
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/plain";
        response.AddHeader("Content-Disposition", "attachment; filename=" + _fileName + ";");
        response.TransmitFile(_filePath);
        response.Flush();
        response.End();
    }

    protected string GetFilePath(string type)
    {
        //return FileHelper.GetFolderPath(type) + @"\\" + _fileName;
        return string.Empty;
    }

    protected string ConfigAdmin()
    {
        return ConfigurationManager.AppSettings["AdminEmail"].ToString();
    }
}