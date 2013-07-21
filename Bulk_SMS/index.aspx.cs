using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;
using System.IO;

public partial class Bulk_SMS_index : System.Web.UI.Page
{
    SMS_EMAIL_DB_Entities _SMS_EMAIL_DB_Entities;
    tbl_Bulk_SMS bulk_SMS;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        HttpPostedFile postedFile = Request.Files["smsFile"];
        if (postedFile == null || postedFile.ContentLength <= 0)
        {
            Session["ErrorMessage"] = "Please select a file";
            return;
        }
        var outputFile = FileHelper.SaveFile(postedFile);
        long tmpId = long.Parse(ddlTemplate.SelectedValue);
        int userId = CurrentUser.Id();
        _SMS_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        bulk_SMS = new tbl_Bulk_SMS
        {
            Created_At = DateTime.Now,
            File_Name = outputFile["FileName"].ToString(),
            File_Path = outputFile["FilePath"].ToString(),
            Status = "New",
            Updated_At = DateTime.Now,
            Template_Id = tmpId,
            User_Id = userId
        };
        _SMS_EMAIL_DB_Entities.AddTotbl_Bulk_SMS(bulk_SMS);
        _SMS_EMAIL_DB_Entities.SaveChanges();
        BindGridView();
    }

    protected void BindGridView()
    {
        _SMS_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        if (CurrentUser.Role() == "Admin")
        {
            var data = from bs in _SMS_EMAIL_DB_Entities.tbl_Bulk_SMS
                       join t in _SMS_EMAIL_DB_Entities.tbl_Templates
                       on bs.Template_Id equals t.Id
                       orderby bs.Created_At descending
                       select new
                       {
                           Id = bs.Id,
                           TemplateName = t.Name,
                           CreatedAt = bs.Created_At,
                           InputFileName = bs.File_Name,
                           InputFilePath = bs.File_Path,
                           OutputFilePath = bs.Output_File_Path,
                           OutputFileName = bs.Output_File_Name,
                           Visible = !string.IsNullOrEmpty(bs.Output_File_Path),
                           Status = bs.Status
                       };
            gvSMS.DataSource = data;
            gvSMS.DataBind();
        }
        else
        {
            var id = CurrentUser.Id();
            var data = from bs in _SMS_EMAIL_DB_Entities.tbl_Bulk_SMS
                       join t in _SMS_EMAIL_DB_Entities.tbl_Templates
                       on bs.Template_Id equals t.Id
                       where bs.User_Id == id
                       orderby bs.Created_At descending
                       select new
                       {
                           Id = bs.Id,
                           TemplateName = t.Name,
                           CreatedAt = bs.Created_At,
                           InputFileName = bs.File_Name,
                           InputFilePath = bs.File_Path,
                           OutputFilePath = bs.Output_File_Path,
                           OutputFileName = bs.Output_File_Name,
                           Visible = !string.IsNullOrEmpty(bs.Output_File_Path),
                           Status = bs.Status
                       };
            gvSMS.DataSource = data;
            gvSMS.DataBind();
        }
    }

    protected void lkBtnInputDownload_Click(object sender, EventArgs e)
    {
        var lkBtn = (LinkButton)sender;
        var id = long.Parse(lkBtn.CommandArgument.ToString());
        _SMS_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        bulk_SMS = _SMS_EMAIL_DB_Entities.tbl_Bulk_SMS.Where(x => x.Id == id).First();
        sendFile(bulk_SMS.File_Name, bulk_SMS.File_Path);
    }

    protected void lkBtnOutputDownload_Click(object sender, EventArgs e)
    {
        var lkBtn = (LinkButton)sender;
        var id = long.Parse(lkBtn.CommandArgument.ToString());
        _SMS_EMAIL_DB_Entities = new SMS_EMAIL_DB_Entities();
        bulk_SMS = _SMS_EMAIL_DB_Entities.tbl_Bulk_SMS.Where(x => x.Id == id).First();
        sendFile(bulk_SMS.Output_File_Name, bulk_SMS.Output_File_Path);
    }

    protected void sendFile(string FileName, string FilePath)
    {
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/plain";
        response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
        response.TransmitFile(FilePath);
        response.Flush();
        response.End();
    }
}