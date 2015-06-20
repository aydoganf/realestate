using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Configuration;

public partial class SearchResult : BasePage
{
    private string _searchModeKey;
    public string searchModeKey
    {
        get 
        {
            if (string.IsNullOrEmpty(_searchModeKey))
            {
                _searchModeKey = RouteData.Values["mode"].ToString();
            }
            return _searchModeKey; 
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
        //if (searchModeKey == ConfigurationManager.AppSettings["searchMode_quick"])
        //{
        //    SearchQuick();
        //}
        //else if (searchModeKey == ConfigurationManager.AppSettings["searchMode_advanced"])
        //{
            //int page = Convert.ToInt32(RouteData.Values["page"]);
            //SearchAdvanced(page);
        //}        
        int page = Convert.ToInt32(RouteData.Values["page"]);
        SearchAdvanced(page);
    }

    protected void SearchQuick()
    {
        //SearchQuery searchQuery = new SearchQuery(RouteData.Values["cityId"], RouteData.Values["townId"], RouteData.Values["districtId"], RouteData.Values["estateTypeId"],
        //    RouteData.Values["marketingTypeId"], RouteData.Values["area"], RouteData.Values["price"], RouteData.Values["priceCurrencyId"]);

        //List<Advert> searchResult = DBProvider.QuickSearchAdvert(searchQuery);
        //rptAdverts.DataSource = searchResult;
        //rptAdverts.DataBind();
        //(this.Master as Site).BindSearchedData(searchQuery, ConfigurationManager.AppSettings["searchMode_quick"]);
    }

    protected void SearchAdvanced(int page)
    {
        SearchQuery searchQuery = GetSearchQueryFromHash(Request.QueryString["q"]);

        List<Advert> searchResult = DBProvider.AdvancedSearchAdvert(searchQuery, page, 20);
        rptAdverts.DataSource = searchResult;
        rptAdverts.DataBind();

        EstateType _estateType = DBProvider.GetEstateTypeByObjectId(searchQuery.EstateTypeId);

        Site master = Page.Master as Site;
        master.BindSearchedData(searchQuery, ConfigurationManager.AppSettings["searchMode_advanced"]);
        master.h2QuickSearchHead.InnerText = "Arama Kriterleri";
        HiddenField hfSearchMode = (HiddenField)Page.Master.FindControl("hfSearchMode");
        hfSearchMode.Value = ConfigurationManager.AppSettings["searchMode_advanced"];

        

        switch (_estateType.TypeKey)
        {
            case "konut":
                master._pnlKonutSearch.Visible = true;
                break;
            case "isyeri":
                master._pnlIsyeriSearch.Visible = true;
                break;
            case "arsa":
                master._pnlArsaSearch.Visible = true;
                break;
            case "devremulk":
                master._pnlDevremulkSearch.Visible = true;
                break;
            case "turistik-isletme":
                master._pnlTuristikSearch.Visible = true;                
                break;
            default:
                break;
        }

        
    }
}