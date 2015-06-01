using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class AdvencedSearch : BasePage
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
        ddlMarketingType.DataSource = DBProvider.GetMarketingTypeList();
        ddlMarketingType.DataBind();

        ddlEstateType.DataSource = DBProvider.GetBaseEstateTypeList();
        ddlEstateType.DataBind();
        ddlEstateType.SelectedValue = "4";  // Konut
        lblEstateTypeText.Text = "Konut";

        lbSubEstateType.DataSource = DBProvider.GetEstateTypeListByParentId(4);
        lbSubEstateType.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
    }
}