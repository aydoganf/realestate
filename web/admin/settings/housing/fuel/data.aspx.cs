using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class admin_settings_housing_fuel_data : BasePage
{
    private FuelType currentFuelType;
    public FuelType CurrentFuelType
    {
        get
        {
            if (currentFuelType == default(FuelType))
            {
                if (Request.QueryString["fuel"] != null)
                {
                    currentFuelType = DBProvider.GetFuelTypeByObjectId(Convert.ToInt32(Request.QueryString["fuel"]));
                }
                else
                {
                    currentFuelType = null;
                }
            }
            return currentFuelType;
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
        if (CurrentFuelType != null)
        {
            tbTypeName.Text = CurrentFuelType.TypeName;
            tbTypeKey.Text = CurrentFuelType.TypeKey;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentFuelType != null)
        {
            CurrentFuelType.TypeName = tbTypeName.Text.Trim();
            CurrentFuelType.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddFuelType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}