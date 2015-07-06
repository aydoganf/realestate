using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Web.UI.HtmlControls;

public partial class AdvertDetail : BasePage
{
    private Advert currentAdvert;
    public Advert CurrentAdvert
    {
        get 
        {
            if (currentAdvert == default(Advert))
            {
                currentAdvert = DBProvider.GetAdvertByAdvertNumber(RouteData.Values["advertNumber"].ToString());
            }
            return currentAdvert; 
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
        if (!Page.User.Identity.IsAuthenticated && !CurrentAdvert.IsActive)
        {
            Response.Redirect("~/error");
        }
        
        rptPhotos.DataSource = CurrentAdvert.AdvertPhoto.Where(i => !i.Deleted);
        rptPhotos.DataBind();

        hfLong.Value = CurrentAdvert.Longitude;
        hfLat.Value = CurrentAdvert.Latitude;

        List<FeatureType> featureTypeList = DBProvider.GetFeatureTypeListByEstateTypeObjectId(Convert.ToInt32(CurrentAdvert.ParentEstateTypeObjectId));

        rptFeatureType.DataSource = featureTypeList;
        rptFeatureType.DataBind();

        rptFeatureTypeTabs.DataSource = featureTypeList;
        rptFeatureTypeTabs.DataBind();

        #region Paneller
        SetPanels();
        lblParentEstateTypeName.Text = CurrentAdvert.EstateType.ParentEstateType.TypeName;
        #endregion

        SetNavigation();
    }

    protected void SetNavigation()
    {
        string redirect = "/arama-sonuclari";

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

        string arrow = "&gt;";
        string navEstateType = "";
        string navSubEstateType = "";
        string navCity = "";
        string navTown = "";
        string navDistrict = "";

        estateType = CurrentAdvert.ParentEstateTypeObjectId.ToString();
        string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect += "/1/?q=" + hash;        
        navEstateType = " <a href='" + redirect + "'>" + CurrentAdvert.EstateType.ParentEstateType.TypeName + " Anasayfa</a> " + arrow;

        // **

        city = CurrentAdvert.CityObjectId.ToString();
        hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect = "/arama-sonuclari";
        redirect += "/1/?q=" + hash;
        navCity = " <a href='" + redirect + "'>" + CurrentAdvert.CityName + "</a> " + arrow;

        // **

        town = CurrentAdvert.TownObjectId.ToString();
        hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect = "/arama-sonuclari";
        redirect += "/1/?q=" + hash;
        navTown = " <a href='" + redirect + "'>" + CurrentAdvert.TownName + "</a> " + arrow;

        // **

        district = CurrentAdvert.DistrictObjectId.ToString();
        hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect = "/arama-sonuclari";
        redirect += "/1/?q=" + hash;
        navDistrict = " <a href='" + redirect + "'>" + CurrentAdvert.DistrictName + "</a> " + arrow;

        // **

        childEstateType = CurrentAdvert.EstateTypeObjectId.ToString();
        hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect = "/arama-sonuclari";
        redirect += "/1/?q=" + hash;
        navSubEstateType = " <a href='" + redirect + "'>" + CurrentAdvert.EstateType.TypeName + "</a> " + arrow;

        // **

        lblNavigation.Text = navEstateType + navCity + navTown + navDistrict + navSubEstateType + " " + CurrentAdvert.Title;
    }

    protected void SetPanels()
    {
        pnlKonutBilgileri.Visible = false;
        pnlIsyeriBilgileri.Visible = false;
        pnlArsaBilgileri.Visible = false;
        pnlDevremulkBilgileri.Visible = false;
        pnlTuristikBilgileri.Visible = false;

        switch (CurrentAdvert.EstateType.ParentEstateType.TypeKey)
        {
            case "konut":
                pnlKonutBilgileri.Visible = true;                
                break;
            case "isyeri":
                pnlIsyeriBilgileri.Visible = true;
                break;
            case "arsa":
                pnlArsaBilgileri.Visible = true;
                break;
            case "devremulk":
                pnlDevremulkBilgileri.Visible = true;
                break;
            case "turistik-isletme":
                pnlTuristikBilgileri.Visible = true;
                break;
            default:
                break;
        }
    }

    protected void rptFeatureTypeTabs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            FeatureType featureType = e.Item.DataItem as FeatureType;
            Repeater rptFeatures = e.Item.FindControl("rptFeatures") as Repeater;

            rptFeatures.DataSource = DBProvider.GetFeatureListByFeatureTypeObjectId(featureType.ObjectId);
            rptFeatures.DataBind();

        }
    }
    protected void rptFeatures_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HtmlGenericControl liFeature = e.Item.FindControl("liFeature") as HtmlGenericControl;
            Feature feature = e.Item.DataItem as Feature;

            if (CurrentAdvert.AdvertFeatureRelation.Where(i=> !i.Deleted && i.FeatureObjectId == feature.ObjectId).Count() != 0)
            {
                liFeature.Attributes["data-checked"] = "1";
                liFeature.Attributes["class"] = "checked";
            }
            else
            {
                liFeature.Attributes["data-checked"] = "0";
                liFeature.Attributes["class"] = "plain";
            }
        }
    }
}