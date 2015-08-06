using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class settings_housing_roomhall_default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        rptRoomHall.DataSource = DBProvider.GetRoomHallList();
        rptRoomHall.DataBind();
    }
    protected void rptRoomHall_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int roomHallId = Convert.ToInt32(e.CommandArgument);
            RoomHall obj = DBProvider.GetRoomHallByObjectId(roomHallId);
            obj.Delete();
            DBProvider.SaveChanges();

            BindData();
        }
    }
}