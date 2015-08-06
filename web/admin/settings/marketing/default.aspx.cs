using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_marketing_default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        rptMarketing.DataSource = DBProvider.GetMarketingTypeList();
        rptMarketing.DataBind();
    }
    protected void rptMarketing_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int marketingId = Convert.ToInt32(e.CommandArgument);
            MarketingType obj = DBProvider.GetMarketingTypeByObjectId(marketingId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}