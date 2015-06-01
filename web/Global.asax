<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");
        RouteTable.Routes.Ignore("ilan-detay/{districtName}/{townName}/{cityName}/{advertNumber}/{title}/{resource}.axd/{*pathInfo}");
        RouteTable.Routes.Ignore("arama-sonuclari/{cityId}/{townId}/{districtId}/{estateTypeId}/{marketingTypeId}/{area}/{price}/{priceCurrencyId}/{resource}.axd/{*pathInfo}");
        RouteTable.Routes.RouteExistingFiles = false;

        RouteTable.Routes.Add("anasayfa", new Route("anasayfa", new PageRouteHandler("~/Default.aspx")));
        RouteTable.Routes.Add("ilan-detay", new Route("ilan-detay/{districtName}/{townName}/{cityName}/{advertNumber}/{title}", new PageRouteHandler("~/AdvertDetail.aspx")));
        RouteTable.Routes.Add("giris", new Route("giris", new PageRouteHandler("~/LoginUser.aspx")));
        RouteTable.Routes.Add("uyelik", new Route("uyelik", new PageRouteHandler("~/Register.aspx")));
        RouteTable.Routes.Add("iletisim", new Route("iletisim", new PageRouteHandler("~/Contact.aspx")));
        RouteTable.Routes.Add("detayli-arama", new Route("detayli-arama", new PageRouteHandler("~/AdvencedSearch.aspx")));
        RouteTable.Routes.Add("arama-sonuclari", 
            new Route("arama-sonuclari/{cityId}/{townId}/{districtId}/{estateTypeId}/{marketingTypeId}/{area}/{price}/{priceCurrencyId}", 
                new PageRouteHandler("~/SearchResult.aspx")));
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    protected void Application_AuthenticateRequest(Object src, EventArgs e)
    {
        HttpContext currentContext = HttpContext.Current;
        if (HttpContext.Current.User != null)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
                    FormsAuthenticationTicket ticket = id.Ticket;
                    string[] userRole = new string[1];
                    userRole[0] = ticket.UserData;
                    var astrRoles = ticket.UserData.Split('|');
                    var principal = new System.Security.Principal.GenericPrincipal(id, astrRoles);
                    HttpContext.Current.User = principal;
                    System.Threading.Thread.CurrentPrincipal = principal;
                }
            }
        }
    }
</script>
