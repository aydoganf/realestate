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
        string password = MD5Crypto(tbPassword.Text.Trim());
        string email = tbEmail.Text.Trim();

        Person person = DBProvider.GetPersonByEmailAndPassword(email, password, 2);
        if (person != null)
        {
            HttpContext currentContext = HttpContext.Current;
            string formsCookieStr = string.Empty;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                person.Email,
                                                DateTime.Now,
                                                DateTime.Now.AddMinutes(120), // value of time out property
                                                false, // Value of IsPersistent property
                                                "admin",
                                                FormsAuthentication.FormsCookiePath);

            formsCookieStr = FormsAuthentication.Encrypt(ticket);
            HttpCookie FormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, formsCookieStr);
            currentContext.Response.Cookies.Add(FormsCookie);
            Session["CurrentUser"] = person.ObjectId;

            if (Request.QueryString["ReturnUrl"] != null)
            {
                Response.Redirect(Request.QueryString["ReturnUrl"]);
            }
            else
                Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}