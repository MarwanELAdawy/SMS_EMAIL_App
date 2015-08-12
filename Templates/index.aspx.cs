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
    Label _lblError;
    string _type, _text;
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
        _text = txtTextNew.Text;
        if (ddlNewType.SelectedValue == "BULK_SMS_DYNAMIC" && !_text.Contains("{variable}"))
        {
            lblErrorN.Visible = true;
            return;
        }
        lblErrorN.Visible = false;
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
        txtNewName.Text = string.Empty;
        txtTextNew.Text = string.Empty;
        ddlNewType.SelectedValue = "SMS";
    }

    protected void EditTemplate(object sender, GridViewEditEventArgs e)
    {
        gvTemplates.EditIndex = e.NewEditIndex;
        BindGridView();
        var ddl = ((DropDownList)gvTemplates.Rows[e.NewEditIndex].FindControl("ddlType"));
        _type = ((HiddenField)gvTemplates.Rows[e.NewEditIndex].FindControl("hdnFldType")).Value;
        ddl.SelectedValue = _type;
    }
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTemplates.EditIndex = -1;
        BindGridView();
    }
    protected void UpdateTemplate(object sender, GridViewUpdateEventArgs e)
    {
        _text = ((TextBox)gvTemplates.Rows[e.RowIndex].FindControl("txtText")).Text;
        _lblError = gvTemplates.Rows[e.RowIndex].FindControl("lblError") as Label;
        var ddl = ((DropDownList)gvTemplates.Rows[e.RowIndex].FindControl("ddlType"));
        if (ddl.SelectedValue == "BULK_SMS_DYNAMIC" && !_text.Contains("{variable}"))
        {
            _lblError.Visible = true;
            return;
        }
        _lblError.Visible = false;
        Id = long.Parse(((HiddenField)gvTemplates.Rows[e.RowIndex].FindControl("hdnFldId")).Value);
        entity = new SMS_EMAIL_DB_Entities();
        tmp = entity.tbl_Templates.Where(x => x.Id == Id).First();
        tmp.Type = ddl.SelectedValue;
        tmp.Name = ((TextBox)gvTemplates.Rows[e.RowIndex].FindControl("txtName")).Text;
        tmp.Text = _text;
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