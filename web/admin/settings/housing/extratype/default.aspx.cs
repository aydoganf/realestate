using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_extratype_default : BasePage
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
        rptExtraType.DataSource = DBProvider.GetFeatureTypeList();
        rptExtraType.DataBind();
    }

    protected void rptExtraType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int featureTypeId = Convert.ToInt32(e.CommandArgument);
            FeatureType obj = DBProvider.GetFeatureTypeByObjectId(featureTypeId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}