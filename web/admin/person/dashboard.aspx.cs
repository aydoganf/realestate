using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

[AuthenticationRequired()]
public partial class person_dashboard : BasePage
{
    private Person currentPerson;
    public Person CurrentPerson
    {
        get 
        {
            if (currentPerson == default(Person))
            {
                currentPerson = DBProvider.GetPersonByObjectId(Convert.ToInt32(Request.QueryString["person"]));
            }
            return currentPerson; 
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    public void BindData()
    {
        if (CurrentPerson.IsActive)
        {
            btnActivate.Visible = false;
        }

        if (CurrentPerson.AccountType.AccountTypeName == "admin")
        {
            btnDelete.Visible = false;
        }
    }

    protected void btnActivate_Click(object sender, EventArgs e)
    {
        CurrentPerson.IsActive = true;
        DBProvider.SaveChanges();
        BindData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CurrentPerson.Delete();
        DBProvider.SaveChanges();
        Response.Redirect("default.aspx");
    }
}