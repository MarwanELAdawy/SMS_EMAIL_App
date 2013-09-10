using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public partial class Admin_Templates_index : System.Web.UI.Page
{
    SMS_EMAIL_DB_Entities entity;
    tbl_Templates tmp;
    long Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    protected void AddNewTemplate(object sender, EventArgs e)
    {
        entity = new SMS_EMAIL_DB_Entities();
        tmp = new tbl_Templates();
        tmp.Type = ddlNewType.SelectedValue;
        tmp.Name = txtNewName.Text;
        tmp.Text = txtTextNew.Text;
        tmp.Created_At = DateTime.Now;
        tmp.Updated_At = DateTime.Now;
        entity.AddTotbl_Templates(tmp);
        entity.SaveChanges();
        BindGridView();
    }

    protected void EditTemplate(object sender, GridViewEditEventArgs e)
    {
        gvTemplates.EditIndex = e.NewEditIndex;
        BindGridView();
        var ddl = ((DropDownList)gvTemplates.Rows[e.NewEditIndex].FindControl("ddlType"));
        ddl.SelectedValue = ((HiddenField)gvTemplates.Rows[e.NewEditIndex].FindControl("hdnFldType")).Value;
    }
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTemplates.EditIndex = -1;
        BindGridView();
    }
    protected void UpdateTemplate(object sender, GridViewUpdateEventArgs e)
    {
        Id = long.Parse(((HiddenField)gvTemplates.Rows[e.RowIndex].FindControl("hdnFldId")).Value);
        entity = new SMS_EMAIL_DB_Entities();
        tmp = entity.tbl_Templates.Where(x => x.Id == Id).First();
        tmp.Type = ((DropDownList)gvTemplates.Rows[e.RowIndex].FindControl("ddlType")).Text;
        tmp.Name = ((TextBox)gvTemplates.Rows[e.RowIndex].FindControl("txtName")).Text;
        tmp.Text = ((TextBox)gvTemplates.Rows[e.RowIndex].FindControl("txtText")).Text;
        tmp.Updated_At = DateTime.Now;
        entity.SaveChanges();
        gvTemplates.EditIndex = -1;
        BindGridView();
    }

    protected void BindGridView()
    {
        entity = new SMS_EMAIL_DB_Entities();
        gvTemplates.DataSource = entity.tbl_Templates.ToList();
        gvTemplates.DataBind();
    }
}