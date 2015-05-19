using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class settings_address_district_data : BasePage
{

    private District currentDistrict;
    public District CurrentDistrict
    {
        get
        {
            if (currentDistrict == default(District))
            {
                if (Request.QueryString["district"] != null)
                {
                    currentDistrict = DBProvider.GetDistrictByObjectId(Convert.ToInt32(Request.QueryString["district"]));
                }
                else
                {
                    currentDistrict = null;
                }
            }
            return currentDistrict;
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
        ddlCityList.DataSource = DBProvider.GetCityList();
        ddlCityList.DataBind();
        ddlCityList.Items.Insert(0, new ListItem("Seçiniz", ""));


        if (CurrentDistrict != null)
        {
            ddlCityList.SelectedValue = CurrentDistrict.Town.CityObjectId.ToString();
            
            ddlTownList.DataSource = DBProvider.GetTownListByCityObjectId(CurrentDistrict.Town.CityObjectId);
            ddlTownList.DataBind();
           
            ddlTownList.SelectedValue = CurrentDistrict.TownObjectId.ToString();

            tbDistrictName.Text = CurrentDistrict.DistrictName;
        }
        else
        {
            ddlTownList.Items.Insert(0, new ListItem("Önce İl Seçiniz", ""));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentDistrict != null)
        {
            CurrentDistrict.DistrictName = tbDistrictName.Text.Trim();
            CurrentDistrict.TownObjectId = Convert.ToInt32(ddlTownList.SelectedValue);
        }
        else
        {
            DBProvider.AddDistrict(tbDistrictName.Text.Trim(), Convert.ToInt32(ddlTownList.SelectedValue));
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
    protected void ddlCityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTownList.Items.Clear();
        if (ddlCityList.SelectedValue != "")
        {
            ddlTownList.DataSource = DBProvider.GetTownListByCityObjectId(Convert.ToInt32(ddlCityList.SelectedValue));
            ddlTownList.DataBind();
        }
        else
        {
            ddlTownList.Items.Insert(0, new ListItem("Önce İl Seçiniz", ""));
        }
    }
}