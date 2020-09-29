using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using REModel.Old.Api;

[AuthenticationRequired()]
public partial class settings_currency_data : BasePage
{
    private REModel.Old.Api.KeyValueStore currentCurrency;

    public REModel.Old.Api.KeyValueStore CurrentCurrency
    {
        get
        {
            if (currentCurrency == null)
            {
                if (Request.QueryString["currency"] != null)
                {
                    currentCurrency = _keyValueStoreApi.GetById(
                        authorization: "",
                        id: Guid.Parse(Request.QueryString["currency"])).Result.Response;
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
            tbCurrencyName.Text = CurrentCurrency.Key;
            tbCurrencyValue.Text = CurrentCurrency.Value;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentCurrency != null)
        {
            CurrentCurrency.Key = tbCurrencyName.Text.Trim();
            CurrentCurrency.Value  = tbCurrencyValue.Text.Trim();

            var updated = _keyValueStoreApi.Update(
                authorization: "",
                id: CurrentCurrency.Id,
                obj: CurrentCurrency).Result.Response;
        }
        else
        {
            var added = _keyValueStoreApi.Add(
                authorization: "",
                obj: new REModel.Old.Api.KeyValueStore()
                {
                    Key = tbCurrencyName.Text.Trim(),
                    Value = tbCurrencyValue.Text.Trim(),
                    Type = "currency"
                }).Result.Response;
        }

        Response.Redirect("default.aspx?status=0");
    }
}