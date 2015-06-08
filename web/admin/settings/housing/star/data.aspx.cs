using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class admin_settings_housing_star_data : BasePage
{
    private StarCount currentStarCount;
    public StarCount CurrentStarCount
    {
        get
        {
            if (currentStarCount == default(StarCount))
            {
                if (Request.QueryString["star"] != null)
                {
                    currentStarCount = DBProvider.GetStarCountByObjectId(Convert.ToInt32(Request.QueryString["star"]));
                }
                else
                {
                    currentStarCount = null;
                }
            }
            return currentStarCount;
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
        if (CurrentStarCount != null)
        {
            tbTypeName.Text = CurrentStarCount.TypeName;
            tbTypeKey.Text = CurrentStarCount.TypeKey;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentStarCount != null)
        {
            CurrentStarCount.TypeName = tbTypeName.Text.Trim();
            CurrentStarCount.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddStarCount(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}