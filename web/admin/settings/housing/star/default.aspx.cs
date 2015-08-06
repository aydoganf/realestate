using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_star_default : BasePage
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
        rptStar.DataSource = DBProvider.GetStarCountList();
        rptStar.DataBind();
    }

    protected void rptStar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int starId = Convert.ToInt32(e.CommandArgument);
            StarCount obj = DBProvider.GetStarCountByObjectId(starId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}