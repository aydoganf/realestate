using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Configuration;
using System.Web.UI.HtmlControls;

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

    private int advertPageNumber;
    public int AdvertPageNumber
    {
        get
        {
            if (advertPageNumber == default(int))
            {
                int o;
                if (RouteData.Values["page"] != null && int.TryParse(RouteData.Values["page"].ToString(), out o))
                {
                    advertPageNumber = o;
                }
                else
                {
                    advertPageNumber = 1;
                }
            }
            return advertPageNumber;
        }
    }

    private string pageSearchQuery;

    public string PageSearchQuery
    {
        get 
        {
            if (string.IsNullOrEmpty(pageSearchQuery))
            {
                if (!string.IsNullOrEmpty(Request.QueryString["q"]))
                {
                    pageSearchQuery = Request.QueryString["q"];
                }
                else
                    Response.Redirect("~/hata?sq=empty");
            }
            return pageSearchQuery; 
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
        SearchAdvanced(AdvertPageNumber);
    }


    protected void SearchAdvanced(int page)
    {
        SearchQuery searchQuery = GetSearchQueryFromHash(PageSearchQuery);

        int resultCount;
        List<Advert> searchResult = DBProvider.AdvancedSearchAdvert(searchQuery, page, AdvertPageItemCount, out resultCount);
        rptAdverts.DataSource = searchResult;
        rptAdverts.DataBind();

        if (resultCount != 0)
        {
            if (resultCount > AdvertPageItemCount)
            {
                int totalPages = (int)Math.Ceiling((double)resultCount / AdvertPageItemCount);
                hfLastPageNumber.Value = totalPages.ToString();
                int[] pagination = new int[totalPages];
                for (int i = 0; i < totalPages; i++)
                {
                    pagination[i] = i + 1;
                }

                rptPagination.DataSource = pagination;
                rptPagination.DataBind();
                hfCurrentAdvertPageNumber.Value = AdvertPageNumber.ToString();
                hfSearchQuery.Value = PageSearchQuery;
            }
            else
                divPagination.Visible = false;
        }
        else
        {
            pnlEmpty.Visible = true;
            divPagination.Visible = false;
        }

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
    protected void rptPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int pageItem = Convert.ToInt32(e.Item.DataItem);
            HtmlGenericControl liPaginationItem = e.Item.FindControl("liPaginationItem") as HtmlGenericControl;

            if (pageItem == AdvertPageNumber)
            {
                liPaginationItem.Attributes["class"] = "active";
            }
        }
    }
}