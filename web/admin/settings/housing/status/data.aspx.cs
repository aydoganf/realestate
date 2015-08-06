using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_status_data : BasePage
{
    private AdvertStatus currentAdvertStatus;
    public AdvertStatus CurrentAdvertStatus
    {
        get
        {
            if (currentAdvertStatus == default(AdvertStatus))
            {
                if (Request.QueryString["status"] != null)
                {
                    currentAdvertStatus = DBProvider.GetAdvertStatusByObjectId(Convert.ToInt32(Request.QueryString["status"]));
                }
                else
                {
                    currentAdvertStatus = null;
                }
            }
            return currentAdvertStatus;
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
        if (CurrentAdvertStatus != null)
        {
            tbTypeName.Text = CurrentAdvertStatus.TypeName;
            tbTypeKey.Text = CurrentAdvertStatus.TypeKey;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentAdvertStatus != null)
        {
            CurrentAdvertStatus.TypeName = tbTypeName.Text.Trim();
            CurrentAdvertStatus.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddAdvertStatus(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}