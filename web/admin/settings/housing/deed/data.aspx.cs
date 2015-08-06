using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_deed_data : BasePage
{
    private DeedType currentDeedType;
    public DeedType CurrentDeedType
    {
        get
        {
            if (currentDeedType == default(DeedType))
            {
                if (Request.QueryString["deed"] != null)
                {
                    currentDeedType = DBProvider.GetDeedTypeByObjectId(Convert.ToInt32(Request.QueryString["deed"]));
                }
                else
                {
                    currentDeedType = null;
                }
            }
            return currentDeedType;
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
        if (CurrentDeedType != null)
        {
            tbTypeName.Text = CurrentDeedType.TypeName;
            tbTypeKey.Text = CurrentDeedType.TypeKey;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentDeedType != null)
        {
            CurrentDeedType.TypeName = tbTypeName.Text.Trim();
            CurrentDeedType.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddDeedType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}