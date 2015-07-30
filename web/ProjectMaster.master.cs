using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProjectMaster : MasterBasePage
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
        ddlCity.DataSource = DBProvider.GetCityList();
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Tüm şehirler", "-1"));

        ddlCity.SelectedValue = "100";
        pnlTownLocationSearch.Visible = true;

        lbTown.DataSource = DBProvider.GetTownListByCityObjectId(100);
        lbTown.DataBind();

        rptLastProperties.DataSource = DBProvider.GetMostRecentAdvertList(3);
        rptLastProperties.DataBind();
    }


    #region Dropdown Events
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cityId = Convert.ToInt32(ddlCity.SelectedValue);
        lbTown.Items.Clear();
        if (cityId != -1)
        {
            lbTown.DataSource = DBProvider.GetTownListByCityObjectId(cityId);
            lbTown.DataBind();

            pnlTownLocationSearch.Visible = true;
        }
        else
        {
            pnlTownLocationSearch.Visible = false;
        }
    }
    #endregion
    
    #region Button Clicks
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    #endregion

}
