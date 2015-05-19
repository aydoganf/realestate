using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class advert_data : BasePage
{
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            SetTab();
        }
    }

    #region Helpers
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

        ddlFloor.DataSource = DBProvider.GetFloorList();
        ddlFloor.DataBind();
        ddlFloor.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlHeatingType.DataSource = DBProvider.GetHeatingTypeList();
        ddlHeatingType.DataBind();
        ddlHeatingType.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlRoomHall.DataSource = DBProvider.GetRoomHallList();
        ddlRoomHall.DataBind();
        ddlRoomHall.Items.Insert(0, new ListItem("Seçebilirsiniz", ""));

        ddlEstateType.DataSource = DBProvider.GetEstateTypeList();
        ddlEstateType.DataBind();

        ddlMarketingType.DataSource = DBProvider.GetMarketingTypeList();
        ddlMarketingType.DataBind();

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
        #endregion

        #region Features

        List<Feature> featureList = DBProvider.GetFeatureList();
        foreach (Feature item in featureList)
        {
            if (item.FeatureTypeObjectId == (int)Feature.TypeOf.Ic)
            {
                cblIcOzellikler.Items.Add(new ListItem(item.FeatureName, item.ObjectId.ToString()));
            }
            else if (item.FeatureTypeObjectId == (int)Feature.TypeOf.Dis)
            {
                cblDisOzellikler.Items.Add(new ListItem(item.FeatureName, item.ObjectId.ToString()));
            }
            else if (item.FeatureTypeObjectId == (int)Feature.TypeOf.Konum)
            {
                cblKonumOzellikleri.Items.Add(new ListItem(item.FeatureName, item.ObjectId.ToString()));
            }

        }
        #endregion

        if (CurrentAdvert == null)
        {
            pnlNoAdvert.Visible = true;
        }
        else
        {
            #region AdvertDetails
            tbTitle.Text = CurrentAdvert.Title;
            tbDescription.Text = CurrentAdvert.Description;
            tbArea.Text = CurrentAdvert.Area.ToString();
            tbAge.Text = CurrentAdvert.Age.ToString();
            tbBathCount.Text = CurrentAdvert.BathCount.HasValue ? CurrentAdvert.BathCount.ToString() : "";
            tbFloorCount.Text = CurrentAdvert.FloorCount.HasValue ? CurrentAdvert.FloorCount.ToString() : "";
            ddlFloor.SelectedValue = CurrentAdvert.FloorObjectId.HasValue ? CurrentAdvert.FloorObjectId.ToString() : "";
            ddlHeatingType.SelectedValue = CurrentAdvert.HeatingTypeObjectId.HasValue ? CurrentAdvert.HeatingTypeObjectId.ToString() : "";
            ddlRoomHall.SelectedValue = CurrentAdvert.RoomHallObjectId.HasValue ? CurrentAdvert.RoomHallObjectId.ToString() : "";
            ddlEstateType.SelectedValue = CurrentAdvert.EstateTypeObjectId.ToString();
            ddlMarketingType.SelectedValue = CurrentAdvert.MarketingTypeObjectId.ToString();
            tbDeposit.Text = CurrentAdvert.Deposit.HasValue ? CurrentAdvert.Deposit.ToString() : "";
            ddlDepositCurrency.SelectedValue = CurrentAdvert.DepositCurrencyObjectId.HasValue ? CurrentAdvert.DepositCurrencyObjectId.ToString() : "1";
            tbPrice.Text = CurrentAdvert.Price.ToString();
            ddlPriceCurreny.SelectedValue = CurrentAdvert.PriceCurrencyObjectId.ToString();
            ddlCity.SelectedValue = CurrentAdvert.CityObjectId.ToString();
            ddlTown.SelectedValue = CurrentAdvert.TownObjectId.ToString();
            ddlDistrict.SelectedValue = CurrentAdvert.DistrictObjectId.ToString();
            hfLat.Value = CurrentAdvert.Latitude;
            hfLong.Value = CurrentAdvert.Longitude;
            tbGAddress.Text = CurrentAdvert.GAddress;
            hfCurrentAdvert.Value = CurrentAdvert.ObjectId.ToString();
            #region AdvertFeatures
            List<AdvertFeatureRelation> relation = DBProvider.GetAdvertFeatureRelationListByAdvertObjectId(CurrentAdvert.ObjectId);
            foreach (ListItem item in cblIcOzellikler.Items)
            {
                if (relation.FirstOrDefault(i => i.FeatureObjectId == Convert.ToInt32(item.Value)) != null)
                    item.Selected = true;
            }
            foreach (ListItem item in cblDisOzellikler.Items)
            {
                if (relation.FirstOrDefault(i => i.FeatureObjectId == Convert.ToInt32(item.Value)) != null)
                    item.Selected = true;
            }
            foreach (ListItem item in cblKonumOzellikleri.Items)
            {
                if (relation.FirstOrDefault(i => i.FeatureObjectId == Convert.ToInt32(item.Value)) != null)
                    item.Selected = true;
            }
            #endregion
            #endregion

            #region AdvertPhotos
            pnlAdvertPhoto.Visible = true;
            if (Request.QueryString["advert_status"] == "0")
            {
                pnlAdvertAdded.Visible = true;
            }
            #endregion
        }
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

    #region ButtonClicks
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string _title = tbTitle.Text.Trim();
        string _description = tbDescription.Text.Trim();
        string _area = tbArea.Text.Trim();
        string _age = tbAge.Text.Trim();
        string _bathCount = tbBathCount.Text.Trim();
        string _floorCount = tbFloorCount.Text.Trim();
        string _floor = ddlFloor.SelectedValue;
        string _heatingType = ddlHeatingType.SelectedValue;
        string _roomHall = ddlRoomHall.SelectedValue;
        string _estateType = ddlEstateType.SelectedValue;
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

        if (!string.IsNullOrEmpty(_title) &&
            !string.IsNullOrEmpty(_description) &&
            !string.IsNullOrEmpty(_area) &&
            !string.IsNullOrEmpty(_age) &&
            !string.IsNullOrEmpty(_estateType) &&
            !string.IsNullOrEmpty(_marketingType) &&
            !string.IsNullOrEmpty(_price) &&
            !string.IsNullOrEmpty(_city) &&
            !string.IsNullOrEmpty(_town) &&
            !string.IsNullOrEmpty(_district))
        {
            int area = Convert.ToInt32(_area);
            int age = Convert.ToInt32(_age);
            int? bathCount = null, floorCount = null, floor = null, heatingType = null, roomHall = null, deposit = null, depositCurrency = null, advertType = null;

            if (!string.IsNullOrEmpty(_bathCount))
                bathCount = Convert.ToInt32(_bathCount);
            if (!string.IsNullOrEmpty(_floorCount))
                floorCount = Convert.ToInt32(_floorCount);
            if (!string.IsNullOrEmpty(_floor))
                floor = Convert.ToInt32(_floor);
            if (!string.IsNullOrEmpty(_heatingType))
                heatingType = Convert.ToInt32(_heatingType);
            if (!string.IsNullOrEmpty(_roomHall))
                roomHall = Convert.ToInt32(_roomHall);
            if (!string.IsNullOrEmpty(_depositPrice))
                deposit = Convert.ToInt32(_depositPrice);
            if (!string.IsNullOrEmpty(_depositCurreny))
                depositCurrency = Convert.ToInt32(_depositCurreny);

            int price = Convert.ToInt32(_price);
            int priceCurrency = Convert.ToInt32(_priceCurreny);
            int estateType = Convert.ToInt32(_estateType);
            int marketingType = Convert.ToInt32(_marketingType);
            int city = Convert.ToInt32(_city);
            int town = Convert.ToInt32(_town);
            int district = Convert.ToInt32(_district);

            if (CurrentAdvert == null)
            {
                #region CreateAdvert
                Advert advert = DBProvider.AddAdvert(_title, _description, area, age, heatingType, roomHall, marketingType, estateType, floor, advertType, bathCount, floorCount, deposit, depositCurrency, price, priceCurrency, CurrentPerson.ObjectId, _lat, _lng, _gAddress, district, town, city);
                DBProvider.SaveChanges();

                if (advert != null)
                {
                    foreach (ListItem item in cblIcOzellikler.Items)
                    {
                        if (item.Selected)
                            DBProvider.AddAdvertFeatureRelation(advert.ObjectId, Convert.ToInt32(item.Value));
                    }
                    foreach (ListItem item in cblDisOzellikler.Items)
                    {
                        if (item.Selected)
                            DBProvider.AddAdvertFeatureRelation(advert.ObjectId, Convert.ToInt32(item.Value));
                    }
                    foreach (ListItem item in cblKonumOzellikleri.Items)
                    {
                        if (item.Selected)
                            DBProvider.AddAdvertFeatureRelation(advert.ObjectId, Convert.ToInt32(item.Value));
                    }
                    advert.AdvertNumber = advert.ObjectId.ToString() + "-" + advert.AdvertNumber;
                    DBProvider.SaveChanges();
                    Response.Redirect("data.aspx?advert=" + advert.ObjectId.ToString() + "&advert_status=0&tab=tab2");
                }
                #endregion
            }
            else
            {
                #region EditAdvert

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

                foreach (ListItem item in cblIcOzellikler.Items)
                {
                    int val = Convert.ToInt32(item.Value);
                    if (item.Selected && CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) == null)
                    {
                        DBProvider.AddAdvertFeatureRelation(CurrentAdvert.ObjectId, val);
                    }
                    else if (CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) != null)
                    {
                        CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val).Delete();
                    }
                }
                foreach (ListItem item in cblDisOzellikler.Items)
                {
                    int val = Convert.ToInt32(item.Value);
                    if (item.Selected && CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) == null)
                    {
                        DBProvider.AddAdvertFeatureRelation(CurrentAdvert.ObjectId, val);
                    }
                    else if (CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) != null)
                    {
                        CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val).Delete();
                    }
                }
                foreach (ListItem item in cblKonumOzellikleri.Items)
                {
                    int val = Convert.ToInt32(item.Value);
                    if (item.Selected && CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) == null)
                    {
                        DBProvider.AddAdvertFeatureRelation(CurrentAdvert.ObjectId, val);
                    }
                    else if (CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val) != null)
                    {
                        CurrentAdvert.AdvertFeatureRelation.Where(i => i.Deleted == false).FirstOrDefault(i => i.FeatureObjectId == val).Delete();
                    }
                }
                DBProvider.SaveChanges();

                #endregion
            }
        }
        else
        {

        }
    }

    protected void btnSavePicture_Click(object sender, EventArgs e)
    {
        string[] allowedExtensions = new string[] { "jpg", "gif", "jpeg", "png" };
        if (fuPic.HasFile && _validExtensions.Contains(fuPic.PostedFile.ContentType))
        {
            FileProcess fp = new FileProcess();
            string pic = fp.UploadImage(fuPic.PostedFile.InputStream, 570, 425, "uploadPath");
        }
    }
    #endregion

    
}