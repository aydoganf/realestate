using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Web.UI.HtmlControls;

public partial class ProjectDetail : BasePage
{
    #region Props

    private Project FieldCurrentProject;
    public Project CurrentProject
    {
        get
        {
            int o;
            if (FieldCurrentProject == default(Project) && int.TryParse(RouteData.Values["projectId"].ToString(), out o))
            {
                FieldCurrentProject = DBProvider.GetProjectByObjectId(o);
            }
            return FieldCurrentProject;
        }
    }

    private Advert FieldCurrentAdvert;
    public Advert CurrentAdvert
    {
        get
        {
            int o;
            if (RouteData.Values["advertId"] != null)
            {
                if (FieldCurrentAdvert == default(Advert) && int.TryParse(RouteData.Values["advertId"].ToString(), out o))
                {
                    FieldCurrentAdvert = DBProvider.GetAdvertByObjectId(o);
                }
            }
            return FieldCurrentAdvert;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();            
        }
    }

    protected void BindData()
    {
        rptProjectAdverts.DataSource = CurrentProject.ProjectAdvertRelation.Where(i => !i.Deleted);
        rptProjectAdverts.DataBind();

        rptPhotos.DataSource = CurrentProject.AdvertPhoto.Where(i => !i.Deleted);
        rptPhotos.DataBind();

        if (CurrentAdvert != null)
        {
            List<FeatureType> featureTypeList = DBProvider.GetFeatureTypeListByEstateTypeObjectId(Convert.ToInt32(CurrentAdvert.ParentEstateTypeObjectId));

            rptFeatureType.DataSource = featureTypeList;
            rptFeatureType.DataBind();

            rptFeatureTypeTabs.DataSource = featureTypeList;
            rptFeatureTypeTabs.DataBind();
        }
        else
        {
            hfLat.Value = CurrentProject.Latitude;
            hfLong.Value = CurrentProject.Longitude;
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

            if (CurrentAdvert.AdvertFeatureRelation.Where(i => !i.Deleted && i.FeatureObjectId == feature.ObjectId).Count() != 0)
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

    protected void rptProjectAdverts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HtmlGenericControl liProjectAdvertHousingTypeName = (HtmlGenericControl)e.Item.FindControl("liProjectAdvertHousingTypeName");
            ProjectAdvertRelation relation = e.Item.DataItem as ProjectAdvertRelation;

            if (CurrentAdvert != null && CurrentAdvert.ObjectId == relation.AdvertObjectId)
            {
                liProjectAdvertHousingTypeName.Attributes["class"] = "active";
            }
        }
    }
}