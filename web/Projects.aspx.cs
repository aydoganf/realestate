using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;

public partial class Projects : BasePage
{
    private string FieldSearchQuery;
    public string SearchQuery
    {
        get
        {
            if (string.IsNullOrEmpty(FieldSearchQuery) && Request.QueryString["q"] != null)
            {
                FieldSearchQuery = Request.QueryString["q"];
            }
            return FieldSearchQuery;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        if (string.IsNullOrEmpty(SearchQuery))
        {
            rptRecentProjects.DataSource = DBProvider.GetRecentlyProjects();
            rptRecentProjects.DataBind();
            lblPageTitle.Text = "Projeler";
            lblNavigation.Text = "Projeler";

            if (rptRecentProjects.Items.Count == 0)
            {
                pnlEmpty.Controls.Add(new Literal() { Text = "Şuanda kayıtlı bir projemiz bulunmamaktadır." });
                pnlEmpty.Visible = true;
            }
        }
        else
        {
            string query = Decypt(SearchQuery);
            Dictionary<string, string> searchParams = new Dictionary<string, string>();
            foreach (string item in query.Split('&'))
            {
                string[] s = item.Split('=');
                searchParams.Add(s[0], s[1]);
            }

            string cityParam = searchParams["city"];
            string townParam = searchParams["town"];
            bool _townParam = false;

            int _city = Convert.ToInt32(cityParam);
            if (townParam != "-1")
            {
                _townParam = true;
            }

            int[] townArr;            
            if (_townParam)
            {
                List<string> townList = new List<string>();
                townList = townParam.Split(',').ToList();
                townArr = new int[townList.Count];
                for (int i = 0; i < townList.Count; i++)
                {
                    townArr[i] = Convert.ToInt32(townList[i]);
                }
            }
            else
                townArr = new int[1] { 0 };
            

            List<Project> result = DBProvider.AdvancedProjectSearch(_city, _townParam, townArr);
            if (result.Count != 0)
            {
                rptSearchedProjects.DataSource = result;
                rptSearchedProjects.DataBind();
                rptSearchedProjects.Visible = true;
            }
            else
            {
                pnlEmpty.Controls.Add(new Literal() { Text = "Aradığınız kriterlere uygun bir projemiz bulunmamaktadır." });
                pnlEmpty.Visible = true;
                rptSearchedProjects.Visible = false;
            }

            lblPageTitle.Text = "Projeler Arama Sonuçları";
            lblNavigation.Text = "<a href='/projeler'>Projeler</a> &gt; Arama Sonuçları";

            ProjectMaster master = Page.Master as ProjectMaster;
            master.BindSearchedData(_city, _townParam, townArr);
        }
    }
}