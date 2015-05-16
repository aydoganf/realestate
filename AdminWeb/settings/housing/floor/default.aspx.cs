using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_housing_floor_default : BasePage
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
        rptFloor.DataSource = DBProvider.GetFloorList();
        rptFloor.DataBind();
    }

    protected void rptFloor_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int floor = Convert.ToInt32(e.CommandArgument);
            Floor obj = DBProvider.GetFloorByObjectId(floor);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}