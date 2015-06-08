using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int[] arr = new int[2] { 17, 2 };
        List<Advert> list = DBProvider.Advert.Where(i => arr.Contains(i.FloorObjectId.Value)).ToList();

        gv.DataSource = list;
        gv.DataBind();
    }
}