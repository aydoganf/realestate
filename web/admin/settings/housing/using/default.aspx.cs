using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_using_default : BasePage
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
        rptUsing.DataSource = DBProvider.GetAdvertUsingTypeList();
        rptUsing.DataBind();
    }
    protected void rptUsing_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int usingId = Convert.ToInt32(e.CommandArgument);
            AdvertUsingType obj = DBProvider.GetAdvertUsingTypeByObjectId(usingId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}