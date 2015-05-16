using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_marketing_data : BasePage
{
    private MarketingType currentMarketingType;

    public MarketingType CurrentMarketingType
    {
        get 
        {
            if (currentMarketingType == default(MarketingType))
            {
                if (Request.QueryString["marketing"] != null)
                {
                    currentMarketingType = DBProvider.GetMarketingTypeByObjectId(Convert.ToInt32(Request.QueryString["marketing"]));
                }
                else
                {
                    currentMarketingType = null;
                }
            }
            return currentMarketingType; 
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
        if (CurrentMarketingType != null)
        {
            tbTypeName.Text = CurrentMarketingType.TypeName;
            tbTypeKey.Text = CurrentMarketingType.TypeKey;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentMarketingType != null)
        {
            CurrentMarketingType.TypeName = tbTypeName.Text.Trim();
            CurrentMarketingType.TypeKey = tbTypeKey.Text.Trim();            
        }
        else
        {
            DBProvider.AddMarketingType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}