using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Configuration;

public partial class AdvencedSearch : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    #region Helpers
    protected void BindData()
    {
        ddlMarketingType.DataSource = DBProvider.GetMarketingTypeList();
        ddlMarketingType.DataBind();

        ddlEstateType.DataSource = DBProvider.GetBaseEstateTypeList();
        ddlEstateType.DataBind();
        ddlEstateType.SelectedValue = KonutEmalgi.ObjectId.ToString();
        lblEstateTypeText.Text = KonutEmalgi.TypeName;

        lbSubEstateType.DataSource = DBProvider.GetEstateTypeListByParentId(KonutEmalgi.ObjectId);
        lbSubEstateType.DataBind();

        ddlCurrency.DataSource = DBProvider.GetCurrencyList();
        ddlCurrency.DataBind();

        #region Şehir Bilgileri

        ddlCity.DataSource = DBProvider.GetCityList();
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Seçiniz", ""));
        ddlTown.Items.Insert(0, new ListItem("İl seçiniz", ""));
        #endregion

        #region SetPanels
        SetPanels(KonutEmalgi.ObjectId);
        #endregion
    }

    protected void SetPanels(int estateType)
    {
        pnlKonutBilgileri.Visible = false;
        pnlIsyeriBilgileri.Visible = false;
        pnlArsaBilgileri.Visible = false;
        pnlDevremulkBilgileri.Visible = false;
        pnlTuristikBilgileri.Visible = false;

        BindFeatures(estateType);
        EstateType selectedEstateType = DBProvider.GetEstateTypeByObjectId(estateType);

        switch (selectedEstateType.TypeKey)
        {
            case "konut":
                BindKonutBilgileri();
                pnlKonutBilgileri.Visible = true;
                break;
            case "isyeri":
                BindIsyeriBilgileri();
                pnlIsyeriBilgileri.Visible = true;
                break;
            case "arsa":
                BindArsaBilgileri();
                pnlArsaBilgileri.Visible = true;
                break;
            case "devremulk":
                BindDevremulkBilgileri();
                pnlDevremulkBilgileri.Visible = true;
                break;
            case "turistik-isletme":
                BindTuristikBilgileri();
                pnlTuristikBilgileri.Visible = true;
                break;
            default:
                break;
        }
    }

    protected void BindKonutBilgileri()
    {
        lbFloorKonut.DataSource = DBProvider.GetFloorList();
        lbFloorKonut.DataBind();
        lbFloorKonut.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbHeatingTypeKonut.DataSource = DBProvider.GetHeatingTypeList();
        lbHeatingTypeKonut.DataBind();
        lbHeatingTypeKonut.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbRoomHallKonut.DataSource = DBProvider.GetRoomHallList();
        lbRoomHallKonut.DataBind();
        lbRoomHallKonut.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbFuelTypeKonut.DataSource = DBProvider.GetFuelTypeList();
        lbFuelTypeKonut.DataBind();
        lbFuelTypeKonut.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlAdvertStatusTypeKonut.DataSource = DBProvider.GetAdvertStatusList();
        ddlAdvertStatusTypeKonut.DataBind();
        ddlAdvertStatusTypeKonut.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlAdvertUsingTypeKonut.DataSource = DBProvider.GetAdvertUsingTypeList();
        ddlAdvertUsingTypeKonut.DataBind();
        ddlAdvertUsingTypeKonut.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlCreditTypeKonut.DataSource = DBProvider.GetCreditTypeList();
        ddlCreditTypeKonut.DataBind();
        ddlCreditTypeKonut.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlDeedTypeKonut.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeKonut.DataBind();
        ddlDeedTypeKonut.Items.Insert(0, new ListItem("Seçiniz", ""));
    }

    protected void BindIsyeriBilgileri()
    {
        lbFloorIsyeri.DataSource = DBProvider.GetFloorList();
        lbFloorIsyeri.DataBind();
        lbFloorIsyeri.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbHeatingTypeIsyeri.DataSource = DBProvider.GetHeatingTypeList();
        lbHeatingTypeIsyeri.DataBind();
        lbHeatingTypeIsyeri.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbFuelTypeIsyeri.DataSource = DBProvider.GetFuelTypeList();
        lbFuelTypeIsyeri.DataBind();
        lbFuelTypeIsyeri.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlAdvertStatusTypeIsyeri.DataSource = DBProvider.GetAdvertStatusList();
        ddlAdvertStatusTypeIsyeri.DataBind();
        ddlAdvertStatusTypeIsyeri.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlAdvertUsingTypeIsyeri.DataSource = DBProvider.GetAdvertUsingTypeList();
        ddlAdvertUsingTypeIsyeri.DataBind();
        ddlAdvertUsingTypeIsyeri.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlCreditTypeIsyeri.DataSource = DBProvider.GetCreditTypeList();
        ddlCreditTypeIsyeri.DataBind();
        ddlCreditTypeIsyeri.Items.Insert(0, new ListItem("Seçiniz", ""));
    }

    protected void BindArsaBilgileri()
    {
        ddlCreditTypeArsa.DataSource = DBProvider.GetCreditTypeList();
        ddlCreditTypeArsa.DataBind();
        ddlCreditTypeArsa.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlDeedTypeArsa.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeArsa.DataBind();
        ddlDeedTypeArsa.Items.Insert(0, new ListItem("Seçiniz", ""));
    }

    protected void BindDevremulkBilgileri()
    {
        lbFloorDevremulk.DataSource = DBProvider.GetFloorList();
        lbFloorDevremulk.DataBind();
        lbFloorDevremulk.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbRoomHallDevremulk.DataSource = DBProvider.GetRoomHallList();
        lbRoomHallDevremulk.DataBind();
        lbRoomHallDevremulk.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbHeatingTypeDevremulk.DataSource = DBProvider.GetHeatingTypeList();
        lbHeatingTypeDevremulk.DataBind();
        lbHeatingTypeDevremulk.Items.Insert(0, new ListItem("Seçiniz", ""));

        lbFuelTypeDevremulk.DataSource = DBProvider.GetFuelTypeList();
        lbFuelTypeDevremulk.DataBind();
        lbFuelTypeDevremulk.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlAdvertStatusTypeDevremulk.DataSource = DBProvider.GetAdvertStatusList();
        ddlAdvertStatusTypeDevremulk.DataBind();
        ddlAdvertStatusTypeDevremulk.Items.Insert(0, new ListItem("Seçiniz", ""));
    }

    protected void BindTuristikBilgileri()
    {
        lbStarCountTuristik.DataSource = DBProvider.GetStarCountList();
        lbStarCountTuristik.DataBind();

        ddlDeedTypeTuristik.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeTuristik.DataBind();
        ddlDeedTypeTuristik.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));
    }

    protected void BindFeatures(int estateTypeId)
    {
        List<FeatureType> typeList = DBProvider.GetFeatureTypeListByEstateTypeObjectId(estateTypeId);
        rptFeatureType.DataSource = typeList;
        rptFeatureType.DataBind();

        rptFeatureTypeTabs.DataSource = typeList;
        rptFeatureTypeTabs.DataBind();
    }
    #endregion

    #region Dropdown Events
    protected void ddlEstateType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int estateTypeId = Convert.ToInt32(ddlEstateType.SelectedValue);
        EstateType estateType = DBProvider.GetEstateTypeByObjectId(estateTypeId);

        lblEstateTypeText.Text = estateType.TypeName;

        lbSubEstateType.DataSource = DBProvider.GetEstateTypeListByParentId(estateTypeId);
        lbSubEstateType.DataBind();

        SetPanels(estateTypeId);        
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTown.Items.Clear();
        lbDistrict.Items.Clear();

        if (ddlCity.SelectedValue != "")
        {
            ddlTown.DataSource = DBProvider.GetTownListByCityObjectId(Convert.ToInt32(ddlCity.SelectedValue));
            ddlTown.DataBind();
            ddlTown.Items.Insert(0, new ListItem("İlçe seçiniz", ""));
        }
        else
        {
            ddlTown.Items.Insert(0, new ListItem("İl seçiniz", ""));
            lbDistrict.Items.Insert(0, new ListItem("İlçe seçiniz", ""));
        }
    }
    protected void ddlTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbDistrict.Items.Clear();
        if (ddlTown.SelectedValue != "")
        {
            lbDistrict.DataSource = DBProvider.GetDistrictListByTownObjectId(Convert.ToInt32(ddlTown.SelectedValue));
            lbDistrict.DataBind();
        }
    }
    #endregion
    
    #region Button Clicks
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string redirect = "~/arama-sonuclari";

        string city = !string.IsNullOrEmpty(ddlCity.SelectedValue) ? ddlCity.SelectedValue : "-1";
        string town = !string.IsNullOrEmpty(ddlTown.SelectedValue) ? ddlTown.SelectedValue : "-1";

        string district = "-1";
        var queryDistrict = from ListItem item in lbDistrict.Items where item.Selected select item;
        if(queryDistrict.Count() != lbDistrict.Items.Count && queryDistrict.Count() != 0)
        {
            district = string.Empty;
            foreach (ListItem item in queryDistrict)
            {
                if(item != queryDistrict.Last())
                    district += item.Value + ",";
                else
                    district += item.Value;
            }
        }


        string estateType = "-1";
        estateType = ddlEstateType.SelectedValue;

        string childEstateType = "-1";
        var queryEstateType = from ListItem item in lbSubEstateType.Items where item.Selected select item;
        if (queryEstateType.Count() != lbSubEstateType.Items.Count && queryEstateType.Count() != 0)
        {
            childEstateType = string.Empty;
            foreach (ListItem item in queryEstateType)
            {
                if (item != queryEstateType.Last())
                    childEstateType += item.Value + ",";
                else
                    childEstateType += item.Value;
            }
        }

        string marketingType = ddlMarketingType.SelectedValue;
        string areaFrom = !string.IsNullOrEmpty(tbAreaFrom.Text.Trim()) ? tbAreaFrom.Text.Trim() : "-1";
        string areaTo = !string.IsNullOrEmpty(tbAreaTo.Text.Trim()) ? tbAreaTo.Text.Trim() : "-1";
        string priceFrom = !string.IsNullOrEmpty(tbPriceFrom.Text.Trim()) ? tbPriceFrom.Text.Trim() : "-1";
        string priceTo = !string.IsNullOrEmpty(tbPriceTo.Text.Trim()) ? tbPriceTo.Text.Trim() : "-1";
        string priceCurrency = ddlCurrency.SelectedValue;
        string isExchangable = !string.IsNullOrEmpty(ddlIsExchangable.SelectedValue) ? ddlIsExchangable.SelectedValue : "-1";


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

        int baseEstateTypeId = Convert.ToInt32(ddlEstateType.SelectedValue);
        EstateType baseEstateType = DBProvider.GetEstateTypeByObjectId(baseEstateTypeId);

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

                if (!string.IsNullOrEmpty(ddlAdvertStatusTypeKonut.SelectedValue))
                    _advertStatus = ddlAdvertStatusTypeKonut.SelectedValue;

                if (!string.IsNullOrEmpty(ddlAdvertUsingTypeKonut.SelectedValue))
                    _advertUsing = ddlAdvertUsingTypeKonut.SelectedValue;

                if (!string.IsNullOrEmpty(ddlCreditTypeKonut.SelectedValue))
                    _creditType = ddlCreditTypeKonut.SelectedValue;

                if (!string.IsNullOrEmpty(ddlDeedTypeKonut.SelectedValue))
                    _deedType = ddlDeedTypeKonut.SelectedValue;
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


                if (!string.IsNullOrEmpty(ddlAdvertStatusTypeKonut.SelectedValue))
                    _advertStatus = ddlAdvertStatusTypeKonut.SelectedValue;

                if (!string.IsNullOrEmpty(ddlAdvertUsingTypeKonut.SelectedValue))
                    _advertUsing = ddlAdvertUsingTypeKonut.SelectedValue;

                if (!string.IsNullOrEmpty(ddlCreditTypeKonut.SelectedValue))
                    _creditType = ddlCreditTypeKonut.SelectedValue;

                if (!string.IsNullOrEmpty(ddlIsSubleaseIsyeri.SelectedValue))
                    _isSublease = ddlIsSubleaseIsyeri.SelectedValue;

                #endregion

                break;
            case "arsa":

                #region Arsa Arama Verileri

                if (!string.IsNullOrEmpty(ddlIsFlatForLandMethodArsa.SelectedValue))
                    _isFlatForLandMethod = ddlIsFlatForLandMethodArsa.SelectedValue;

                if (!string.IsNullOrEmpty(ddlCreditTypeArsa.SelectedValue))
                    _creditType = ddlCreditTypeArsa.SelectedValue;

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

                if (!string.IsNullOrEmpty(ddlIsSubleaseDevremulk.SelectedValue))
                    _isSublease = ddlIsSubleaseDevremulk.SelectedValue;

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

                if (!string.IsNullOrEmpty(ddlAdvertStatusTypeDevremulk.SelectedValue))
                    _advertStatus = ddlAdvertStatusTypeDevremulk.SelectedValue;

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

        foreach (RepeaterItem item in rptFeatureTypeTabs.Items)
        {
            CheckBoxList cblFeatureList = item.FindControl("cblFeatureList") as CheckBoxList;
            foreach (ListItem listItem in cblFeatureList.Items)
            {
                _features += listItem.Value + ",";
            }
        }

        if (_features[_features.Length - 1] == ',')
            _features = _features.Remove(_features.Length - 1);


        string hash = GetSearchQueryHash(city, town, district, estateType, childEstateType, marketingType, areaFrom, areaTo, priceFrom, priceTo, priceCurrency, isExchangable, _ageFrom, _ageTo, _bathCount, _floorCount, _floor, _heatingType, _roomHall, _advertOwner, _isFlatForLandMethod, _creditType, _deedType, _fuelType, _isSublease, _advertStatus, _advertUsing, _starCount, _isSettlement, _bedCountFrom, _bedCountTo, _roomCountFrom, _roomCountTo, _features);

        redirect += "/1/?q=" + hash;
        Response.Redirect(redirect);
    }
    #endregion

    #region Repeater Events
    protected void rptFeatureTypeTabs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            FeatureType featureType = e.Item.DataItem as FeatureType;
            List<Feature> featureList = DBProvider.GetFeatureListByFeatureTypeObjectId(featureType.ObjectId);
            CheckBoxList cblFeatureList = e.Item.FindControl("cblFeatureList") as CheckBoxList;
            cblFeatureList.DataSource = featureList;
            cblFeatureList.DataBind();
        }
    }
    #endregion
    
}