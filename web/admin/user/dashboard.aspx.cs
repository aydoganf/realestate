using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using REModel.Old;

[AuthenticationRequired()]
public partial class user_dashboard : BasePage
{
    private User currentUser;
    public User CurrentUser
    {
        get 
        {
            if (currentUser == default(User))
            {
                currentUser = _userApi.GetUserAsync("", Guid.Parse(Request.QueryString["person"])).Result.Response;
            }
            return currentUser; 
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
        if (CurrentUser.IsActive)
        {
            btnActivate.Visible = false;
        }

        if (CurrentUser.AccountType == "admin")
        {
            btnDelete.Visible = false;
        }
    }

    protected void btnActivate_Click(object sender, EventArgs e)
    {
        CurrentUser.IsActive = true;
        //DBProvider.SaveChanges();
        BindData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //CurrentUser.Delete();
        //DBProvider.SaveChanges();
        Response.Redirect("default.aspx");
    }
}