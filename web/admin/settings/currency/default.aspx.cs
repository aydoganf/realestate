using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_currency_default : BasePage
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
        rptCurrency.DataSource = DBProvider.GetCurrencyList();
        rptCurrency.DataBind();
    }

    protected void rptCurrency_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int currencyId = Convert.ToInt32(e.CommandArgument);
            Currency obj = DBProvider.GetCurrencyByObjectId(currencyId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}