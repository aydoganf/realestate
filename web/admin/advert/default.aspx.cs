using REModel.Old;
using System;
using System.Web.UI.WebControls;

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
        rptAdvert.DataSource = _advertApi.GetAllAdvertAsync("").Result.Response; //DBProvider.GetAdvertList();
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
        var advertId = Guid.Parse(e.CommandArgument.ToString());
        Advert advert = _advertApi.GetAdvertAsync("", advertId).Result.Response; //DBProvider.GetAdvertByObjectId(advertId);

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
            //advert.Delete();
        }

        //DBProvider.SaveChanges();
        BindData();
        SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, ApplicationGenericControls.OperationStatus.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
    }
}