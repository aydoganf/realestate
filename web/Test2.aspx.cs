using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class Test2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int[] arr = new int[2] { 17, 2 };
        int[] arr2 = new int[2] { 17, 2 };
        bool x = false;

        List<Advert> list = DBProvider.Advert.Where(i => arr.Contains(i.FloorObjectId.Value) && 
            (x ? arr2.Contains(i.EstateTypeObjectId) : true)).ToList();

        gv.DataSource = list;
        gv.DataBind();
    }
}