using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class _Default : BasePage
{
    private List<EstateType> baseEstateTypeList;
    public List<EstateType> BaseEstateTypeList
    {
        get 
        {
            if (baseEstateTypeList == default(List<EstateType>))
            {
                baseEstateTypeList = DBProvider.GetBaseEstateTypeList();
            }
            return baseEstateTypeList; 
        }
    }
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {


        rptLastProperties.DataSource = DBProvider.GetMostRecentAdvertList(3);
        rptLastProperties.DataBind();

        rptRecentProperties.DataSource = DBProvider.GetMostRecentAdvertList(12);
        rptRecentProperties.DataBind();

        rptBaseEstateTypes.DataSource = BaseEstateTypeList;
        rptBaseEstateTypes.DataBind();

        ddlEstateType.DataSource = BaseEstateTypeList;
        ddlEstateType.DataBind();

        ddlMarketingType.DataSource = DBProvider.GetMarketingTypeList();
        ddlMarketingType.DataBind();

        ddlCurrencyList.DataSource = DBProvider.GetCurrencyList();
        ddlCurrencyList.DataBind();

        ddlCity.DataSource = DBProvider.GetCityList();
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Tüm şehirler", "-1"));
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cityId = Convert.ToInt32(ddlCity.SelectedValue);
        ddlTown.Items.Clear();
        if (cityId != -1)
        {
            ddlTown.DataSource = DBProvider.GetTownListByCityObjectId(cityId);
            ddlTown.DataBind();
            ddlTown.Items.Insert(0, new ListItem("Tüm ilçeler", "-1"));
            pnlTownLocationSearch.Visible = true;
        }
        else
        {
            pnlTownLocationSearch.Visible = false;
            pnlDistrictLocationSearch.Visible = false;
        }
    }
    protected void ddlTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        int townId = Convert.ToInt32(ddlTown.SelectedValue);
        ddlDistrict.Items.Clear();
        if (townId != -1)
        {
            ddlDistrict.DataSource = DBProvider.GetDistrictListByTownObjectId(townId);
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("Tüm semtler", "-1"));
            pnlDistrictLocationSearch.Visible = true;
        }
        else
        {
            pnlDistrictLocationSearch.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string redirect = "~/arama-sonuclari";
        string city = ddlCity.SelectedValue;
        string town = !string.IsNullOrEmpty(ddlTown.SelectedValue) ? ddlTown.SelectedValue : "-1";
        string district = !string.IsNullOrEmpty(ddlDistrict.SelectedValue) ? ddlDistrict.SelectedValue : "-1";
        string estateType = ddlEstateType.SelectedValue;
        string marketingType = ddlMarketingType.SelectedValue;
        string areaFrom = !string.IsNullOrEmpty(tbAreaFrom.Text.Trim()) ? tbAreaFrom.Text.Trim() : "-1";
        string areaTo = !string.IsNullOrEmpty(tbAreaTo.Text.Trim()) ? tbAreaTo.Text.Trim() : "-1";
        string priceFrom = !string.IsNullOrEmpty(tbPriceFrom.Text.Trim()) ? tbPriceFrom.Text.Trim() : "-1";
        string priceTo = !string.IsNullOrEmpty(tbPriceTo.Text.Trim()) ? tbPriceTo.Text.Trim() : "-1";
        string priceCurrency = ddlCurrencyList.SelectedValue;

        redirect += "/" + city;
        redirect += "/" + town;
        redirect += "/" + district;
        redirect += "/" + estateType;
        redirect += "/" + marketingType;
        redirect += "/" + areaFrom + "," + areaTo;        
        redirect += "/" + priceFrom + "," + priceTo;        
        redirect += "/" + priceCurrency;
        Response.Redirect(redirect);        
    }
}