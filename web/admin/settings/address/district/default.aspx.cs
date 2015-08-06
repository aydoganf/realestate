using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_address_district_default : BasePage
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
        ddlCityList.DataSource = DBProvider.GetCityList();
        ddlCityList.DataBind();
        ddlCityList.Items.Insert(0, new ListItem("Seçiniz", ""));
        ddlTownList.Items.Insert(0, new ListItem("Önce İl Seçiniz", ""));
    }

    protected void ddlCityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTownList.Items.Clear();
        if (ddlCityList.SelectedValue != "")
        {
            ddlTownList.DataSource = DBProvider.GetTownListByCityObjectId(Convert.ToInt32(ddlCityList.SelectedValue));
            ddlTownList.DataBind();
        }
        else
        {
            ddlTownList.Items.Insert(0, new ListItem("Önce İl Seçiniz", ""));
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        rptDistrict.DataSource = DBProvider.GetDistrictListByTownObjectId(Convert.ToInt32(ddlTownList.SelectedValue));
        rptDistrict.DataBind();

        pnlDistrictList.Visible = true;
    }

    protected void rptDistrict_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int districtId = Convert.ToInt32(e.CommandArgument);
            District obj = DBProvider.GetDistrictByObjectId(districtId);

            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}