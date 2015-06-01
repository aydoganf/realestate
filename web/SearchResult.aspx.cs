using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class SearchResult : BasePage
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
        SearchQuery searchQuery = new SearchQuery(
            RouteData.Values["cityId"], 
            RouteData.Values["townId"], 
            RouteData.Values["districtId"], 
            RouteData.Values["estateTypeId"], 
            RouteData.Values["marketingTypeId"], 
            RouteData.Values["area"], 
            RouteData.Values["price"], 
            RouteData.Values["priceCurrencyId"]);

        List<Advert> searchResult = DBProvider.QuickSearchAdvert(searchQuery);

        rptAdverts.DataSource = searchResult;
        rptAdverts.DataBind();
        (this.Master as Site).BindSearchedData(searchQuery);
    }
}