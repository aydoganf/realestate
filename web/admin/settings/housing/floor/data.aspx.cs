using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_housing_floor_data : BasePage
{
    private Floor currentFloor;

    public Floor CurrentFloor
    {
        get 
        {
            if (currentFloor == default(Floor))
            {
                if (Request.QueryString["floor"] != null)
                {
                    currentFloor = DBProvider.GetFloorByObjectId(Convert.ToInt32(Request.QueryString["floor"]));
                }
                else
                {
                    currentFloor = null;
                }
            }
            return currentFloor; 
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
        if (CurrentFloor != null)
        {
            tbFloorName.Text = CurrentFloor.FloorName;
            tbFloorKey.Text = CurrentFloor.FloorKey;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentFloor != null)
        {
            CurrentFloor.FloorName = tbFloorName.Text.Trim();
            CurrentFloor.FloorKey = tbFloorKey.Text.Trim();            
        }
        else
        {
            DBProvider.AddFloor(tbFloorName.Text.Trim(), tbFloorKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}