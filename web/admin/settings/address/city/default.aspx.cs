using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class address_city_default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        rptCity.DataSource = _keyValueStoreApi.GetByType(authorization: "", type: "city").Result.Response;  //DBProvider.GetCityList();
        rptCity.DataBind();
    }

    protected void rptCity_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int cityId = Convert.ToInt32(e.CommandArgument);
            City obj = DBProvider.GetCityByObjectId(cityId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}