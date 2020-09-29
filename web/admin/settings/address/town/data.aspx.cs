using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using REModel.Old.Api;

[AuthenticationRequired()]
public partial class settings_address_town_data : BasePage
{
    //private Town currentTown;
    //public Town CurrentTown
    //{
    //    get 
    //    {
    //        if (currentTown == default(Town))
    //        {
    //            if (Request.QueryString["town"] != null)
    //            {
    //                currentTown = DBProvider.GetTownByObjectId(Convert.ToInt32(Request.QueryString["town"]));
    //            }
    //            else
    //            {
    //                currentTown = null;
    //            }
    //        }
    //        return currentTown; 
    //    }
    //}

    private REModel.Old.Api.KeyValueStore _currentTown;
    public REModel.Old.Api.KeyValueStore CurrentTown
    {
        get
        {
            if (_currentTown == null)
            {
                if (Request.QueryString["town"] != null)
                {
                    _currentTown = _keyValueStoreApi.GetById(
                        authorization: "",
                        id: Guid.Parse(Request.QueryString["town"].ToString())).Result.Response;
                }
            }

            return _currentTown;
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
        ddlCityList.DataSource = _keyValueStoreApi.GetByType(
            authorization: "",
            type: "city").Result.Response;
        ddlCityList.DataBind();

        if (CurrentTown != null)
        {
            tbTownName.Text = CurrentTown.Key;
            tbTownValue.Text = CurrentTown.Value;

            ddlCityList.SelectedValue = CurrentTown.Parent;

            pnlDistrictList.Visible = true;

            rptDistrict.DataSource = _keyValueStoreApi.GetByTypeAndParent(
                authorization: "",
                parent: CurrentTown.Value,
                type: "district").Result.Response;
            rptDistrict.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentTown != null)
        {
            //CurrentTown.TownName = tbTownName.Text.Trim();
            //CurrentTown.CityObjectId = Convert.ToInt32(ddlCityList.SelectedValue);
        }
        else
        {
            var added = _keyValueStoreApi.Add(
                authorization: "",
                obj: new REModel.Old.Api.KeyValueStore()
                {
                    Key = tbTownName.Text.Trim(),
                    Parent = ddlCityList.SelectedValue,
                    Type = "town",
                    Value = tbTownValue.Text.Trim()
                }).Result.Response;
            //DBProvider.AddTown(tbTownName.Text.Trim(), Convert.ToInt32(ddlCityList.SelectedValue));
        }
        //DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }

    protected void rptDistrict_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            //int districtId = Convert.ToInt32(e.CommandArgument);
            //District obj = DBProvider.GetDistrictByObjectId(districtId);

            //obj.Delete();
            //DBProvider.SaveChanges();

            Guid districtId = Guid.Parse(e.CommandArgument.ToString());

            _keyValueStoreApi.Delete(
                authorization: "",
                id: districtId).GetAwaiter().GetResult();

            BindData();
        }
    }
}