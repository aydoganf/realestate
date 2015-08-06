using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_credit_data : BasePage
{
    private CreditType currentCreditType;
    public CreditType CurrentCreditType
    {
        get
        {
            if (currentCreditType == default(CreditType))
            {
                if (Request.QueryString["credit"] != null)
                {
                    currentCreditType = DBProvider.GetCreditTypeByObjectId(Convert.ToInt32(Request.QueryString["credit"]));
                }
                else
                {
                    currentCreditType = null;
                }
            }
            return currentCreditType;
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
        if (CurrentCreditType != null)
        {
            tbTypeName.Text = CurrentCreditType.TypeName;
            tbTypeKey.Text = CurrentCreditType.TypeKey;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentCreditType != null)
        {
            CurrentCreditType.TypeName = tbTypeName.Text.Trim();
            CurrentCreditType.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddCreditType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}