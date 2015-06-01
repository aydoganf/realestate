using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class admin_settings_housing_deed_default : BasePage
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
        rptDeed.DataSource = DBProvider.GetDeedTypeList();
        rptDeed.DataBind();
    }

    protected void rptDeed_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int deedId = Convert.ToInt32(e.CommandArgument);
            DeedType obj = DBProvider.GetDeedTypeByObjectId(deedId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}