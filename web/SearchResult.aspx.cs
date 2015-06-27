using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Configuration;
using System.Web.UI.HtmlControls;

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

    private int advertPageNumber;
    public int AdvertPageNumber
    {
        get
        {
            if (advertPageNumber == default(int))
            {
                int o;
                if (RouteData.Values["page"] != null && int.TryParse(RouteData.Values["page"].ToString(), out o))
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

    private string pageSearchQuery;

    public string PageSearchQuery
    {
        get 
        {
            if (string.IsNullOrEmpty(pageSearchQuery))
            {
                if (!string.IsNullOrEmpty(Request.QueryString["q"]))
                {
                    pageSearchQuery = Request.QueryString["q"];
                }
                else
                    Response.Redirect("~/hata?sq=empty");
            }
            return pageSearchQuery; 
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
        SearchAdvanced(AdvertPageNumber);
    }


    protected void SearchAdvanced(int page)
    {
        SearchQuery searchQuery = GetSearchQueryFromHash(PageSearchQuery);

        int resultCount;
        List<Advert> searchResult = DBProvider.AdvancedSearchAdvert(searchQuery, page, AdvertPageItemCount, out resultCount);
        rptAdverts.DataSource = searchResult;
        rptAdverts.DataBind();

        if (resultCount != 0)
        {
            if (resultCount > AdvertPageItemCount)
            {
                int totalPages = (int)Math.Ceiling((double)resultCount / AdvertPageItemCount);
                hfLastPageNumber.Value = totalPages.ToString();
                int[] pagination = new int[totalPages];
                for (int i = 0; i < totalPages; i++)
                {
                    pagination[i] = i + 1;
                }

                rptPagination.DataSource = pagination;
                rptPagination.DataBind();
                hfCurrentAdvertPageNumber.Value = AdvertPageNumber.ToString();
                hfSearchQuery.Value = PageSearchQuery;
            }
            else
                divPagination.Visible = false;
        }
        else
        {
            pnlEmpty.Visible = true;
            divPagination.Visible = false;
        }

        EstateType _estateType = DBProvider.GetEstateTypeByObjectId(searchQuery.EstateTypeId);
        Site master = Page.Master as Site;
        master.BindSearchedData(searchQuery, ConfigurationManager.AppSettings["searchMode_advanced"]);
        master.h2QuickSearchHead.InnerText = "Arama Kriterleri";
        HiddenField hfSearchMode = (HiddenField)Page.Master.FindControl("hfSearchMode");
        hfSearchMode.Value = ConfigurationManager.AppSettings["searchMode_advanced"];

        #region Navigation

        #region Base Query
        string redirect = "/arama-sonuclari";

        string city = "-1";
        string town = "-1";
        string district = "-1";
        string estateType = searchQuery.EstateTypeId.ToString();
        string childEstateType = "-1";
        string marketingType = searchQuery.MarketingTypeId.ToString();
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

        
        #endregion

        string arrow = "&gt;";
        string navEstateType = "";
        string navSubEstateType = "";
        string navCity = "";
        string navTown = "";
        string navDistrict = "";

        if (searchQuery.EstateTypeId != -1)
        {
            string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

            redirect += "/1/?q=" + hash;
            EstateType searchEstateType = DBProvider.GetEstateTypeByObjectId(searchQuery.EstateTypeId);
            navEstateType = " <a href='" + redirect + "'>" + searchEstateType.TypeName + " Anasayfa</a> " + arrow;
        }

        if (searchQuery.CityId != -1)
        {
            city = searchQuery.CityId.ToString();
            string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

            redirect = "/arama-sonuclari";
            redirect += "/1/?q=" + hash;
            City searchedCity = DBProvider.GetCityByObjectId(searchQuery.CityId);
            navCity = " <a href='" + redirect + "'>" + searchedCity.CityName + "</a> " + arrow;
        }

        if (searchQuery.TownId != -1)
        {
            town = searchQuery.TownId.ToString();
            string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

            redirect = "/arama-sonuclari";
            redirect += "/1/?q=" + hash;

            Town searchedTown = DBProvider.GetTownByObjectId(searchQuery.TownId);
            navTown = " <a href='" + redirect + "'>" + searchedTown.TownName + "</a> " + arrow;
        }

        if (searchQuery._DistrictId)
        {
            string districtName = "";
            district = "";
            for (int i = 0; i < searchQuery.DistrictId.Length; i++)
            {
                District searchedDistrict = DBProvider.GetDistrictByObjectId(searchQuery.DistrictId[i]);
                if (i != searchQuery.DistrictId.Length - 1)
                {
                    district += searchQuery.DistrictId[i].ToString() + ",";
                    districtName += searchedDistrict.DistrictName + ",";
                }
                else
                {
                    district += searchQuery.DistrictId[i].ToString();
                    districtName += searchedDistrict.DistrictName;
                }
            }

            string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

            redirect = "/arama-sonuclari";
            redirect += "/1/?q=" + hash;
            navDistrict = " <a href='" + redirect + "'>" + districtName + "</a> " + arrow;
        }

        if (searchQuery._EstateTypeChildIdList)
        {
            string childName = "";
            for (int i = 0; i < searchQuery.EstateTypeChildIdList.Length; i++)
            {
                EstateType searchedChildEstateType = DBProvider.GetEstateTypeByObjectId(searchQuery.EstateTypeChildIdList[i]);
                if (i != searchQuery.EstateTypeChildIdList.Length - 1)
                {
                    childEstateType += searchQuery.EstateTypeChildIdList[i].ToString() + ",";
                    childName += searchedChildEstateType.TypeName + ",";
                }
                else
                { 
                    childEstateType += searchQuery.EstateTypeChildIdList[i].ToString();
                    childName += searchedChildEstateType.TypeName;
                }
            }

            string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

            redirect = "/arama-sonuclari";
            redirect += "/1/?q=" + hash;
            navSubEstateType = " <a href='" + redirect + "'>" + childName + "</a> " + arrow;
        }

        lblNavigation.Text = navEstateType + navCity + navTown + navDistrict + navSubEstateType + " Arama Sonuçları";
        #endregion

        switch (_estateType.TypeKey)
        {
            case "konut":
                master._pnlKonutSearch.Visible = true;
                break;
            case "isyeri":
                master._pnlIsyeriSearch.Visible = true;
                break;
            case "arsa":
                master._pnlArsaSearch.Visible = true;
                break;
            case "devremulk":
                master._pnlDevremulkSearch.Visible = true;
                break;
            case "turistik-isletme":
                master._pnlTuristikSearch.Visible = true;                
                break;
            default:
                break;
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
}