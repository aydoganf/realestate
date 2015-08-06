using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class advert_data : BasePage
{
    #region Props
    private Advert currentAdvert;
    public Advert CurrentAdvert
    {
        get
        {
            if (currentAdvert == default(Advert))
            {
                if (Request.QueryString["advert"] != null)
                {
                    currentAdvert = DBProvider.GetAdvertByObjectId(Convert.ToInt32(Request.QueryString["advert"]));
                }
                else
                {
                    currentAdvert = null;
                }
            }
            return currentAdvert;
        }
    }

    private static readonly string[] _validExtensions = { "image/gif", "image/jpeg", "image/jpg", "image/png" };
    #endregion
    
    #region Helpers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            SetTab();
        }
    }

    protected void SetTab()
    {
        if (Request.QueryString["tab"] != null)
        {
            string script = "setTab('" + Request.QueryString["tab"] + "')";
            ClientScript.RegisterStartupScript(GetType(), "setTabKey", script, true);
        }
    }

    protected void BindData()
    {
        #region Dropdowns
        ddlMarketingType.DataSource = DBProvider.GetMarketingTypeList();
        ddlMarketingType.DataBind();
        ddlMarketingType.SelectedValue = "1";

        List<Currency> currenyList = DBProvider.GetCurrencyList();
        ddlDepositCurrency.DataSource = currenyList;
        ddlDepositCurrency.DataBind();

        ddlPriceCurreny.DataSource = currenyList;
        ddlPriceCurreny.DataBind();

        ddlCity.DataSource = DBProvider.GetCityList();
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Seçiniz", ""));

        ddlTown.Items.Insert(0, new ListItem("Önce il seçiniz", ""));
        ddlDistrict.Items.Insert(0, new ListItem("Önce ilçe seçiniz", ""));

        ddlAdvertOwner.DataSource = DBProvider.GetAdvertOwnerTypeList();
        ddlAdvertOwner.DataBind();
        ddlAdvertOwner.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));
        #endregion


        if (CurrentAdvert == null)
        {
            pnlNoAdvert.Visible = true;
        }
        else
        {
            #region AdvertDetails
            SetPanels(CurrentAdvert.EstateType.ParentEstateType.TypeKey);

            #region Standart Veriler

            ddlTown.DataSource = DBProvider.GetTownListByCityObjectId(CurrentAdvert.CityObjectId);
            ddlTown.DataBind();

            ddlDistrict.DataSource = DBProvider.GetDistrictListByTownObjectId(CurrentAdvert.TownObjectId);
            ddlDistrict.DataBind();

            ddlMarketingType.SelectedValue = CurrentAdvert.MarketingTypeObjectId.ToString();
            ddlCity.SelectedValue = CurrentAdvert.CityObjectId.ToString();
            ddlTown.SelectedValue = CurrentAdvert.TownObjectId.ToString();
            ddlDistrict.SelectedValue = CurrentAdvert.DistrictObjectId.ToString();
            ddlAdvertOwner.SelectedValue = CurrentAdvert.AdvertOwnerTypeObjectId.HasValue ? CurrentAdvert.AdvertOwnerTypeObjectId.ToString() : "";
            hfSelectedEstateTypeId.Value = CurrentAdvert.EstateTypeObjectId.ToString();
            hfSelectedEstateTypeName.Value = CurrentAdvert.EstateType.TypeName;
            hfCurrentAdvert.Value = CurrentAdvert.ObjectId.ToString();
            tbPrice.Text = CurrentAdvert.Price.ToString();
            ddlPriceCurreny.SelectedValue = CurrentAdvert.PriceCurrencyObjectId.ToString();
            tbDeposit.Text = CurrentAdvert.Deposit.HasValue ? CurrentAdvert.Deposit.ToString() : "";
            ddlDepositCurrency.SelectedValue = CurrentAdvert.DepositCurrencyObjectId.HasValue ? CurrentAdvert.DepositCurrencyObjectId.ToString() : "";

            tbArea.Text = CurrentAdvert.Area.ToString();
            hfLat.Value = CurrentAdvert.Latitude;
            hfLong.Value = CurrentAdvert.Longitude;
            tbTitle.Text = CurrentAdvert.Title;
            tbDescription.Text = CurrentAdvert.Description;
            #endregion
            
            #region FeatureTypes & Features

            List<FeatureType> featureTypeList = DBProvider.GetFeatureTypeListByEstateTypeObjectId((int)CurrentAdvert.EstateType.ParentEstateTypeObjectId);

            rptFeatureType.DataSource = featureTypeList;
            rptFeatureType.DataBind();

            rptFeatureTypeTabs.DataSource = featureTypeList;
            rptFeatureTypeTabs.DataBind();

            List<AdvertFeatureRelation> relation = DBProvider.GetAdvertFeatureRelationListByAdvertObjectId(CurrentAdvert.ObjectId);
            foreach (RepeaterItem item in rptFeatureTypeTabs.Items)
            {
                CheckBoxList cblFeatureList = item.FindControl("cblFeatureList") as CheckBoxList;
                foreach (ListItem citem in cblFeatureList.Items)
                {
                    if (relation.FirstOrDefault(i => i.FeatureObjectId == Convert.ToInt32(citem.Value)) != null)
                        citem.Selected = true;
                }
            }

            #endregion
            #endregion

            #region AdvertPhotos
            pnlAdvertPhoto.Visible = true;
            BindAdvertPhotos();
            if (Request.QueryString["advert_status"] == "0")
            {
                pnlAdvertAdded.Visible = true;
            }
            #endregion

            #region Buttons
            if (CurrentAdvert.IsActive)
            {
                btnActivateAdvert.Visible = false;
            }
            else
            {
                pnlActiveStatus.Visible = true;
            }
            aPreview.HRef = FormatAdvertLink(CurrentAdvert);
            #endregion
        }
    }

    protected void BindAdvertPhotos()
    {
        rptAdvertPhotos.DataSource = CurrentAdvert.AdvertPhoto.Where(i => i.Deleted == false).OrderBy(i => i.SortOrder);
        rptAdvertPhotos.DataBind();

        if (rptAdvertPhotos.Items.Count == 0)
            rptAdvertPhotos.Visible = false;
        else
            rptAdvertPhotos.Visible = true;        
    }

    protected void SetPanels(string key)
    {
        pnlKonut.Visible = false;
        pnlIsyeri.Visible = false;
        pnlArsa.Visible = false;
        pnlDevremulk.Visible = false;
        pnlTuristik.Visible = false;

        switch (key)
        {
            case "konut":
                BindKonutBilgileri();
                pnlKonut.Visible = true;
                break;
            case "isyeri":
                BindIsyeriBilgileri();
                pnlIsyeri.Visible = true;
                break;
            case "arsa":
                BindArsaBilgileri();
                pnlArsa.Visible = true;
                break;
            case "devremulk":
                BindDevremulkBilgileri();
                pnlDevremulk.Visible = true;
                break;
            case "turistik-isletme":
                BindTuristikBilgileri();
                pnlTuristik.Visible = true;
                break;
            default:
                break;
        }
    }

    protected void BindKonutBilgileri()
    {
        ddlFloorKonut.DataSource = DBProvider.GetFloorList();
        ddlFloorKonut.DataBind();
        ddlFloorKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlHeatingTypeKonut.DataSource = DBProvider.GetHeatingTypeList();
        ddlHeatingTypeKonut.DataBind();
        ddlHeatingTypeKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlRoomHallKonut.DataSource = DBProvider.GetRoomHallList();
        ddlRoomHallKonut.DataBind();
        ddlRoomHallKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlFuelTypeKonut.DataSource = DBProvider.GetFuelTypeList();
        ddlFuelTypeKonut.DataBind();
        ddlFuelTypeKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlAdvertStatusKonut.DataSource = DBProvider.GetAdvertStatusList();
        ddlAdvertStatusKonut.DataBind();
        ddlAdvertStatusKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlAdvertUsingKonut.DataSource = DBProvider.GetAdvertUsingTypeList();
        ddlAdvertUsingKonut.DataBind();
        ddlAdvertUsingKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlCreditTypeKonut.DataSource = DBProvider.GetCreditTypeList();
        ddlCreditTypeKonut.DataBind();
        ddlCreditTypeKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlDeedTypeKonut.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeKonut.DataBind();
        ddlDeedTypeKonut.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        if (CurrentAdvert != null)
        {
            ddlFloorKonut.SelectedValue = CurrentAdvert.FloorObjectId.HasValue ? CurrentAdvert.FloorObjectId.ToString() : "";
            ddlHeatingTypeKonut.SelectedValue = CurrentAdvert.HeatingTypeObjectId.HasValue ? CurrentAdvert.HeatingTypeObjectId.ToString() : "";
            ddlRoomHallKonut.SelectedValue = CurrentAdvert.RoomHallObjectId.HasValue ? CurrentAdvert.RoomHallObjectId.ToString() : "";
            ddlFuelTypeKonut.SelectedValue = CurrentAdvert.FuelTypeObjectId.HasValue ? CurrentAdvert.FuelTypeObjectId.ToString() : "";
            ddlAdvertStatusKonut.SelectedValue = CurrentAdvert.AdvertStatusObjectId.HasValue ? CurrentAdvert.AdvertStatusObjectId.ToString() : "";
            ddlAdvertUsingKonut.SelectedValue = CurrentAdvert.AdvertUsingTypeObjectId.HasValue ? CurrentAdvert.AdvertUsingTypeObjectId.ToString() : "";
            ddlCreditTypeKonut.SelectedValue = CurrentAdvert.CreditTypeObjectId.HasValue ? CurrentAdvert.CreditTypeObjectId.ToString() : "";
            ddlDeedTypeKonut.SelectedValue = CurrentAdvert.DeedTypeObjectId.HasValue ? CurrentAdvert.DeedTypeObjectId.ToString() : "";

            tbAgeKonut.Text = CurrentAdvert.Age.HasValue ? CurrentAdvert.Age.ToString() : "";
            tbFloorCountKonut.Text = CurrentAdvert.FloorCount.HasValue ? CurrentAdvert.FloorCount.ToString() : "";
            tbBathCountKonut.Text = CurrentAdvert.BathCount.HasValue ? CurrentAdvert.BathCount.ToString() : "";
        }
    }

    protected void BindIsyeriBilgileri()
    {
        ddlFloorIsyeri.DataSource = DBProvider.GetFloorList();
        ddlFloorIsyeri.DataBind();
        ddlFloorIsyeri.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlHeatingTypeIsyeri.DataSource = DBProvider.GetHeatingTypeList();
        ddlHeatingTypeIsyeri.DataBind();
        ddlHeatingTypeIsyeri.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlFuelTypeIsyeri.DataSource = DBProvider.GetFuelTypeList();
        ddlFuelTypeIsyeri.DataBind();
        ddlFuelTypeIsyeri.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlAdvertStatusIsyeri.DataSource = DBProvider.GetAdvertStatusList();
        ddlAdvertStatusIsyeri.DataBind();
        ddlAdvertStatusIsyeri.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlAdvertUsingIsyeri.DataSource = DBProvider.GetAdvertUsingTypeList();
        ddlAdvertUsingIsyeri.DataBind();
        ddlAdvertUsingIsyeri.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlCreditTypeIsyeri.DataSource = DBProvider.GetCreditTypeList();
        ddlCreditTypeIsyeri.DataBind();
        ddlCreditTypeIsyeri.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        if (CurrentAdvert != null)
        {
            ddlFloorIsyeri.SelectedValue = CurrentAdvert.FloorObjectId.HasValue ? CurrentAdvert.FloorObjectId.ToString() : "";
            ddlHeatingTypeIsyeri.SelectedValue = CurrentAdvert.HeatingTypeObjectId.HasValue ? CurrentAdvert.HeatingTypeObjectId.ToString() : "";
            ddlFuelTypeIsyeri.SelectedValue = CurrentAdvert.FuelTypeObjectId.HasValue ? CurrentAdvert.FuelTypeObjectId.ToString() : "";
            ddlAdvertStatusIsyeri.SelectedValue = CurrentAdvert.AdvertStatusObjectId.HasValue ? CurrentAdvert.AdvertStatusObjectId.ToString() : "";
            ddlAdvertUsingIsyeri.SelectedValue = CurrentAdvert.AdvertUsingTypeObjectId.HasValue ? CurrentAdvert.AdvertUsingTypeObjectId.ToString() : "";
            ddlCreditTypeIsyeri.SelectedValue = CurrentAdvert.CreditTypeObjectId.HasValue ? CurrentAdvert.CreditTypeObjectId.ToString() : "";

            tbAgeIsyeri.Text = CurrentAdvert.Age.HasValue ? CurrentAdvert.Age.ToString() : "";
            tbRoomCountIsyeri.Text = CurrentAdvert.RoomCount.HasValue ? CurrentAdvert.RoomCount.ToString() : "";
            ddlIsSubleaseIsyeri.SelectedValue = CurrentAdvert.IsSublease.HasValue ? ((bool)CurrentAdvert.IsSublease ? "1" : "0") : "";
        }
    }

    protected void BindArsaBilgileri()
    {
        ddlCreditTypeArsa.DataSource = DBProvider.GetCreditTypeList();
        ddlCreditTypeArsa.DataBind();
        ddlCreditTypeArsa.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlDeedTypeArsa.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeArsa.DataBind();
        ddlDeedTypeArsa.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        if (CurrentAdvert != null)
        {
            ddlCreditTypeArsa.SelectedValue = CurrentAdvert.CreditTypeObjectId.HasValue ? CurrentAdvert.CreditTypeObjectId.ToString() : "";
            ddlDeedTypeArsa.SelectedValue = CurrentAdvert.DeedTypeObjectId.HasValue ? CurrentAdvert.DeedTypeObjectId.ToString() : "";
            if (CurrentAdvert.IsFlatForLandMethod.HasValue)
            {
                rdbtnIsFlatForLandMethod.SelectedValue = (bool)CurrentAdvert.IsFlatForLandMethod ? "1" : "0";
            }
        }
    }

    protected void BindDevremulkBilgileri()
    {
        ddlFloorDevremulk.DataSource = DBProvider.GetFloorList();
        ddlFloorDevremulk.DataBind();
        ddlFloorDevremulk.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlRoomHallDevremulk.DataSource = DBProvider.GetRoomHallList();
        ddlRoomHallDevremulk.DataBind();
        ddlRoomHallDevremulk.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlHeatingTypeDevremulk.DataSource = DBProvider.GetHeatingTypeList();
        ddlHeatingTypeDevremulk.DataBind();
        ddlHeatingTypeDevremulk.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlFuelTypeDevremulk.DataSource = DBProvider.GetFuelTypeList();
        ddlFuelTypeDevremulk.DataBind();
        ddlFuelTypeDevremulk.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlAdvertStatusDevremulk.DataSource = DBProvider.GetAdvertStatusList();
        ddlAdvertStatusDevremulk.DataBind();
        ddlAdvertStatusDevremulk.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        if (CurrentAdvert != null)
        {
            ddlFloorDevremulk.SelectedValue = CurrentAdvert.FloorObjectId.HasValue ? CurrentAdvert.FloorObjectId.ToString() : "";
            ddlRoomHallDevremulk.SelectedValue = CurrentAdvert.RoomHallObjectId.HasValue ? CurrentAdvert.RoomHallObjectId.ToString() : "";
            ddlHeatingTypeDevremulk.SelectedValue = CurrentAdvert.HeatingTypeObjectId.HasValue ? CurrentAdvert.HeatingTypeObjectId.ToString() : "";
            ddlFuelTypeDevremulk.SelectedValue = CurrentAdvert.FuelTypeObjectId.HasValue ? CurrentAdvert.FuelTypeObjectId.ToString() : "";
            ddlAdvertStatusDevremulk.SelectedValue = CurrentAdvert.AdvertStatusObjectId.HasValue ? CurrentAdvert.AdvertStatusObjectId.ToString() : "";

            tbAgeDevremulk.Text = CurrentAdvert.Age.HasValue ? CurrentAdvert.Age.ToString() : "";
            tbbathCountDevremulk.Text = CurrentAdvert.BathCount.HasValue ? CurrentAdvert.BathCount.ToString() : "";
            ddlIsSubleaseDevremulk.SelectedValue = CurrentAdvert.IsSublease.HasValue ? ((bool)CurrentAdvert.IsSublease ? "1" : "0") : "";
        }
    }

    protected void BindTuristikBilgileri()
    {
        ddlStarCountTuristik.DataSource = DBProvider.GetStarCountList();
        ddlStarCountTuristik.DataBind();
        ddlStarCountTuristik.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlDeedTypeTuristik.DataSource = DBProvider.GetDeedTypeList();
        ddlDeedTypeTuristik.DataBind();
        ddlDeedTypeTuristik.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        if (CurrentAdvert != null)
        {
            ddlStarCountTuristik.SelectedValue = CurrentAdvert.StarCountObjectId.HasValue ? CurrentAdvert.StarCountObjectId.ToString() : "";
            ddlDeedTypeTuristik.SelectedValue = CurrentAdvert.DeedTypeObjectId.HasValue ? CurrentAdvert.DeedTypeObjectId.ToString() : "";
            tbRoomCountTuristik.Text = CurrentAdvert.RoomCount.HasValue ? CurrentAdvert.RoomCount.ToString() : "";
            tbBedCountTuristik.Text = CurrentAdvert.BedCount.HasValue ? CurrentAdvert.BedCount.ToString() : "";
            ddlIsSettlementTuristik.SelectedValue = CurrentAdvert.IsSettlement.HasValue ? ((bool)CurrentAdvert.IsSettlement ? "1" : "0") : "";
        }
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
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTown.Items.Clear();

        if (ddlCity.SelectedValue != "")
        {
            ddlTown.DataSource = DBProvider.GetTownListByCityObjectId(Convert.ToInt32(ddlCity.SelectedValue));
            ddlTown.DataBind();
            ddlTown.Items.Insert(0, new ListItem("İlçe seçiniz", ""));
        }
        else
        {
            ddlTown.Items.Insert(0, new ListItem("Önce il seçiniz", ""));
        }
    }
    protected void ddlTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDistrict.Items.Clear();

        if (ddlTown.SelectedValue != "")
        {
            ddlDistrict.DataSource = DBProvider.GetDistrictListByTownObjectId(Convert.ToInt32(ddlTown.SelectedValue));
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("Semt seçiniz", ""));
        }
        else
        {
            ddlDistrict.Items.Insert(0, new ListItem("Önce ilçe seçiniz", ""));
        }
    }
    #endregion

    #region Button Clicks
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string _title = tbTitle.Text.Trim();
        string _description = tbDescription.Text.Trim();
        string _area = tbArea.Text.Trim();
        string _age = string.Empty;
        string _bathCount = string.Empty;
        string _floorCount = string.Empty;
        string _floor = string.Empty;
        string _heatingType = string.Empty;
        string _roomHall = string.Empty;
        string _estateType = hfSelectedEstateTypeId.Value;
        string _marketingType = ddlMarketingType.SelectedValue;
        string _depositPrice = tbDeposit.Text.Trim();
        string _depositCurreny = ddlDepositCurrency.SelectedValue;
        string _price = tbPrice.Text.Trim();
        string _priceCurreny = ddlPriceCurreny.SelectedValue;
        string _city = ddlCity.SelectedValue;
        string _town = ddlTown.SelectedValue;
        string _district = ddlDistrict.SelectedValue;
        string _lat = hfLat.Value;
        string _lng = hfLong.Value;
        string _gAddress = tbGAddress.Text.Trim();
        string _advertOwner = string.Empty;
        string _isFlatForLandMethod = string.Empty;
        string _creditType = string.Empty;
        string _deedType = string.Empty;
        string _isExchangable = string.Empty;
        string _fuelType = string.Empty;
        string _isSublease = string.Empty;
        string _advertStatus = string.Empty;
        string _advertUsing = string.Empty;
        string _starCount = string.Empty;
        string _isSettlement = string.Empty;
        string _bedCount = string.Empty;
        string _roomCount = string.Empty;


        if (!string.IsNullOrEmpty(_title) && !string.IsNullOrEmpty(_description) && !string.IsNullOrEmpty(_area) && !string.IsNullOrEmpty(_estateType) &&
            !string.IsNullOrEmpty(_marketingType) && !string.IsNullOrEmpty(_price) && !string.IsNullOrEmpty(_city) && !string.IsNullOrEmpty(_town) && !string.IsNullOrEmpty(_district))
        {
            int area = Convert.ToInt32(_area);
            int price = Convert.ToInt32(_price);
            int priceCurrency = Convert.ToInt32(_priceCurreny);
            int estateType = Convert.ToInt32(_estateType);
            int marketingType = Convert.ToInt32(_marketingType);
            int city = Convert.ToInt32(_city);
            int town = Convert.ToInt32(_town);
            int district = Convert.ToInt32(_district);
            District selectedDistrict = DBProvider.GetDistrictByObjectId(district);
            EstateType estateTypeObj = DBProvider.GetEstateTypeByObjectId(estateType);

            int? age = null, bathCount = null, floorCount = null, floor = null, heatingType = null, roomHall = null, deposit = null, depositCurrency = null, advertType = null;
            int? advertOwner = null, creditType = null, deedType = null, fuelType = null, advertStatus = null, advertUsing = null, starCount = null, bedCount = null, roomCount = null;
            bool? isFlatForLandMethod = null, isExchangable = null, isSublease = null, isSettlement = null;

            if (!string.IsNullOrEmpty(_depositPrice))
                deposit = Convert.ToInt32(_depositPrice);
            if (!string.IsNullOrEmpty(_depositCurreny))
                depositCurrency = Convert.ToInt32(_depositCurreny);

            switch (estateTypeObj.ParentEstateType.TypeKey)
            {
                case "konut":
                    #region Konut Case
                    _floor = ddlFloorKonut.SelectedValue;
                    _floorCount = tbFloorCountKonut.Text.Trim();
                    _age = tbAgeKonut.Text.Trim();
                    _roomHall = ddlRoomHallKonut.SelectedValue;
                    _bathCount = tbBathCountKonut.Text.Trim();
                    _advertOwner = ddlAdvertOwner.SelectedValue;
                    _heatingType = ddlHeatingTypeKonut.SelectedValue;
                    _fuelType = ddlFuelTypeKonut.SelectedValue;
                    _advertStatus = ddlAdvertStatusKonut.SelectedValue;
                    _advertUsing = ddlAdvertUsingKonut.SelectedValue;
                    _creditType = ddlCreditTypeKonut.SelectedValue;
                    _deedType = ddlDeedTypeKonut.SelectedValue;

                    if (!string.IsNullOrEmpty(_floor))
                        floor = Convert.ToInt32(_floor);

                    if (!string.IsNullOrEmpty(_floorCount))
                        floorCount = Convert.ToInt32(_floorCount);

                    if (!string.IsNullOrEmpty(_age))
                        age = Convert.ToInt32(_age);

                    if (!string.IsNullOrEmpty(_roomHall))
                        roomHall = Convert.ToInt32(_roomHall);

                    if (!string.IsNullOrEmpty(_bathCount))
                        bathCount = Convert.ToInt32(_bathCount);

                    if (!string.IsNullOrEmpty(_advertOwner))
                        advertOwner = Convert.ToInt32(_advertOwner);

                    if (!string.IsNullOrEmpty(_heatingType))
                        heatingType = Convert.ToInt32(_heatingType);

                    if (!string.IsNullOrEmpty(_fuelType))
                        fuelType = Convert.ToInt32(_fuelType);

                    if (!string.IsNullOrEmpty(_advertStatus))
                        advertStatus = Convert.ToInt32(_advertStatus);

                    if (!string.IsNullOrEmpty(_advertUsing))
                        advertUsing = Convert.ToInt32(_advertUsing);

                    if (!string.IsNullOrEmpty(_creditType))
                        creditType = Convert.ToInt32(_creditType);

                    if (!string.IsNullOrEmpty(_deedType))
                        deedType = Convert.ToInt32(_deedType);

                    isExchangable = _isExchangable == "1" ? true : false;
                    #endregion                    
                    break;
                case "isyeri":
                    #region İşyeri Case
                    _floor = ddlFloorIsyeri.SelectedValue;
                    _age = tbAgeIsyeri.Text.Trim();
                    _roomCount = tbRoomCountIsyeri.Text.Trim();
                    _heatingType = ddlHeatingTypeIsyeri.SelectedValue;
                    _fuelType = ddlFuelTypeIsyeri.SelectedValue;
                    _advertStatus = ddlAdvertStatusIsyeri.SelectedValue;
                    _advertUsing = ddlAdvertUsingIsyeri.SelectedValue;
                    _creditType = ddlCreditTypeIsyeri.SelectedValue;
                    _isSublease = ddlIsSubleaseIsyeri.SelectedValue;

                    if (!string.IsNullOrEmpty(_floor))
                        floor = Convert.ToInt32(_floor);

                    if (!string.IsNullOrEmpty(_age))
                        age = Convert.ToInt32(_age);

                    if (!string.IsNullOrEmpty(_roomCount))
                        roomCount = Convert.ToInt32(_roomCount);

                    if (!string.IsNullOrEmpty(_heatingType))
                        heatingType = Convert.ToInt32(_heatingType);

                    if (!string.IsNullOrEmpty(_fuelType))
                        fuelType = Convert.ToInt32(_fuelType);

                    if (!string.IsNullOrEmpty(_advertStatus))
                        advertStatus = Convert.ToInt32(_advertStatus);

                    if (!string.IsNullOrEmpty(_advertUsing))
                        advertUsing = Convert.ToInt32(_advertUsing);

                    if (!string.IsNullOrEmpty(_creditType))
                        creditType = Convert.ToInt32(_creditType);

                    if (!string.IsNullOrEmpty(_isSublease))
                        isSublease = _isSublease == "1" ? true : false;
                    #endregion                    
                    break;
                case "arsa":
                    #region Arsa Case
                    _isFlatForLandMethod = rdbtnIsFlatForLandMethod.SelectedValue;
                    _deedType = ddlDeedTypeArsa.SelectedValue;
                    _creditType = ddlCreditTypeArsa.SelectedValue;

                    if (!string.IsNullOrEmpty(_isFlatForLandMethod))
                        isFlatForLandMethod = _isFlatForLandMethod == "1" ? true : false;

                    if (!string.IsNullOrEmpty(_deedType))
                        deedType = Convert.ToInt32(_deedType);

                    if (!string.IsNullOrEmpty(_creditType))
                        creditType = Convert.ToInt32(_creditType);
                    #endregion
                    break;
                case "devremulk":
                    #region Devremülk Case
                    
                    _floor = ddlFloorDevremulk.SelectedValue;
                    _roomHall = ddlRoomHallDevremulk.SelectedValue;
                    _bathCount = tbbathCountDevremulk.Text.Trim();
                    _isSublease = ddlIsSubleaseDevremulk.SelectedValue;
                    _heatingType = ddlHeatingTypeDevremulk.SelectedValue;
                    _fuelType = ddlFuelTypeDevremulk.SelectedValue;
                    _advertStatus = ddlAdvertStatusDevremulk.SelectedValue;

                    if (!string.IsNullOrEmpty(_floor))
                        floor = Convert.ToInt32(_floor);

                    if (!string.IsNullOrEmpty(_roomHall))
                        roomHall = Convert.ToInt32(_roomHall);

                    if (!string.IsNullOrEmpty(_bathCount))
                        bathCount = Convert.ToInt32(_bathCount);

                    if (!string.IsNullOrEmpty(_isSublease))
                        isSublease = _isSublease == "1" ? true : false;

                    if (!string.IsNullOrEmpty(_heatingType))
                        heatingType = Convert.ToInt32(_heatingType);

                    if (!string.IsNullOrEmpty(_fuelType))
                        fuelType = Convert.ToInt32(_fuelType);

                    if (!string.IsNullOrEmpty(_advertStatus))
                        advertStatus = Convert.ToInt32(_advertStatus);

                    #endregion
                    break;
                case "turistik-isletme":
                    #region Turistik İşletme Case

                    _roomCount = tbRoomCountTuristik.Text.Trim();
                    _starCount = ddlStarCountTuristik.SelectedValue;
                    _bedCount = tbBedCountTuristik.Text.Trim();
                    _deedType = ddlDeedTypeTuristik.SelectedValue;
                    _isSettlement = ddlIsSettlementTuristik.SelectedValue;


                    if (!string.IsNullOrEmpty(_roomCount))
                        roomCount = Convert.ToInt32(_roomCount);

                    if (!string.IsNullOrEmpty(_starCount))
                        starCount = Convert.ToInt32(_starCount);

                    if (!string.IsNullOrEmpty(_bedCount))
                        bedCount = Convert.ToInt32(_bedCount);

                    if (!string.IsNullOrEmpty(_deedType))
                        deedType = Convert.ToInt32(_deedType);

                    if (!string.IsNullOrEmpty(_isSettlement))
                        isSettlement = _isSettlement == "1" ? true : false;

                    #endregion
                    break;
                default:
                    break;
            }

            if (CurrentAdvert == null)
            {
                #region Create Advert
                
                Advert advert = DBProvider.AddAdvert(_title, _description, area, age, heatingType, roomHall, marketingType, estateType, floor, advertType, bathCount, floorCount, deposit, depositCurrency, price, priceCurrency, CurrentPerson.ObjectId, _lat, _lng, _gAddress, district, town, city, selectedDistrict.Town.City.CityName, selectedDistrict.Town.TownName, selectedDistrict.DistrictName, advertOwner, isFlatForLandMethod, creditType, deedType, isExchangable, fuelType, isSublease, advertStatus, advertUsing, starCount, isSettlement, bedCount, roomCount);

                advert.ParentEstateTypeObjectId = estateTypeObj.ParentEstateTypeObjectId;
                if (advert != null)
                {
                    advert.AdvertNumber = advert.ObjectId.ToString() + "-" + advert.AdvertNumber;
                    foreach (RepeaterItem rItem in rptFeatureTypeTabs.Items)
                    {
                        CheckBoxList cbList = rItem.FindControl("cblFeatureList") as CheckBoxList;
                        foreach (ListItem lItem in cbList.Items)
                        {
                            if(lItem.Selected)
                                DBProvider.AddAdvertFeatureRelation(advert.ObjectId, Convert.ToInt32(lItem.Value));
                        }
                    }
                    DBProvider.SaveChanges();
                    Response.Redirect("data.aspx?advert=" + advert.ObjectId.ToString() + "&advert_status=0&tab=tab2");
                }

                #endregion
            }
            else
            {
                #region Edit Advert

                CurrentAdvert.Title = _title;
                CurrentAdvert.Description = _description;
                CurrentAdvert.Area = area;
                CurrentAdvert.Age = age;
                CurrentAdvert.BathCount = bathCount;
                CurrentAdvert.FloorCount = floorCount;
                CurrentAdvert.FloorObjectId = floor;
                CurrentAdvert.HeatingTypeObjectId = heatingType;
                CurrentAdvert.RoomHallObjectId = roomHall;
                CurrentAdvert.EstateTypeObjectId = estateType;
                CurrentAdvert.MarketingTypeObjectId = marketingType;
                CurrentAdvert.Deposit = deposit;
                CurrentAdvert.DepositCurrencyObjectId = depositCurrency;
                CurrentAdvert.Price = price;
                CurrentAdvert.PriceCurrencyObjectId = priceCurrency;
                CurrentAdvert.CityObjectId = city;
                CurrentAdvert.TownObjectId = town;
                CurrentAdvert.DistrictObjectId = district;
                CurrentAdvert.Latitude = _lat;
                CurrentAdvert.Longitude = _lng;
                CurrentAdvert.GAddress = _gAddress;
                CurrentAdvert.UpdateDate = DateTime.Now;
                CurrentAdvert.CityName = selectedDistrict.Town.City.CityName;
                CurrentAdvert.TownName = selectedDistrict.Town.TownName;
                CurrentAdvert.DistrictName = selectedDistrict.DistrictName;
                CurrentAdvert.IsFlatForLandMethod = isFlatForLandMethod;
                CurrentAdvert.CreditTypeObjectId = creditType;
                CurrentAdvert.DeedTypeObjectId = deedType;
                CurrentAdvert.IsExchangable = isExchangable;
                CurrentAdvert.FuelTypeObjectId = fuelType;
                CurrentAdvert.IsSublease = isSublease;
                CurrentAdvert.AdvertStatusObjectId = advertStatus;
                CurrentAdvert.AdvertUsingTypeObjectId = advertUsing;
                CurrentAdvert.StarCountObjectId = starCount;
                CurrentAdvert.IsSettlement = isSettlement;
                CurrentAdvert.BedCount = bedCount;
                CurrentAdvert.RoomCount = roomCount;
                CurrentAdvert.ParentEstateTypeObjectId = estateTypeObj.ParentEstateTypeObjectId;

                foreach (RepeaterItem rItem in rptFeatureTypeTabs.Items)
                {
                    CheckBoxList cbList = rItem.FindControl("cblFeatureList") as CheckBoxList;
                    foreach (ListItem lItem in cbList.Items)
                    {
                        int val = Convert.ToInt32(lItem.Value);
                        if (lItem.Selected && CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) == null)
                        {
                            DBProvider.AddAdvertFeatureRelation(CurrentAdvert.ObjectId, val);
                        }
                        else if (!lItem.Selected && CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) != null)
                        {
                            CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val).Delete();
                        }
                    }
                }


                DBProvider.SaveChanges();
                BindData();
                SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, ApplicationGenericControls.OperationStatus.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
                #endregion
            }
        }
    }

    protected void btnSavePicture_Click(object sender, EventArgs e)
    {
        string[] allowedExtensions = new string[] { "jpg", "gif", "jpeg", "png" };
        if (fuPic.HasFile && _validExtensions.Contains(fuPic.PostedFile.ContentType))
        {
            FileProcess fp = new FileProcess();
            string pic = fp.UploadImageConstantSize(fuPic.PostedFile.InputStream, 570, 425, "~/uploads/");
            string picSmall = fp.UploadImageConstantSize(fuPic.PostedFile.InputStream, 270, 201, "~/uploads/");

            if (!string.IsNullOrEmpty(pic))
            {
                AdvertPhoto photo = DBProvider.AddAdvertPhoto(pic, picSmall, CurrentAdvert.ObjectId, null, 0);
                DBProvider.SaveChanges();
                if (photo != null)
                {
                    SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, ApplicationGenericControls.Operations.AdvertPhoto.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
                    BindAdvertPhotos();
                }
                else
                {
                    SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusERRORTitle, ApplicationGenericControls.Operations.AdvertPhoto.StatusERRORDescription, ApplicationGenericControls.OperationStatus.StatusERRORCSS);
                }
            }
        }
        else
        {
            SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusERRORTitle, ApplicationGenericControls.Operations.AdvertPhoto.StatusERRORDescription, ApplicationGenericControls.OperationStatus.StatusERRORCSS);
        }

        string script = "setTab('tab2');";
        RegisterStartupScript("setTabKey", script);
    }

    protected void btnSelectBaseEstateType_Click(object sender, EventArgs e)
    {
        int estateTypeId = Convert.ToInt32(hfSelectedEstateTypeId.Value);
        EstateType estateType = DBProvider.GetEstateTypeByObjectId(estateTypeId);
        hfSelectedEstateTypeName.Value = estateType.TypeName;
        SetPanels(estateType.ParentEstateType.TypeKey);
        BindFeatures((int)estateType.ParentEstateTypeObjectId);
    }

    protected void btnActivateAdvert_Click(object sender, EventArgs e)
    {
        CurrentAdvert.IsActive = true;
        DBProvider.SaveChanges();
        Response.Redirect("~/admin/advert/data.aspx?advert=" + CurrentAdvert.ObjectId.ToString());
    }
    #endregion

    #region Repeater Events
    protected void rptAdvertPhotos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deletePhoto")
        {
            int photoId = Convert.ToInt32(e.CommandArgument);
            AdvertPhoto photo = DBProvider.GetAdvertPhotoByObjectId(photoId);
            photo.Delete();
            DBProvider.SaveChanges();

            BindAdvertPhotos();
            SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, ApplicationGenericControls.Operations.AdvertPhoto.StatusDELETEDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
            string script = "setTab('tab2');";
            RegisterStartupScript("setTabKey", script);
        }
    }

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