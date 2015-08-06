using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_address_city_data : BasePage
{
    private City currentCity;
    public City CurrentCity
    {
        get
        {
            if (currentCity == default(City))
            {
                if (Request.QueryString["city"] != null)
                {
                    currentCity = DBProvider.GetCityByObjectId(Convert.ToInt32(Request.QueryString["city"]));
                }
                else
                {
                    currentCity = null;
                }
            }
            return currentCity;
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
        if (CurrentCity != null)
        {
            tbCityName.Text = CurrentCity.CityName;
            pnlTownList.Visible = true;

            rptTown.DataSource = DBProvider.GetTownListByCityObjectId(CurrentCity.ObjectId);
            rptTown.DataBind();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentCity != null)
        {
            CurrentCity.CityName = tbCityName.Text.Trim();            
        }
        else
        {
            DBProvider.AddCity(tbCityName.Text.Trim(), DBProvider.City.OrderByDescending(i=> i.SortOrder).FirstOrDefault().SortOrder + 1);
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }

    protected void rptTown_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int townId = Convert.ToInt32(e.CommandArgument);
            Town town = DBProvider.GetTownByObjectId(townId);

            if (town != null)
            town.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}