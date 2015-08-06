using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_using_data : BasePage
{
    private AdvertUsingType currentAdvertUsingType;
    public AdvertUsingType CurrentAdvertUsingType
    {
        get
        {
            if (currentAdvertUsingType == default(AdvertUsingType))
            {
                if (Request.QueryString["using"] != null)
                {
                    currentAdvertUsingType = DBProvider.GetAdvertUsingTypeByObjectId(Convert.ToInt32(Request.QueryString["using"]));
                }
                else
                {
                    currentAdvertUsingType = null;
                }
            }
            return currentAdvertUsingType;
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
        if (CurrentAdvertUsingType != null)
        {
            tbTypeName.Text = CurrentAdvertUsingType.TypeName;
            tbTypeKey.Text = CurrentAdvertUsingType.TypeKey;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentAdvertUsingType != null)
        {
            CurrentAdvertUsingType.TypeName = tbTypeName.Text.Trim();
            CurrentAdvertUsingType.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddAdvertUsingType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}