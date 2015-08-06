using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_address_town_data : BasePage
{
    private Town currentTown;
    public Town CurrentTown
    {
        get 
        {
            if (currentTown == default(Town))
            {
                if (Request.QueryString["town"] != null)
                {
                    currentTown = DBProvider.GetTownByObjectId(Convert.ToInt32(Request.QueryString["town"]));
                }
                else
                {
                    currentTown = null;
                }
            }
            return currentTown; 
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

        if (CurrentTown != null)
        {
            tbTownName.Text = CurrentTown.TownName;
            ddlCityList.SelectedValue = CurrentTown.CityObjectId.ToString();

            pnlDistrictList.Visible = true;

            rptDistrict.DataSource = DBProvider.GetTownListByCityObjectId(CurrentTown.ObjectId);
            rptDistrict.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentTown != null)
        {
            CurrentTown.TownName = tbTownName.Text.Trim();
            CurrentTown.CityObjectId = Convert.ToInt32(ddlCityList.SelectedValue);
        }
        else
        {
            DBProvider.AddTown(tbTownName.Text.Trim(), Convert.ToInt32(ddlCityList.SelectedValue));
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }

    protected void rptDistrict_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int districtId = Convert.ToInt32(e.CommandArgument);
            District obj = DBProvider.GetDistrictByObjectId(districtId);

            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}