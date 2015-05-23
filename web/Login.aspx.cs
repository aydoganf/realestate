using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Web.Security;

public partial class Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e) 
    {

        string password = BasePage.MD5Crypto(tbPassword.Text);
        string email = tbEmail.Text;

        Person person = DBProvider.GetPersonByEmailAndPassword(email, password);
        if (person != null)
        {
            HttpContext currentContext = HttpContext.Current;
            string formsCookieStr = string.Empty;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                person.Email,
                                                DateTime.Now,
                                                DateTime.Now.AddMinutes(120), // value of time out property
                                                false, // Value of IsPersistent property
                                                person.AccountType.AccountTypeName,
                                                FormsAuthentication.FormsCookiePath);

            formsCookieStr = FormsAuthentication.Encrypt(ticket);
            HttpCookie FormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, formsCookieStr);
            currentContext.Response.Cookies.Add(FormsCookie);
            Session["CurrentUserId"] = person.ObjectId;

            if (person.AccountTypeObjectId == 2)
            {
                Response.Redirect("~/admin/default.aspx");
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}