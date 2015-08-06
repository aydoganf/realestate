using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_owner_default : BasePage
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
        rptAdvertOwner.DataSource = DBProvider.GetAdvertOwnerTypeList();
        rptAdvertOwner.DataBind();
    }

    protected void rptAdvertOwner_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int ownerId = Convert.ToInt32(e.CommandArgument);
            AdvertOwnerType obj = DBProvider.GetAdvertOwnerTypeByObjectId(ownerId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}