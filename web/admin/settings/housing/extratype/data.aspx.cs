using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_housing_extratype_data : BasePage
{
    private FeatureType currentFeatureType;
    public FeatureType CurrentFeatureType
    {
        get
        {
            if (currentFeatureType == default(FeatureType))
            {
                if (Request.QueryString["extratype"] != null)
                {
                    currentFeatureType = DBProvider.GetFeatureTypeByObjectId(Convert.ToInt32(Request.QueryString["extratype"]));
                }
                else
                {
                    currentFeatureType = null;
                }
            }
            return currentFeatureType;
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
        ddlEstateType.DataSource = DBProvider.GetBaseEstateTypeList();
        ddlEstateType.DataBind();
        ddlEstateType.Items.Insert(0, new ListItem("Seçiniz", ""));


        if (CurrentFeatureType != null)
        {
            tbFeatureTypeName.Text = CurrentFeatureType.TypeName;
            ddlEstateType.SelectedValue = CurrentFeatureType.EstateTypeObjectId.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int? estateTypeId = null;
        if (ddlEstateType.SelectedValue != "")
            estateTypeId = Convert.ToInt32(ddlEstateType.SelectedValue);

        if (CurrentFeatureType != null)
        {
            CurrentFeatureType.TypeName= tbFeatureTypeName.Text.Trim();
            CurrentFeatureType.EstateTypeObjectId = estateTypeId;
            CurrentFeatureType.IsProjectType = cbIsProjectType.Checked;
        }
        else
        {
            DBProvider.AddFeatureType(tbFeatureTypeName.Text.Trim(), estateTypeId, cbIsProjectType.Checked);
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}