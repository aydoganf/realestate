using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_housing_heating_default : BasePage
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
        rptHeating.DataSource = DBProvider.GetHeatingTypeList();
        rptHeating.DataBind();
    }

    protected void rptHeating_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int heatingId = Convert.ToInt32(e.CommandArgument);
            HeatingType obj = DBProvider.GetHeatingTypeByObjectId(heatingId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}