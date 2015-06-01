using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class admin_settings_housing_owner_data : BasePage
{
    private AdvertOwnerType currentAdvertOwnerType;
    public AdvertOwnerType CurrentAdvertOwnerType
    {
        get
        {
            if (currentAdvertOwnerType == default(AdvertOwnerType))
            {
                if (Request.QueryString["owner"] != null)
                {
                    currentAdvertOwnerType = DBProvider.GetAdvertOwnerTypeByObjectId(Convert.ToInt32(Request.QueryString["owner"]));
                }
                else
                {
                    currentAdvertOwnerType = null;
                }
            }
            return currentAdvertOwnerType;
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
        if (CurrentAdvertOwnerType != null)
        {
            tbTypeName.Text = CurrentAdvertOwnerType.TypeName;
            tbTypeKey.Text = CurrentAdvertOwnerType.TypeKey;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentAdvertOwnerType != null)
        {
            CurrentAdvertOwnerType.TypeName = tbTypeName.Text.Trim();
            CurrentAdvertOwnerType.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddAdvertOwnerType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}