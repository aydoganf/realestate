using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_currency_data : BasePage
{
    private Currency currentCurrency;

    public Currency CurrentCurrency
    {
        get
        {
            if (currentCurrency == default(Currency))
            {
                if (Request.QueryString["currency"] != null)
                {
                    currentCurrency = DBProvider.GetCurrencyByObjectId(Convert.ToInt32(Request.QueryString["currency"]));
                }
                else
                {
                    currentCurrency = null;
                }
            }
            return currentCurrency;
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
        if (CurrentCurrency != null)
        {
            tbCurrencyName.Text = CurrentCurrency.CurrencyName;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentCurrency != null)
        {
            CurrentCurrency.CurrencyName = tbCurrencyName.Text.Trim();
        }
        else
        {
            DBProvider.AddCurrency(tbCurrencyName.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}