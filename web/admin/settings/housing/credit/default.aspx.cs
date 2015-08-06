using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_credit_default : BasePage
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
        rptCredit.DataSource = DBProvider.GetCreditTypeList();
        rptCredit.DataBind();
    }

    protected void rptCredit_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int creditId = Convert.ToInt32(e.CommandArgument);
            CreditType obj = DBProvider.GetCreditTypeByObjectId(creditId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}