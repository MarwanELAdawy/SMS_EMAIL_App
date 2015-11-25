using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using SMS_EMAIL_DB_Model;

public class DdlBinding : System.Web.UI.Page
{
    protected int _userId;
    protected DateTime _currentDateTime;
    protected SMS_EMAIL_DB_Entities _entity;
    static TextValue objTV;
    static List<TextValue> lstTV;
    DataTable _objDataTable;
    DataRow _objDataRow;
    protected SMS_EMAIL_DB_Entities GetEntity()
    {
        _entity = new SMS_EMAIL_DB_Entities();
        return _entity;
    }

    private void BindCategoriesRoot(object sender, EventArgs e)
    {
    }

    protected void BindDDlRoot(DropDownList ddlRoot, bool includeSelect = true, RadioButtonList rbl = null)
    {
        _objDataTable = new DataTable();
        _objDataTable.Columns.Add("Text");
        _objDataTable.Columns.Add("Value");
        if (includeSelect)
        {
            _objDataRow = _objDataTable.NewRow();
            _objDataRow["Text"] = "Select";
            _objDataRow["Value"] = "0";
            _objDataTable.Rows.Add(_objDataRow);
        }
        foreach (var x in lstTV)
        {
            _objDataRow = _objDataTable.NewRow();
            _objDataRow["Text"] = x.Text;
            _objDataRow["Value"] = x.Value;
            _objDataTable.Rows.Add(_objDataRow);
        }
        ddlRoot.DataSource = _objDataTable;
        ddlRoot.DataTextField = _objDataTable.Columns["Text"].ColumnName;
        ddlRoot.DataValueField = _objDataTable.Columns["Value"].ColumnName;
        ddlRoot.DataBind();
        ddlRoot.SelectedIndexChanged += new System.EventHandler(BindCategoriesRoot);
    }

    protected void BindDdlUsersRoot(DropDownList ddlRoot, bool active = true)
    {
        using (_entity = GetEntity())
        {
            var data = from u in _entity.tbl_Users
                       //where u.Status == "Active"
                       orderby u.User_Name
                       select new
                       {
                           Name = u.User_Name,
                           Id = u.Id,
                           Role = u.Role
                       };
            lstTV = new List<TextValue>();
            foreach (var x in data)
            {
                objTV = new TextValue { Text = x.Name, Value = x.Id.ToString() };
                lstTV.Add(objTV);
            }
        }
        BindDDlRoot(ddlRoot);
    }
}