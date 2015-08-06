using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_housing_roomhall_data : BasePage
{
    private RoomHall currentRoomHall;
    public RoomHall CurrentRoomHall
    {
        get
        {
            if (currentRoomHall == default(RoomHall))
            {
                if (Request.QueryString["roomhall"] != null)
                {
                    currentRoomHall = DBProvider.GetRoomHallByObjectId(Convert.ToInt32(Request.QueryString["roomhall"]));
                }
                else
                {
                    currentRoomHall = null;
                }
            }
            return currentRoomHall;
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
        if (CurrentRoomHall != null)
        {
            tbRoomHallName.Text = CurrentRoomHall.RoomHallName;
            tbRoomHallKey.Text = CurrentRoomHall.RoomHallKey;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CurrentRoomHall != null)
        {
            CurrentRoomHall.RoomHallName = tbRoomHallName.Text.Trim();
            CurrentRoomHall.RoomHallKey = tbRoomHallKey.Text.Trim();
        }
        else
        {
            DBProvider.AddRoomHall(tbRoomHallName.Text.Trim(), tbRoomHallKey.Text.Trim());
        }
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx?status=0");
    }
}