using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class advert_default : BasePage
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
        rptAdvert.DataSource = DBProvider.GetAdvertList();
        rptAdvert.DataBind();
    }
    protected void rptAdvert_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Advert advert = e.Item.DataItem as Advert;
            LinkButton lbtnDeactivate = e.Item.FindControl("lbtnDeactivate") as LinkButton;
            LinkButton lbtnActivate = e.Item.FindControl("lbtnActivate") as LinkButton;

            if (advert.IsActive)
            {
                lbtnDeactivate.Visible = true;
            }
            else
            {
                lbtnActivate.Visible = true;
            }
        }
    }

    public static string TruncateString(string str, int maxLength)
    {
        return str.Substring(0, Math.Min(str.Length, maxLength));
    }
    protected void rptAdvert_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int advertId = Convert.ToInt32(e.CommandArgument);
        Advert advert = DBProvider.GetAdvertByObjectId(advertId);

        if (e.CommandName == "deactivate")
        {
            advert.IsActive = false;
        }
        else if (e.CommandName == "activate")
        {
            advert.IsActive = true;
        }
        else if (e.CommandName == "delete")
        {
            advert.Delete();
        }

        DBProvider.SaveChanges();
        BindData();
        SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, ApplicationGenericControls.OperationStatus.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
    }
}