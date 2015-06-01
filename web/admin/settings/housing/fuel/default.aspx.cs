using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class admin_settings_housing_fuel_default : BasePage
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
        rptFuel.DataSource = DBProvider.GetFuelTypeList();
        rptFuel.DataBind();
    }
    protected void rptFuel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int fuelId = Convert.ToInt32(e.CommandArgument);
            FuelType obj = DBProvider.GetFuelTypeByObjectId(fuelId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}