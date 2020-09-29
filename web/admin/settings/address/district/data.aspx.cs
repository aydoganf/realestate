using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_address_district_data : BasePage
{

    //private District currentDistrict;
    //public District CurrentDistrict
    //{
    //    get
    //    {
    //        if (currentDistrict == default(District))
    //        {
    //            if (Request.QueryString["district"] != null)
    //            {
    //                currentDistrict = DBProvider.GetDistrictByObjectId(Convert.ToInt32(Request.QueryString["district"]));
    //            }
    //            else
    //            {
    //                currentDistrict = null;
    //            }
    //        }
    //        return currentDistrict;
    //    }
    //}

    private REModel.Old.Api.KeyValueStore _currentDistrict;
    public REModel.Old.Api.KeyValueStore CurrentDistrict
    {
        get
        {
            if (_currentDistrict == null)
            {
                if (Request.QueryString["district"] != null)
                {
                    _currentDistrict = _keyValueStoreApi.GetById(
                        authorization: "",
                        id: Guid.Parse(Request.QueryString["district"].ToString())).Result.Response;
                }
            }

            return _currentDistrict;
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
        ddlCityList.DataSource = GetKeyValueStores("city");
        ddlCityList.DataBind();
        ddlCityList.Items.Insert(0, new ListItem("Seçiniz", ""));


        if (CurrentDistrict != null)
        {
            var town = _keyValueStoreApi.GetParentById(
                authorization: "",
                id: CurrentDistrict.Id).Result.Response;

            ddlCityList.SelectedValue = town.Parent;

            ddlTownList.DataSource = _keyValueStoreApi.GetByTypeAndParent(
                authorization: "",
                type: "town",
                parent: town.Parent).Result.Response;
                //DBProvider.GetTownListByCityObjectId(CurrentDistrict.Town.CityObjectId);
            ddlTownList.DataBind();
           
            ddlTownList.SelectedValue = town.Value;

            tbDistrictName.Text = CurrentDistrict.Key;
        }
        else
        {
            pnlAddPart.Visible = true;
            ddlTownList.Items.Insert(0, new ListItem("Önce İl Seçiniz", ""));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentDistrict != null)
        {
            CurrentDistrict.Key = tbDistrictName.Text.Trim();
            CurrentDistrict.Value = tbDistrictName.Text.Trim();
            CurrentDistrict.Parent = ddlTownList.SelectedValue;

            var updated = _keyValueStoreApi.Update(
                authorization: "",
                id: CurrentDistrict.Id,
                obj: CurrentDistrict).Result.Response;
        }
        else
        {
            if (cbAddMultiple.Checked)
            {
                string districts = tbDistricts.Text.Trim();
                string[] districtArr = districts.Split(',');
                foreach (string district in districtArr)
                {
                    _keyValueStoreApi.Add(
                        authorization: "",
                        obj: new REModel.Old.Api.KeyValueStore()
                        {
                            Key = district,
                            Value = district,
                            Type = "district",
                            Parent = ddlTownList.SelectedValue
                        });
                }                
            }
            else
            {
                var added = _keyValueStoreApi.Add(
                    authorization: "",
                    obj: new REModel.Old.Api.KeyValueStore()
                    {
                        Key = tbDistrictName.Text.Trim(),
                        Value = tbDistrictName.Text.Trim(),
                        Type = "district",
                        Parent = ddlTownList.SelectedValue
                    }).Result.Response;

                //DBProvider.AddDistrict(tbDistrictName.Text.Trim(), Convert.ToInt32(ddlTownList.SelectedValue));
            }            
        }
        //DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
    protected void ddlCityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTownList.Items.Clear();
        if (ddlCityList.SelectedValue != "")
        {
            ddlTownList.DataSource = GetKeyValueStores("town", ddlCityList.SelectedValue); //DBProvider.GetTownListByCityObjectId(Convert.ToInt32(ddlCityList.SelectedValue));
            ddlTownList.DataBind();
        }
        else
        {
            ddlTownList.Items.Insert(0, new ListItem("Önce İl Seçiniz", ""));
        }
    }
}