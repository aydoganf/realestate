using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Web.UI.HtmlControls;

public partial class AdvertDetail : BasePage
{
    private Advert currentAdvert;
    public Advert CurrentAdvert
    {
        get 
        {
            if (currentAdvert == default(Advert))
            {
                currentAdvert = DBProvider.GetAdvertByAdvertNumber(RouteData.Values["advertNumber"].ToString());
            }
            return currentAdvert; 
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
        rptPhotos.DataSource = CurrentAdvert.AdvertPhoto.Where(i => !i.Deleted);
        rptPhotos.DataBind();

        hfLong.Value = CurrentAdvert.Longitude;
        hfLat.Value = CurrentAdvert.Latitude;

        List<FeatureType> featureTypeList = DBProvider.GetFeatureTypeListByEstateTypeObjectId(Convert.ToInt32(CurrentAdvert.ParentEstateTypeObjectId));

        rptFeatureType.DataSource = featureTypeList;
        rptFeatureType.DataBind();

        rptFeatureTypeTabs.DataSource = featureTypeList;
        rptFeatureTypeTabs.DataBind();

        #region Paneller
        SetPanels();
        lblParentEstateTypeName.Text = CurrentAdvert.EstateType.ParentEstateType.TypeName;
        #endregion
    }


    protected void SetPanels()
    {
        pnlKonutBilgileri.Visible = false;
        pnlIsyeriBilgileri.Visible = false;
        pnlArsaBilgileri.Visible = false;
        pnlDevremulkBilgileri.Visible = false;
        pnlTuristikBilgileri.Visible = false;

        switch (CurrentAdvert.EstateType.ParentEstateType.TypeKey)
        {
            case "konut":
                pnlKonutBilgileri.Visible = true;                
                break;
            case "isyeri":
                pnlIsyeriBilgileri.Visible = true;
                break;
            case "arsa":
                pnlArsaBilgileri.Visible = true;
                break;
            case "devremulk":
                pnlDevremulkBilgileri.Visible = true;
                break;
            case "turistik-isletme":
                pnlTuristikBilgileri.Visible = true;
                break;
            default:
                break;
        }
    }

    protected void rptFeatureTypeTabs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            FeatureType featureType = e.Item.DataItem as FeatureType;
            Repeater rptFeatures = e.Item.FindControl("rptFeatures") as Repeater;

            rptFeatures.DataSource = DBProvider.GetFeatureListByFeatureTypeObjectId(featureType.ObjectId);
            rptFeatures.DataBind();

        }
    }
    protected void rptFeatures_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HtmlGenericControl liFeature = e.Item.FindControl("liFeature") as HtmlGenericControl;
            Feature feature = e.Item.DataItem as Feature;

            if (CurrentAdvert.AdvertFeatureRelation.Where(i=> !i.Deleted && i.FeatureObjectId == feature.ObjectId).Count() != 0)
            {
                liFeature.Attributes["data-checked"] = "1";
                liFeature.Attributes["class"] = "checked";
            }
            else
            {
                liFeature.Attributes["data-checked"] = "0";
                liFeature.Attributes["class"] = "plain";
            }
        }
    }
}