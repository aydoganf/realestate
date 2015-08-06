using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_estatetype_default : BasePage
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
        rptEstateType.DataSource = DBProvider.GetEstateTypeList();
        rptEstateType.DataBind();
    }
    protected void rptEstateType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int estateTypeId = Convert.ToInt32(e.CommandArgument);
            EstateType obj = DBProvider.GetEstateTypeByObjectId(estateTypeId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}