using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Configuration;
using System.Web.UI.HtmlControls;

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

    private int advertPageNumber;
    public int AdvertPageNumber
    {
        get 
        {
            if (advertPageNumber == default(int))
            {
                int o;
                if (Request.QueryString["p"] != null && int.TryParse(Request.QueryString["p"], out o))
                {
                    advertPageNumber = o;
                }
                else
                {
                    advertPageNumber = 1;
                }
            }
            return advertPageNumber; 
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
        return;
        List<Advert> recentList = DBProvider.GetMostRecentAdvertList(100);

        #region Map Databinding
        double latTotal = 0;
        double longTotal = 0;

        foreach (Advert item in recentList)
        {
            latTotal += Convert.ToDouble(item.Latitude, System.Globalization.CultureInfo.InvariantCulture);
            longTotal += Convert.ToDouble(item.Longitude, System.Globalization.CultureInfo.InvariantCulture);
        }

        double latCenter = latTotal / recentList.Count;
        double longCenter = longTotal / recentList.Count;

        hfLatCenter.Value = latCenter.ToString().Replace(',', '.');
        hfLongCenter.Value = longCenter.ToString().Replace(',', '.');

        rptMapInfo.DataSource = recentList.Take(30);
        rptMapInfo.DataBind();
        #endregion

        #region Advert Databinding
        rptLastProperties.DataSource = recentList.Take(3);
        rptLastProperties.DataBind();

        rptRecentProperties.DataSource = DBProvider.GetMostRecentAdvertListWithPage(AdvertPageNumber, AdvertPageItemCount);
        rptRecentProperties.DataBind();

        if (recentList.Count > AdvertPageItemCount)
        {
            int totalPages = (int)Math.Ceiling((double)recentList.Count / AdvertPageItemCount);
            hfLastPageNumber.Value = totalPages.ToString();
            int[] pagination = new int[totalPages];
            for (int i = 0; i < totalPages; i++)
            {
                pagination[i] = i + 1;
            }

            rptPagination.DataSource = pagination;
            rptPagination.DataBind();
            hfCurrentAdvertPageNumber.Value = AdvertPageNumber.ToString();
        }
        else
            divPagination.Visible = false;
        #endregion                

        #region Search Databinding
        rptBaseEstateTypes.DataSource = BaseEstateTypeList;
        rptBaseEstateTypes.DataBind();

        ddlEstateType.DataSource = BaseEstateTypeList;
        ddlEstateType.DataBind();

        ddlMarketingType.DataSource = DBProvider.GetMarketingTypeList();
        ddlMarketingType.DataBind();
        ddlMarketingType.Items.Insert(0, new ListItem("Hepsi", "-1"));

        MarketingType marketingType = DBProvider.GetMarketingTypeByKey("kiralık");
        ddlMarketingType.SelectedValue = marketingType.ObjectId.ToString();

        ddlCurrencyList.DataSource = DBProvider.GetCurrencyList();
        ddlCurrencyList.DataBind();

        ddlCity.DataSource = DBProvider.GetCityList();
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Tüm şehirler", "-1"));
        #endregion
        
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

        string city = "-1";
        string town = "-1";
        string district = "-1";
        string estateType = "-1";
        string childEstateType = "-1";
        string marketingType = "-1";
        string areaFrom = "-1";
        string areaTo = "-1";
        string priceFrom = "-1";
        string priceTo = "-1";
        string priceCurrency = "-1";
        string isExchangable = "-1";
        string _ageFrom = "-1";
        string _ageTo = "-1";
        string _bathCount = "-1";
        string _floorCount = "-1";
        string _floor = "-1";
        string _heatingType = "-1";
        string _roomHall = "-1";
        string _advertOwner = "-1";
        string _isFlatForLandMethod = "-1";
        string _creditType = "-1";
        string _deedType = "-1";
        string _fuelType = "-1";
        string _isSublease = "-1";
        string _advertStatus = "-1";
        string _advertUsing = "-1";
        string _starCount = "-1";
        string _isSettlement = "-1";
        string _bedCountFrom = "-1";
        string _bedCountTo = "-1";
        string _roomCountFrom = "-1";
        string _roomCountTo = "-1";
        string _features = "-1";

        city = ddlCity.SelectedValue;
        town = !string.IsNullOrEmpty(ddlTown.SelectedValue) ? ddlTown.SelectedValue : "-1";
        district = !string.IsNullOrEmpty(ddlDistrict.SelectedValue) ? ddlDistrict.SelectedValue : "-1";
        estateType = ddlEstateType.SelectedValue;
        marketingType = ddlMarketingType.SelectedValue;
        areaFrom = !string.IsNullOrEmpty(tbAreaFrom.Text.Trim()) ? tbAreaFrom.Text.Trim() : "-1";
        areaTo = !string.IsNullOrEmpty(tbAreaTo.Text.Trim()) ? tbAreaTo.Text.Trim() : "-1";
        priceFrom = !string.IsNullOrEmpty(tbPriceFrom.Text.Trim()) ? tbPriceFrom.Text.Trim() : "-1";
        priceTo = !string.IsNullOrEmpty(tbPriceTo.Text.Trim()) ? tbPriceTo.Text.Trim() : "-1";
        priceCurrency = ddlCurrencyList.SelectedValue;

        string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect += "/1/?q=" + hash;
        Response.Redirect(redirect);
    }

    protected void rptBaseEstateTypes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            EstateType parentEstateType = e.Item.DataItem as EstateType;
            HtmlAnchor aQuick = e.Item.FindControl("aQuick") as HtmlAnchor;

            string redirect = "~/arama-sonuclari";

            string city = "-1";
            string town = "-1";
            string district = "-1";
            string estateType = parentEstateType.ObjectId.ToString();
            string childEstateType = "-1";
            string marketingType = "-1";
            string areaFrom = "-1";
            string areaTo = "-1";
            string priceFrom = "-1";
            string priceTo = "-1";
            string priceCurrency = "-1";
            string isExchangable = "-1";
            string _ageFrom = "-1";
            string _ageTo = "-1";
            string _bathCount = "-1";
            string _floorCount = "-1";
            string _floor = "-1";
            string _heatingType = "-1";
            string _roomHall = "-1";
            string _advertOwner = "-1";
            string _isFlatForLandMethod = "-1";
            string _creditType = "-1";
            string _deedType = "-1";
            string _fuelType = "-1";
            string _isSublease = "-1";
            string _advertStatus = "-1";
            string _advertUsing = "-1";
            string _starCount = "-1";
            string _isSettlement = "-1";
            string _bedCountFrom = "-1";
            string _bedCountTo = "-1";
            string _roomCountFrom = "-1";
            string _roomCountTo = "-1";
            string _features = "-1";

            string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

            redirect += "/1/?q=" + hash;
            aQuick.HRef = redirect;
        }
    }
    
    protected void rptPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int pageItem = Convert.ToInt32(e.Item.DataItem);
            HtmlGenericControl liPaginationItem = e.Item.FindControl("liPaginationItem") as HtmlGenericControl;

            if (pageItem == AdvertPageNumber)
            {
                liPaginationItem.Attributes["class"] = "active";
            }
        }
    }

    protected void lbtnBina_Click(object sender, EventArgs e)
    {
        EstateType binaEmlagi = KonutEmalgi.ChildEstateTypeList.FirstOrDefault(i => !i.Deleted && i.TypeKey == "bina");
        string _childEstateType = "";
        if (binaEmlagi == null)
            _childEstateType = "-1";
        else
            _childEstateType = binaEmlagi.ObjectId.ToString();

        string redirect = "~/arama-sonuclari";

        string city = "-1";
        string town = "-1";
        string district = "-1";
        string estateType = KonutEmalgi.ObjectId.ToString();
        string childEstateType = _childEstateType;
        string marketingType = "-1";
        string areaFrom = "-1";
        string areaTo = "-1";
        string priceFrom = "-1";
        string priceTo = "-1";
        string priceCurrency = "-1";
        string isExchangable = "-1";
        string _ageFrom = "-1";
        string _ageTo = "-1";
        string _bathCount = "-1";
        string _floorCount = "-1";
        string _floor = "-1";
        string _heatingType = "-1";
        string _roomHall = "-1";
        string _advertOwner = "-1";
        string _isFlatForLandMethod = "-1";
        string _creditType = "-1";
        string _deedType = "-1";
        string _fuelType = "-1";
        string _isSublease = "-1";
        string _advertStatus = "-1";
        string _advertUsing = "-1";
        string _starCount = "-1";
        string _isSettlement = "-1";
        string _bedCountFrom = "-1";
        string _bedCountTo = "-1";
        string _roomCountFrom = "-1";
        string _roomCountTo = "-1";
        string _features = "-1";

        string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect += "/1/?q=" + hash;
        Response.Redirect(redirect);
    }
}