using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_housing_extra_default : BasePage
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
        rptExtra.DataSource = DBProvider.GetFeatureList();
        rptExtra.DataBind();
    }

    protected void rptExtra_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int featureId = Convert.ToInt32(e.CommandArgument);
            Feature obj = DBProvider.GetFeatureByObjectId(featureId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}