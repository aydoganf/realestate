using System;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_address_city_data : BasePage
{
    //private City currentCity;
    //public City CurrentCity
    //{
    //    get
    //    {
    //        if (currentCity == default(City))
    //        {
    //            if (Request.QueryString["city"] != null)
    //            {
    //                currentCity = DBProvider.GetCityByObjectId(Convert.ToInt32(Request.QueryString["city"]));
    //            }
    //            else
    //            {
    //                currentCity = null;
    //            }
    //        }
    //        return currentCity;
    //    }
    //}

    private REModel.Old.Api.KeyValueStore _currentCity;
    public REModel.Old.Api.KeyValueStore CurrentCity
    {
        get
        {
            if (_currentCity == null)
            {
                if (Request.QueryString["city"] != null)
                {
                    _currentCity = _keyValueStoreApi
                        .GetById(
                            authorization: "", 
                            id: Guid.Parse(Request.QueryString["city"].ToString()))
                        .Result
                        .Response;
                }
            }

            return _currentCity;
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
        if (CurrentCity != null)
        {
            tbCityName.Text = CurrentCity.Key;
            tbCityValue.Text = CurrentCity.Value;
            pnlTownList.Visible = true;

            rptTown.DataSource = _keyValueStoreApi.GetByTypeAndParent(
                authorization: "",
                parent: CurrentCity.Value,
                type: "town").Result.Response;

            rptTown.DataBind();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentCity != null)
        {
            CurrentCity.Key = tbCityName.Text.Trim();
            CurrentCity.Value = tbCityValue.Text.Trim();

            var response = _keyValueStoreApi.Update(
                authorization: "",
                id: CurrentCity.Id,
                obj: CurrentCity).Result.Response;
        }
        else
        {
            _keyValueStoreApi.Add(
                authorization: "",
                obj: new REModel.Old.Api.KeyValueStore() 
                {
                    Key = tbCityName.Text.Trim(),
                    Value = tbCityValue.Text.Trim()
                });

            //DBProvider.AddCity(tbCityName.Text.Trim(), DBProvider.City.OrderByDescending(i=> i.SortOrder).FirstOrDefault().SortOrder + 1);
        }

        //DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }

    protected void rptTown_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            //int townId = Convert.ToInt32(e.CommandArgument);
            //Town town = DBProvider.GetTownByObjectId(townId);

            //if (town != null)
            //    town.Delete();
            //DBProvider.SaveChanges();

            Guid townId = Guid.Parse(e.CommandArgument.ToString());
            _keyValueStoreApi.Delete(
                authorization: "",
                id: townId).GetAwaiter().GetResult();

            BindData();
        }
    }
}