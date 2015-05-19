using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_estatetype_data : BasePage
{
    private EstateType currentEstateType;

    public EstateType CurrentEstateType
    {
        get
        {
            if (currentEstateType == default(EstateType))
            {
                if (Request.QueryString["estatetype"] != null)
                {
                    currentEstateType = DBProvider.GetEstateTypeByObjectId(Convert.ToInt32(Request.QueryString["estatetype"]));
                }
                else
                {
                    currentEstateType = null;
                }
            }
            return currentEstateType;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        ddlEstateTypeList.DataSource = DBProvider.GetEstateTypeList();
        ddlEstateTypeList.DataBind();
        ddlEstateTypeList.Items.Insert(0, new ListItem("Üst tip yok", ""));

        if (CurrentEstateType != null)
        {
            tbTypeName.Text = CurrentEstateType.TypeName;
            tbTypeKey.Text = CurrentEstateType.TypeKey;
            ddlEstateTypeList.SelectedValue = CurrentEstateType.ParentEstateTypeObjectId.HasValue ? CurrentEstateType.ParentEstateTypeObjectId.ToString() : "";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int? parentEstateTypeId = null;
        if (ddlEstateTypeList.SelectedValue != "")
        {
            parentEstateTypeId = Convert.ToInt32(ddlEstateTypeList.SelectedValue);
        }

        if (CurrentEstateType != null)
        {
            CurrentEstateType.TypeName = tbTypeName.Text.Trim();
            CurrentEstateType.TypeKey = tbTypeKey.Text.Trim();
            CurrentEstateType.ParentEstateTypeObjectId = parentEstateTypeId;
        }
        else
        {
            DBProvider.AddEstateType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim(), parentEstateTypeId);
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}