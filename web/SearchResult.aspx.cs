using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Configuration;

public partial class SearchResult : BasePage
{
    private string _searchModeKey;
    public string searchModeKey
    {
        get 
        {
            if (string.IsNullOrEmpty(_searchModeKey))
            {
                _searchModeKey = RouteData.Values["mode"].ToString();
            }
            return _searchModeKey; 
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
        if (searchModeKey == ConfigurationManager.AppSettings["searchMode_quick"])
        {
            SearchQuick();
        }
        else if (searchModeKey == ConfigurationManager.AppSettings["searchMode_advanced"])
        {
            SearchAdvanced();
        }        
    }

    protected void SearchQuick()
    {
        SearchQuery searchQuery = new SearchQuery(RouteData.Values["cityId"], RouteData.Values["townId"], RouteData.Values["districtId"], RouteData.Values["estateTypeId"],
            RouteData.Values["marketingTypeId"], RouteData.Values["area"], RouteData.Values["price"], RouteData.Values["priceCurrencyId"]);

        List<Advert> searchResult = DBProvider.QuickSearchAdvert(searchQuery);
        rptAdverts.DataSource = searchResult;
        rptAdverts.DataBind();
        //(this.Master as Site).BindSearchedData(searchQuery);
    }

    protected void SearchAdvanced()
    {
        string query = Decypt(Request.QueryString["q"]);

        Dictionary<string, string> searchParams = new Dictionary<string, string>();
        foreach (string item in query.Split('&'))
        {
            string[] s = item.Split('=');
            searchParams.Add(s[0], s[1]);
        }

        string city = searchParams["city"];
        string town = searchParams["town"];
        string district = searchParams["district"];
        string estateType = searchParams["estateType"];
        string childEstateType = searchParams["childEstateType"];
        string marketingType = searchParams["marketingType"];
        string areaFrom = searchParams["areaFrom"];
        string areaTo = searchParams["areaTo"];
        string priceFrom = searchParams["priceFrom"];
        string priceTo = searchParams["priceTo"];
        string priceCurrency = searchParams["priceCurrency"];
        string isExchangable = searchParams["isExchangable"];
        string ageFrom = searchParams["ageFrom"];
        string ageTo = searchParams["ageTo"];
        string bathCount = searchParams["bathCount"];
        string floorCount = searchParams["floorCount"];
        string floor = searchParams["floor"];
        string heatingType = searchParams["heatingType"];
        string roomHallType = searchParams["roomHallType"];
        string advertOwner = searchParams["advertOwner"];
        string isFlatForLandMethod = searchParams["isFlatForLandMethod"];
        string creditType = searchParams["creditType"];
        string deedType = searchParams["deedType"];
        string fuelType = searchParams["fuelType"];
        string isSublease = searchParams["isSublease"];
        string advertStatusType = searchParams["advertStatusType"];
        string advertUsingType = searchParams["advertUsingType"];
        string starCount = searchParams["starCount"];
        string isSettlement = searchParams["isSettlement"];
        string bedCountFrom = searchParams["bedCountFrom"];
        string bedCountTo = searchParams["bedCountTo"];
        string roomCountFrom = searchParams["roomCountFrom"];
        string roomCountTo = searchParams["roomCountTo"];
        string features = searchParams["features"];

        SearchQuery searchQuery = new SearchQuery(marketingType, estateType, childEstateType, city, town, district, priceFrom, priceTo, priceCurrency, areaFrom, areaTo, isExchangable, ageFrom, ageTo, heatingType, roomHallType, floor, floorCount, advertOwner, bathCount, isFlatForLandMethod, creditType, deedType, fuelType, isSublease, advertStatusType, advertUsingType, starCount, isSettlement, bedCountFrom, bedCountTo, roomCountFrom, roomCountTo, features);

        List<Advert> searchResult = DBProvider.AdvancedSearchAdvert(searchQuery);
        rptAdverts.DataSource = searchResult;
        rptAdverts.DataBind();
        //(this.Master as Site).BindSearchedData(searchQuery);
    }
}