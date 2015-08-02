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
    }

    protected void Page_Init(object sender, EventArgs e)
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

    public void BindSearchedData(int cityObjectId, bool townParam, int[] townArr = null)
    {
        ddlCity.SelectedValue = cityObjectId.ToString();
        if (townParam)
        {
            foreach (ListItem item in lbTown.Items)
            {
                if (townArr.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }
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
        string city = ddlCity.SelectedValue;
        string town = "";

        foreach (ListItem item in lbTown.Items)
        {
            if (item.Selected)
            {
                town += item.Value + ",";
            }
        }

        if (town != "")
        {
            town = town.Remove(town.Length - 1);
        }
        else
        {
            town = "-1";
        }

        string query = "city=" + city + "&town=" + town;
        string hash = Encrypt(query);

        Response.Redirect("~/projeler?q=" + hash);
    }
    #endregion

}
