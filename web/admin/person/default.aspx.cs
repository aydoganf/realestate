using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class person_Default : BasePage
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
        rptPerson.DataSource = DBProvider.GetPersonList();
        rptPerson.DataBind();
    }

    protected void rptPerson_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Person p = e.Item.DataItem as Person;
            LinkButton lbtnDeactivate = e.Item.FindControl("lbtnDeactivate") as LinkButton;
            LinkButton lbtnActivate = e.Item.FindControl("lbtnActivate") as LinkButton;
            LinkButton lbtnAdmin = e.Item.FindControl("lbtnAdmin") as LinkButton;

            if (p.IsActive)
                lbtnDeactivate.Visible = true;            
            else
                lbtnActivate.Visible = true;
            if (p.AccountTypeObjectId == 1)
                lbtnAdmin.Visible = true;
        }
    }
    protected void rptPerson_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int personId = Convert.ToInt32(e.CommandArgument);
        Person person = DBProvider.GetPersonByObjectId(personId);

        switch (e.CommandName)
        {
            case "deactivate":
                person.IsActive = false;
                break;
            case "activate":
                person.IsActive = true;
                break;
            case "delete":
                person.Delete();
                break;
            case "admin":
                person.AccountTypeObjectId = 2;
                break;
            default:
                break;
        }
        DBProvider.SaveChanges();
        BindData();
        SetOperationStatus(pnlOperationStatus, h4StatusTitle, pStatusInfo, ApplicationGenericControls.OperationStatus.StatusOKTitle, ApplicationGenericControls.OperationStatus.StatusOKDescription, ApplicationGenericControls.OperationStatus.StatusOKCSS);
    }
}