using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_housing_heating_data : BasePage
{
    private HeatingType currentHeatingType;
    public HeatingType CurrentHeatingType
    {
        get
        {
            if (currentHeatingType == default(HeatingType))
            {
                if (Request.QueryString["heating"] != null)
                {
                    currentHeatingType = DBProvider.GetHeatingTypeByObjectId(Convert.ToInt32(Request.QueryString["heating"]));
                }
                else
                {
                    currentHeatingType = null;
                }
            }
            return currentHeatingType;
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
        if (CurrentHeatingType != null)
        {
            tbTypeName.Text = CurrentHeatingType.TypeName;
            tbTypeKey.Text = CurrentHeatingType.TypeKey;            
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentHeatingType != null)
        {
            CurrentHeatingType.TypeName = tbTypeName.Text.Trim();
            CurrentHeatingType.TypeKey = tbTypeKey.Text.Trim();
        }
        else
        {
            DBProvider.AddHeatingType(tbTypeName.Text.Trim(), tbTypeKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}