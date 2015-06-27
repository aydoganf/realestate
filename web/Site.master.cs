using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class Site : MasterBasePage
{
    #region Props

    #region DBPorps
    private RealEstateEntities dbProvider;
    public RealEstateEntities DBProvider
    {
        get
        {
            if (dbProvider == default(RealEstateEntities))
            {
                dbProvider = new RealEstateEntities();
            }
            return dbProvider;
        }
    }

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
    #endregion

    #region QueryProps
    



    #endregion

    public HtmlGenericControl divQuickSearch
    {
        get
        {
            return quickSearch;
        }
    }

    public HtmlGenericControl h2QuickSearchHead
    {
        get
        {
            return quickSearchHead;
        }
    }

    public Panel _pnlKonutSearch
    {
        get
        {
            return pnlKonutSearch;
        }
    }

    public Panel _pnlIsyeriSearch
    {
        get
        {
            return pnlIsyeriSearch;
        }
    }

    public Panel _pnlArsaSearch
    {
        get
        {
            return pnlArsaSearch;
        }
    }

    public Panel _pnlDevremulkSearch
    {
        get
        {
            return pnlDevremulkSearch;
        }
    }

    public Panel _pnlTuristikSearch
    {
        get
        {
            return pnlTuristikSearch;
        }
    }


    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BindData()
    {
        rptLastProperties.DataSource = DBProvider.GetMostRecentAdvertList(3);
        rptLastProperties.DataBind();

        ddlCity.DataSource = DBProvider.GetCityList();
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Tüm şehirler", "-1"));

        ddlEstateType.DataSource = BaseEstateTypeList;
        ddlEstateType.DataBind();

        ddlMarketingType.DataSource = DBProvider.GetMarketingTypeList();
        ddlMarketingType.DataBind();

        ddlCurrencyList.DataSource = DBProvider.GetCurrencyList();
        ddlCurrencyList.DataBind();
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

    public void BindSearchedData(SearchQuery obj, string searchMode)
    {
        ddlCity.SelectedValue = obj.CityId.ToString();
        if (obj.CityId != -1)
        {
            pnlTownLocationSearch.Visible = true;
            ddlTown.DataSource = DBProvider.GetTownListByCityObjectId(obj.CityId);
            ddlTown.DataBind();
            ddlTown.Items.Insert(0, new ListItem("Tüm ilçeler", "-1"));
            ddlTown.SelectedValue = obj.TownId.ToString();
            if (obj.TownId != -1)
            {
                pnlDistrictLocationSearch.Visible = true;
                ddlDistrict.DataSource = DBProvider.GetDistrictListByTownObjectId(obj.TownId);
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Tüm semtler", "-1"));
                ddlDistrict.SelectedValue = obj.DistrictId.ToString();
            }
        }
        ddlEstateType.SelectedValue = obj.EstateTypeId.ToString();
        ddlMarketingType.SelectedValue = obj.MarketingTypeId.ToString();
        if (obj.AreaFrom != -1)
            tbAreaFrom.Text = obj.AreaFrom.ToString();        
        if (obj.AreaTo != -1)
            tbAreaTo.Text = obj.AreaTo.ToString();
        if (obj.PriceFrom != -1)
            tbPriceFrom.Text = obj.PriceFrom.ToString();
        if (obj.PriceTo != -1)
            tbPriceTo.Text = obj.PriceTo.ToString();
        ddlCurrencyList.SelectedValue = obj.PriceCurrencyId.ToString();

        foreach (int item in obj.EstateTypeChildIdList)
        {
            if(item != obj.EstateTypeChildIdList.Last())
                hfSelectedChildEstate.Value += item.ToString() + ",";
            else
                hfSelectedChildEstate.Value += item.ToString();
        }

        if (searchMode == ConfigurationManager.AppSettings["searchMode_advanced"])
        {
            EstateType parentEstateType = DBProvider.GetEstateTypeByObjectId(obj.EstateTypeId);

            switch (parentEstateType.TypeKey)
            {
                case "konut":
                    BindKonutBilgileri(obj);
                    break;
                case "isyeri":
                    BindIsyeriBilgileri(obj);
                    break;
                case "arsa":
                    BindArsaBilgileri(obj);
                    break;
                case "devremulk":
                    BindDevremulkBilgileri(obj);
                    break;
                case "turistik-isletme":
                    BindTuristikBilgileri(obj);
                    break;
                default:
                    break;
            }
        }

        rptSubEstateTypeList.DataSource = DBProvider.GetEstateTypeListByParentId(obj.EstateTypeId);
        rptSubEstateTypeList.DataBind();
    }

    protected void BindKonutBilgileri(SearchQuery obj)
    {
        lbFloorKonut.DataSource = DBProvider.GetFloorList();
        lbFloorKonut.DataBind();
        if (obj._FloorId)
        {
            foreach (ListItem item in lbFloorKonut.Items)
            {
                if (obj.FloorId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbHeatingTypeKonut.DataSource = DBProvider.GetHeatingTypeList();
        lbHeatingTypeKonut.DataBind();
        if (obj._HeatingTypeId)
        {
            foreach (ListItem item in lbHeatingTypeKonut.Items)
            {
                if (obj.HeatingTypeId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbRoomHallKonut.DataSource = DBProvider.GetRoomHallList();
        lbRoomHallKonut.DataBind();
        if (obj._RoomHallId)
        {
            foreach (ListItem item in lbRoomHallKonut.Items)
            {
                if (obj.RoomHallId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbFuelTypeKonut.DataSource = DBProvider.GetFuelTypeList();
        lbFuelTypeKonut.DataBind();
        if (obj._FuelTypeId)
        {
            foreach (ListItem item in lbFuelTypeKonut.Items)
            {
                if (obj.FuelTypeId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }

        if (obj.AgeFrom != -1)
            tbAgeFromKonut.Text = obj.AgeFrom.ToString();

        if (obj.AgeTo != -1)
            tbAgeToKonut.Text = obj.AgeTo.ToString();


    }

    protected void BindIsyeriBilgileri(SearchQuery obj)
    {
        lbFloorIsyeri.DataSource = DBProvider.GetFloorList();
        lbFloorIsyeri.DataBind();
        if (obj._FloorId)
        {
            foreach (ListItem item in lbFloorIsyeri.Items)
            {
                if (obj.FloorId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbHeatingTypeIsyeri.DataSource = DBProvider.GetHeatingTypeList();
        lbHeatingTypeIsyeri.DataBind();
        if (obj._HeatingTypeId)
        {
            foreach (ListItem item in lbHeatingTypeIsyeri.Items)
            {
                if (obj.HeatingTypeId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbFuelTypeIsyeri.DataSource = DBProvider.GetFuelTypeList();
        lbFuelTypeIsyeri.DataBind();
        if (obj._FuelTypeId)
        {
            foreach (ListItem item in lbFuelTypeIsyeri.Items)
            {
                if (obj.FuelTypeId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }

        if (obj.AgeFrom != -1)
            tbAgeFromIsyeri.Text = obj.AgeFrom.ToString();

        if (obj.AgeTo != -1)
            tbAgeToIsyeri.Text = obj.AgeTo.ToString();

        if (obj.RoomCountFrom != -1)
            tbRoomCountFromIsyeri.Text = obj.RoomCountFrom.ToString();

        if (obj.RoomCountTo != -1)
            tbRoomCountToIsyeri.Text = obj.RoomCountTo.ToString();
        
    }

    protected void BindArsaBilgileri(SearchQuery obj)
    {
        ddlDeedTypeArsa.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeArsa.DataBind();
        ddlDeedTypeArsa.Items.Insert(0, new ListItem("Seçiniz", ""));
        if (obj.DeedTypeId != -1)
        {
            ddlDeedTypeArsa.SelectedValue = obj.DeedTypeId.ToString();
        }        
    }

    protected void BindDevremulkBilgileri(SearchQuery obj)
    {
        lbFloorDevremulk.DataSource = DBProvider.GetFloorList();
        lbFloorDevremulk.DataBind();
        if (obj._FloorId)
        {
            foreach (ListItem item in lbFloorDevremulk.Items)
            {
                if (obj.FloorId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbRoomHallDevremulk.DataSource = DBProvider.GetRoomHallList();
        lbRoomHallDevremulk.DataBind();
        if (obj._RoomHallId)
        {
            foreach (ListItem item in lbRoomHallDevremulk.Items)
            {
                if (obj.RoomHallId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbHeatingTypeDevremulk.DataSource = DBProvider.GetHeatingTypeList();
        lbHeatingTypeDevremulk.DataBind();
        if (obj._HeatingTypeId)
        {
            foreach (ListItem item in lbHeatingTypeDevremulk.Items)
            {
                if (obj.HeatingTypeId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }


        lbFuelTypeDevremulk.DataSource = DBProvider.GetFuelTypeList();
        lbFuelTypeDevremulk.DataBind();
        if (obj._FuelTypeId)
        {
            foreach (ListItem item in lbFuelTypeDevremulk.Items)
            {
                if (obj.FuelTypeId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }

        if (obj.AgeFrom != -1)
            tbAgeFromDevremulk.Text = obj.AgeFrom.ToString();

        if (obj.AgeTo != -1)
            tbAgeToDevremulk.Text = obj.AgeTo.ToString();
    }

    protected void BindTuristikBilgileri(SearchQuery obj)
    {
        lbStarCountTuristik.DataSource = DBProvider.GetStarCountList();
        lbStarCountTuristik.DataBind();
        if (obj._StarCountId)
        {
            foreach (ListItem item in lbStarCountTuristik.Items)
            {
                if (obj.StarCountId.Contains(Convert.ToInt32(item.Value)))
                    item.Selected = true;
            }
        }

        ddlDeedTypeTuristik.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeTuristik.DataBind();
        ddlDeedTypeTuristik.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));
        if (obj.DeedTypeId != -1)
        {
            ddlDeedTypeTuristik.SelectedValue = obj.DeedTypeId.ToString();
        }

        if (obj.RoomCountFrom != -1)
            tbRoomCountFromTuristik.Text = obj.RoomCountFrom.ToString();

        if (obj.RoomCountTo != -1)
            tbRoomCountToTuristik.Text = obj.RoomCountTo.ToString();

        if (obj.BedCountFrom != -1)
            tbBedCountFromTuristik.Text = obj.BedCountFrom.ToString();

        if (obj.BedCountTo != -1)
            tbBedCountToTuristik.Text = obj.BedCountTo.ToString();
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

        EstateType baseEstateType = DBProvider.GetEstateTypeByObjectId(Convert.ToInt32(ddlEstateType.SelectedValue));

        switch (baseEstateType.TypeKey)
        {
            case "konut":

                #region Konut Arama Verileri
                // floor (bulunduğu kat)
                var queryFloorKonut = from ListItem item in lbFloorKonut.Items where item.Selected select item;
                if (queryFloorKonut.Count() != lbFloorKonut.Items.Count && queryFloorKonut.Count() != 0)
                {
                    _floor = string.Empty;
                    foreach (ListItem item in queryFloorKonut)
                    {
                        if (item != queryFloorKonut.Last())
                            _floor += item.Value + ",";
                        else
                            _floor += item.Value;
                    }
                }
                // **

                // bina yaşı
                if (!string.IsNullOrEmpty(tbAgeFromKonut.Text.Trim()))
                    _ageFrom = tbAgeFromKonut.Text.Trim();

                if (!string.IsNullOrEmpty(tbAgeToKonut.Text.Trim()))
                    _ageTo = tbAgeToKonut.Text.Trim();

                // room & hall
                var queryRoomHallKonut = from ListItem item in lbRoomHallKonut.Items where item.Selected select item;
                if (queryRoomHallKonut.Count() != lbRoomHallKonut.Items.Count && queryRoomHallKonut.Count() != 0)
                {
                    _roomHall = string.Empty;
                    foreach (ListItem item in queryRoomHallKonut)
                    {
                        if (item != queryRoomHallKonut.Last())
                            _roomHall += item.Value + ",";
                        else
                            _roomHall += item.Value;
                    }
                }

                if (!string.IsNullOrEmpty(ddlBathCountKonut.SelectedValue))
                    _bathCount = ddlBathCountKonut.SelectedValue;

                // heating type
                var queryHeatingTypeKonut = from ListItem item in lbHeatingTypeKonut.Items where item.Selected select item;
                if (queryHeatingTypeKonut.Count() != lbHeatingTypeKonut.Items.Count && queryHeatingTypeKonut.Count() != 0)
                {
                    _heatingType = string.Empty;
                    foreach (ListItem item in queryHeatingTypeKonut)
                    {
                        if (item != queryHeatingTypeKonut.Last())
                            _heatingType += item.Value + ",";
                        else
                            _heatingType += item.Value;
                    }
                }

                // fuel type
                var queryFuelTypeKonut = from ListItem item in lbFuelTypeKonut.Items where item.Selected select item;
                if (queryFuelTypeKonut.Count() != lbFuelTypeKonut.Items.Count && queryFuelTypeKonut.Count() != 0)
                {
                    _fuelType = string.Empty;
                    foreach (ListItem item in queryFuelTypeKonut)
                    {
                        if (item != queryFuelTypeKonut.Last())
                            _fuelType += item.Value + ",";
                        else
                            _fuelType += item.Value;
                    }
                }

                #endregion

                break;
            case "isyeri":

                #region İşyeri Arama Verileri
                // floor (bulunduğu kat)
                var queryFloorIsyeri = from ListItem item in lbFloorIsyeri.Items where item.Selected select item;
                if (queryFloorIsyeri.Count() != lbFloorIsyeri.Items.Count && queryFloorIsyeri.Count() != 0)
                {
                    _floor = string.Empty;
                    foreach (ListItem item in queryFloorIsyeri)
                    {
                        if (item != queryFloorIsyeri.Last())
                            _floor += item.Value + ",";
                        else
                            _floor += item.Value;
                    }
                }
                // **

                // bina yaşı
                if (!string.IsNullOrEmpty(tbAgeFromIsyeri.Text.Trim()))
                    _ageFrom = tbAgeFromIsyeri.Text.Trim();

                if (!string.IsNullOrEmpty(tbAgeToIsyeri.Text.Trim()))
                    _ageTo = tbAgeToIsyeri.Text.Trim();


                // oda bölüm sayısı
                if (!string.IsNullOrEmpty(tbRoomCountFromIsyeri.Text.Trim()))
                    _roomCountFrom = tbRoomCountFromIsyeri.Text.Trim();

                if (!string.IsNullOrEmpty(tbRoomCountToIsyeri.Text.Trim()))
                    _roomCountTo = tbRoomCountToIsyeri.Text.Trim();


                // heating type
                var queryHeatingTypeIsyeri = from ListItem item in lbHeatingTypeIsyeri.Items where item.Selected select item;
                if (queryHeatingTypeIsyeri.Count() != lbHeatingTypeIsyeri.Items.Count && queryHeatingTypeIsyeri.Count() != 0)
                {
                    _heatingType = string.Empty;
                    foreach (ListItem item in queryHeatingTypeIsyeri)
                    {
                        if (item != queryHeatingTypeIsyeri.Last())
                            _heatingType += item.Value + ",";
                        else
                            _heatingType += item.Value;
                    }
                }


                // fuel type
                var queryFuelTypeIsyeri = from ListItem item in lbFuelTypeIsyeri.Items where item.Selected select item;
                if (queryFuelTypeIsyeri.Count() != lbFuelTypeIsyeri.Items.Count && queryFuelTypeIsyeri.Count() != 0)
                {
                    _fuelType = string.Empty;
                    foreach (ListItem item in queryFuelTypeIsyeri)
                    {
                        if (item != queryFuelTypeIsyeri.Last())
                            _fuelType += item.Value + ",";
                        else
                            _fuelType += item.Value;
                    }
                }

                #endregion

                break;
            case "arsa":

                #region Arsa Arama Verileri

                if (!string.IsNullOrEmpty(ddlDeedTypeArsa.SelectedValue))
                    _deedType = ddlDeedTypeArsa.SelectedValue;

                #endregion

                break;
            case "devremulk":

                #region Devremülk Arama Verileri

                // floor (bulunduğu kat)
                var queryFloorDevremulk = from ListItem item in lbFloorDevremulk.Items where item.Selected select item;
                if (queryFloorDevremulk.Count() != lbFloorDevremulk.Items.Count && queryFloorDevremulk.Count() != 0)
                {
                    _floor = string.Empty;
                    foreach (ListItem item in queryFloorDevremulk)
                    {
                        if (item != queryFloorDevremulk.Last())
                            _floor += item.Value + ",";
                        else
                            _floor += item.Value;
                    }
                }
                // **

                // bina yaşı
                if (!string.IsNullOrEmpty(tbAgeFromDevremulk.Text.Trim()))
                    _ageFrom = tbAgeFromDevremulk.Text.Trim();

                if (!string.IsNullOrEmpty(tbAgeToDevremulk.Text.Trim()))
                    _ageTo = tbAgeToDevremulk.Text.Trim();

                // room & hall
                var queryRoomHallDevremulk = from ListItem item in lbRoomHallDevremulk.Items where item.Selected select item;
                if (queryRoomHallDevremulk.Count() != lbRoomHallDevremulk.Items.Count && queryRoomHallDevremulk.Count() != 0)
                {
                    _roomHall = string.Empty;
                    foreach (ListItem item in queryRoomHallDevremulk)
                    {
                        if (item != queryRoomHallDevremulk.Last())
                            _roomHall += item.Value + ",";
                        else
                            _roomHall += item.Value;
                    }
                }

                if (!string.IsNullOrEmpty(ddlBathCountDevremulk.SelectedValue))
                    _bathCount = ddlBathCountDevremulk.SelectedValue;


                // heating type
                var queryHeatingTypeDevremulk = from ListItem item in lbHeatingTypeDevremulk.Items where item.Selected select item;
                if (queryHeatingTypeDevremulk.Count() != lbHeatingTypeDevremulk.Items.Count && queryHeatingTypeDevremulk.Count() != 0)
                {
                    _heatingType = string.Empty;
                    foreach (ListItem item in queryHeatingTypeDevremulk)
                    {
                        if (item != queryHeatingTypeDevremulk.Last())
                            _heatingType += item.Value + ",";
                        else
                            _heatingType += item.Value;
                    }
                }

                // fuel type
                var queryFuelTypeDevremulk = from ListItem item in lbFuelTypeDevremulk.Items where item.Selected select item;
                if (queryFuelTypeDevremulk.Count() != lbFuelTypeDevremulk.Items.Count && queryFuelTypeDevremulk.Count() != 0)
                {
                    _fuelType = string.Empty;
                    foreach (ListItem item in queryFuelTypeDevremulk)
                    {
                        if (item != queryFuelTypeDevremulk.Last())
                            _fuelType += item.Value + ",";
                        else
                            _fuelType += item.Value;
                    }
                }

                #endregion

                break;
            case "turistik-isletme":

                #region Turistik İşletme Arama Verileri

                if (!string.IsNullOrEmpty(tbRoomCountFromTuristik.Text.Trim()))
                    _roomCountFrom = tbRoomCountFromTuristik.Text.Trim();

                if (!string.IsNullOrEmpty(tbRoomCountToTuristik.Text.Trim()))
                    _roomCountTo = tbRoomCountToTuristik.Text.Trim();

                var queryStarCountTuristik = from ListItem item in lbStarCountTuristik.Items where item.Selected select item;
                if (queryStarCountTuristik.Count() != lbStarCountTuristik.Items.Count && queryStarCountTuristik.Count() != 0)
                {
                    _starCount = string.Empty;
                    foreach (ListItem item in queryStarCountTuristik)
                    {
                        if (item != queryStarCountTuristik.Last())
                            _starCount += item.Value + ",";
                        else
                            _starCount += item.Value;
                    }
                }

                if (!string.IsNullOrEmpty(tbBedCountFromTuristik.Text.Trim()))
                    _bedCountFrom = tbBedCountFromTuristik.Text.Trim();

                if (!string.IsNullOrEmpty(tbBedCountToTuristik.Text.Trim()))
                    _bedCountTo = tbBedCountToTuristik.Text.Trim();

                if (!string.IsNullOrEmpty(ddlDeedTypeTuristik.SelectedValue))
                    _deedType = ddlDeedTypeTuristik.SelectedValue;

                if (!string.IsNullOrEmpty(ddlIsSettlementTuristik.SelectedValue))
                    _isSettlement = ddlIsSettlementTuristik.SelectedValue;


                #endregion

                break;
            default:
                break;
        }

        string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect += "/1/?q=" + hash;
        Response.Redirect(redirect);
    }
    
    protected void rptSubEstateTypeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            EstateType _childEstateType = e.Item.DataItem as EstateType;
            HtmlAnchor aSubEstateLink = e.Item.FindControl("aSubEstateLink") as HtmlAnchor;
            HtmlGenericControl iconUnselected = e.Item.FindControl("iconUnselected") as HtmlGenericControl;
            HtmlGenericControl iconSelected = e.Item.FindControl("iconSelected") as HtmlGenericControl;
            SearchQuery searchQuery = GetSearchQueryFromHash(Request.QueryString["q"]);

            string redirect = "~/arama-sonuclari";

            string city = searchQuery.CityId.ToString();
            string town = searchQuery.TownId.ToString();
            string district = searchQuery._DistrictId ? GetSearchArrayStringFormat(searchQuery.DistrictId) : "-1";
            string estateType = _childEstateType.ParentEstateTypeObjectId.ToString();
            string childEstateType = _childEstateType.ObjectId.ToString();
            string marketingType = ddlMarketingType.SelectedValue;
            string areaFrom = searchQuery.AreaFrom.ToString();
            string areaTo = searchQuery.AreaTo.ToString();
            string priceFrom = searchQuery.PriceFrom.ToString();
            string priceTo = searchQuery.PriceTo.ToString();
            string priceCurrency = searchQuery.PriceCurrencyId.ToString();
            string isExchangable = GetSearchBooleanStringFormat(searchQuery.IsExchangable);
            string _ageFrom = searchQuery.AgeFrom.ToString();
            string _ageTo = searchQuery.AgeTo.ToString();
            string _bathCount = searchQuery.BathCount.ToString();
            string _floorCount = searchQuery.FloorCount.ToString();
            string _floor = searchQuery._FloorId ? GetSearchArrayStringFormat(searchQuery.FloorId) : "-1";
            string _heatingType = searchQuery._HeatingTypeId ? GetSearchArrayStringFormat(searchQuery.HeatingTypeId) : "-1";
            string _roomHall = searchQuery._RoomHallId ? GetSearchArrayStringFormat(searchQuery.RoomHallId) : "-1";
            string _advertOwner = "-1";
            string _isFlatForLandMethod = GetSearchBooleanStringFormat(searchQuery.IsFlatForLandMethod);
            string _creditType = searchQuery.CreditTypeId.ToString();
            string _deedType = searchQuery.DeedTypeId.ToString();
            string _fuelType = searchQuery._FuelTypeId ? GetSearchArrayStringFormat(searchQuery.FuelTypeId) : "-1";
            string _isSublease = GetSearchBooleanStringFormat(searchQuery.IsSublease);
            string _advertStatus = searchQuery.AdvertStatusId.ToString();
            string _advertUsing = searchQuery.AdvertUsingTypeId.ToString();
            string _starCount = searchQuery._StarCountId ? GetSearchArrayStringFormat(searchQuery.StarCountId) : "-1";
            string _isSettlement = GetSearchBooleanStringFormat(searchQuery.IsSettlement);
            string _bedCountFrom = searchQuery.BedCountFrom.ToString();
            string _bedCountTo = searchQuery.BedCountTo.ToString();
            string _roomCountFrom = searchQuery.RoomCountFrom.ToString();
            string _roomCountTo = searchQuery.RoomCountTo.ToString();
            string _features = searchQuery._FeaturesId ? GetSearchArrayStringFormat(searchQuery.FeaturesId) : "-1";
            string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

            redirect += "/1/?q=" + hash;
            aSubEstateLink.HRef = redirect;

            if (searchQuery._EstateTypeChildIdList)
            {
                if (searchQuery.EstateTypeChildIdList.Contains(_childEstateType.ObjectId))
                {
                    iconSelected.Visible = true;
                }
                else
                {
                    iconUnselected.Visible = true;
                }
            }
            else
            {
                iconSelected.Visible = true;
            }            
        }
    }
}
