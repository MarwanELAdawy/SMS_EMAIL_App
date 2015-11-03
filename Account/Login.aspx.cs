using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            errorDiv.Visible = false;
        }
        if (User.Identity.IsAuthenticated && Request.QueryString["ReturnUrl"] != null)
        {
            Response.Redirect("/SMS_EMAIL_App/NotAuthorized.aspx");
        }
        else if (User.Identity.IsAuthenticated)
        {
            Response.Redirect(CurrentUser.GetRedirectPath(CurrentUser.Role()));
        } 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SMS_EMAIL_DB_Entities _sms_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        var password = StringHelper.MD5Hash(txtPassword.Text.ToString());
        tbl_Users user = _sms_EMAIL_DB_Entities.tbl_Users.Where(x => x.User_Name == txtUserName.Text).Where(x => x.Password == password && x.Status == "Active").FirstOrDefault();
        if (user == null)
        {
            errorDiv.Visible = true;
            return;
        }
        FormsAuthentication.SetAuthCookie(user.User_Name, false);
        FormsAuthenticationTicket ticket1 =
           new FormsAuthenticationTicket(
                1,                                   // version
                user.User_Name,   // get username  from the form
                DateTime.Now,                        // issue time is now
                DateTime.Now.AddHours(11),         // expires in 10 minutes
                false,      // cookie is not persistent
                user.Role + "#" + user.Id.ToString()    // role assignment is stored
                );
        HttpCookie cookie1 = new HttpCookie(
          FormsAuthentication.FormsCookieName,
          FormsAuthentication.Encrypt(ticket1));
        Response.Cookies.Add(cookie1);
        
        int? count = user.Sign_In_Count.Equals(String.Empty) ? 0 : user.Sign_In_Count;
        user.Sign_In_Count = count + 1;
        user.Last_Sign_In_At = DateTime.Now;
        _sms_EMAIL_DB_Entities.SaveChanges();
        String returnUrl1 = "";
        if (Request.QueryString["ReturnUrl"] != null)
        {
            returnUrl1 = Request.QueryString["ReturnUrl"];
        }
        else
        {
            returnUrl1 = CurrentUser.GetRedirectPath(user.Role);
        }
        Session["NoticeMessage"] = "Successfully logged in !";
        Response.Redirect(returnUrl1);
    }
}
