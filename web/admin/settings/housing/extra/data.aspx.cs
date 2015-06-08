using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_housing_extra_data : BasePage
{
    private Feature currentFeature;

    public Feature CurrentFeature
    {
        get
        {
            if (currentFeature == default(Feature))
            {
                if (Request.QueryString["feature"] != null)
                {
                    currentFeature = DBProvider.GetFeatureByObjectId(Convert.ToInt32(Request.QueryString["feature"]));
                }
                else
                {
                    currentFeature = null;
                }
            }
            return currentFeature;
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
        List<FeatureType> featureTypeList = DBProvider.GetFeatureTypeList();

        foreach (FeatureType item in featureTypeList)
        {
            ListItem li = new ListItem(item.EstateType.TypeName + " - " + item.TypeName, item.ObjectId.ToString());
            ddlFeatureType.Items.Add(li);
        }

        if (CurrentFeature != null)
        {
            ddlFeatureType.SelectedValue = CurrentFeature.FeatureTypeObjectId.ToString();
            tbFeatureName.Text = CurrentFeature.FeatureName;
            tbFeatureKey.Text = CurrentFeature.FeatureKey;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentFeature != null)
        {
            CurrentFeature.FeatureTypeObjectId = Convert.ToInt32(ddlFeatureType.SelectedValue);
            CurrentFeature.FeatureName = tbFeatureName.Text.Trim();
            CurrentFeature.FeatureKey = tbFeatureKey.Text.Trim().ToLower();
        }
        else
        {
            DBProvider.AddFeature(tbFeatureName.Text.Trim(), tbFeatureKey.Text.Trim().ToLower(), Convert.ToInt32(ddlFeatureType.SelectedValue));
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}