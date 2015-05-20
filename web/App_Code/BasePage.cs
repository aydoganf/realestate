using DBLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    private string FieldSiteName;
    public string SiteName
    {
        get
        {
            if (FieldSiteName == null)
            {
                FieldSiteName = ConfigurationManager.AppSettings["SiteName"];
            }
            return FieldSiteName;
        }
    }

    private RealEstateEntities FieldDBProvider;
    public RealEstateEntities DBProvider
    {
        get
        {
            if (FieldDBProvider == default(RealEstateEntities))
            {
                FieldDBProvider = new RealEstateEntities();
            }
            return FieldDBProvider;
        }
    }

    protected static string MD5Crypto(string metin)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] btr = Encoding.UTF8.GetBytes(metin);
        btr = md5.ComputeHash(btr);

        StringBuilder sb = new StringBuilder();
        foreach (byte ba in btr)
        {
            sb.Append(ba.ToString("x2").ToLower());
        }

        return sb.ToString();
    }


    private Person currentPerson;

    public Person CurrentPerson
    {
        get
        {
            if (currentPerson == default(Person))
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    currentPerson = DBProvider.GetPersonByEmailAddress(Page.User.Identity.Name);
                }
                else
                {
                    currentPerson = null;
                }
            }
            return currentPerson;
        }
    }


    public void SetOperationStatus(Panel panel, HtmlGenericControl h4, HtmlGenericControl p, string title, string info, string cssClass)
    {
        panel.CssClass = cssClass;
        h4.InnerText = title;
        p.InnerHtml = info;
        panel.Visible = true;
    }

    public void RegisterStartupScript(string scriptKey, string script)
    {
        ClientScript.RegisterStartupScript(GetType(), scriptKey, script, true);
    }

    public BasePage()
    {
    }
}