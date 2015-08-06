using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_address_town_default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCityList.DataSource = DBProvider.GetCityList();
            ddlCityList.DataBind();

            BindData();
        }
    }

    protected void BindData()
    {
        rptTown.DataSource = DBProvider.GetTownListByCityObjectId(Convert.ToInt32(ddlCityList.SelectedValue));
        rptTown.DataBind();
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void rptTown_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int townId = Convert.ToInt32(e.CommandArgument);
            Town town = DBProvider.GetTownByObjectId(townId);

            if (town != null)
                town.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}