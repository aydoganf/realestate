using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBLayer;
using System.Configuration;

/// <summary>
/// Summary description for MasterBasePage
/// </summary>
public class MasterBasePage : System.Web.UI.MasterPage
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

    private string FieldSiteLink;

    public string SiteLink
    {
        get 
        {
            if (FieldSiteLink == null)
            {
                FieldSiteLink = ConfigurationManager.AppSettings["SiteLink"];
            }
            return FieldSiteLink; 
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
    

    private Person FieldCurrentPerson;
    public Person CurrentPerson
    {
        get 
        {
            if (FieldCurrentPerson == default(Person))
            {
                FieldCurrentPerson = DBProvider.GetPersonByEmailAddress(Page.User.Identity.Name);
            }
            return FieldCurrentPerson; 
        }
    }

    public MasterBasePage()
    {
        object userId = HttpContext.Current.Session["CurrentUser"];
        if (userId == null)
        {
            //Response.Redirect("~/Login.aspx");
        }
    }
}