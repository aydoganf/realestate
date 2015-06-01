using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class admin_settings_housing_status_default : BasePage
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
        rptStatus.DataSource = DBProvider.GetAdvertStatusList();
        rptStatus.DataBind();
    }
    protected void rptStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int statusId = Convert.ToInt32(e.CommandArgument);
            AdvertStatus obj = DBProvider.GetAdvertStatusByObjectId(statusId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}