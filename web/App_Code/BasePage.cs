using DBLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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

    private string CyrptoKey = "Faruk";
    private TripleDESCryptoServiceProvider _cryptDES3;
    public TripleDESCryptoServiceProvider cryptDES3
    {
        get 
        {
            if (_cryptDES3 == default(TripleDESCryptoServiceProvider))
            {
                _cryptDES3 = new TripleDESCryptoServiceProvider();
            }
            return _cryptDES3; 
        }
    }

    private MD5CryptoServiceProvider _cryptMD5Hash;
    public MD5CryptoServiceProvider cryptMD5Hash
    {
        get 
        {
            if (_cryptMD5Hash == default(MD5CryptoServiceProvider))
            {
                _cryptMD5Hash = new MD5CryptoServiceProvider();
            }
            return _cryptMD5Hash; 
        }
    }

    public string Encrypt(string text)
    {
        cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(CyrptoKey));
        cryptDES3.Mode = CipherMode.ECB;
        ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
        byte[] buff = ASCIIEncoding.ASCII.GetBytes(text);
        string Encrypt = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        Encrypt = Encrypt.Replace("+", "!");
        Encrypt = Encrypt.Replace("/", "__");
        return Encrypt;
    }

    public string Decypt(string text)
    {
        text = text.Replace("!", "+");
        text = text.Replace("__", "/");
        byte[] buf = new byte[text.Length];
        cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(CyrptoKey));
        cryptDES3.Mode = CipherMode.ECB;
        ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
        buf = Convert.FromBase64String(text);
        string Decrypt = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buf, 0, buf.Length));
        return Decrypt;
    }

    public string FormatPrice(object input)
    {
        return Regex.Replace(String.Format("{0:#,#}", input), "\\.00$", "");
    }
}