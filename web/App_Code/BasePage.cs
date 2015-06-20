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

    public string FormatAdvertLink(Advert obj)
    {
        return "/emlak-detay/" + obj.CityName + "/" + obj.TownName + "/" + obj.DistrictName + "/" + obj.AdvertNumber + "/" + FormatAdvertTitle(obj.Title);
    }

    public string FormatAdvertTitle(string title)
    {
        title = title.Replace('+', '_');
        title = title.Replace(' ', '-');
        title = title.Replace('.', '-');
        title = title.Replace("'", "-");
        return title;
    }

    private EstateType FieldKonutEmalgi;
    public EstateType KonutEmalgi
    {
        get 
        {
            if (FieldKonutEmalgi == default(EstateType))
            {
                FieldKonutEmalgi = DBProvider.GetEstateTypeByKey("konut");
            }
            return FieldKonutEmalgi; 
        }
    }


    private EstateType FieldİsyeriEmalgi;
    public EstateType İsyeriEmalgi
    {
        get
        {
            if (FieldİsyeriEmalgi == default(EstateType))
            {
                FieldİsyeriEmalgi = DBProvider.GetEstateTypeByKey("isyeri");
            }
            return FieldİsyeriEmalgi;
        }
    }

    private EstateType FieldArsaEmalgi;
    public EstateType ArsaEmalgi
    {
        get
        {
            if (FieldArsaEmalgi == default(EstateType))
            {
                FieldArsaEmalgi = DBProvider.GetEstateTypeByKey("arsa");
            }
            return FieldArsaEmalgi;
        }
    }

    private EstateType FieldDevremulkEmalgi;
    public EstateType DevremulkEmalgi
    {
        get
        {
            if (FieldDevremulkEmalgi == default(EstateType))
            {
                FieldDevremulkEmalgi = DBProvider.GetEstateTypeByKey("devremulk");
            }
            return FieldDevremulkEmalgi;
        }
    }

    private EstateType FieldTuristikİsletmeEmalgi;
    public EstateType TuristikİsletmeEmalgi
    {
        get
        {
            if (FieldTuristikİsletmeEmalgi == default(EstateType))
            {
                FieldTuristikİsletmeEmalgi = DBProvider.GetEstateTypeByKey("turistik-isletme");
            }
            return FieldTuristikİsletmeEmalgi;
        }
    }

    public SearchQuery GetSearchQueryFromHash(string hash)
    {
        string query = Decypt(hash);

        Dictionary<string, string> searchParams = new Dictionary<string, string>();
        foreach (string item in query.Split('&'))
        {
            string[] s = item.Split('=');
            searchParams.Add(s[0], s[1]);
        }

        string city = searchParams["city"];
        string town = searchParams["town"];
        string district = searchParams["district"];
        string estateType = searchParams["estateType"];
        string childEstateType = searchParams["childEstateType"];
        string marketingType = searchParams["marketingType"];
        string areaFrom = searchParams["areaFrom"];
        string areaTo = searchParams["areaTo"];
        string priceFrom = searchParams["priceFrom"];
        string priceTo = searchParams["priceTo"];
        string priceCurrency = searchParams["priceCurrency"];
        string isExchangable = searchParams["isExchangable"];
        string ageFrom = searchParams["ageFrom"];
        string ageTo = searchParams["ageTo"];
        string bathCount = searchParams["bathCount"];
        string floorCount = searchParams["floorCount"];
        string floor = searchParams["floor"];
        string heatingType = searchParams["heatingType"];
        string roomHallType = searchParams["roomHallType"];
        string advertOwner = searchParams["advertOwner"];
        string isFlatForLandMethod = searchParams["isFlatForLandMethod"];
        string creditType = searchParams["creditType"];
        string deedType = searchParams["deedType"];
        string fuelType = searchParams["fuelType"];
        string isSublease = searchParams["isSublease"];
        string advertStatusType = searchParams["advertStatusType"];
        string advertUsingType = searchParams["advertUsingType"];
        string starCount = searchParams["starCount"];
        string isSettlement = searchParams["isSettlement"];
        string bedCountFrom = searchParams["bedCountFrom"];
        string bedCountTo = searchParams["bedCountTo"];
        string roomCountFrom = searchParams["roomCountFrom"];
        string roomCountTo = searchParams["roomCountTo"];
        string features = searchParams["features"];

        return new SearchQuery(marketingType, estateType, childEstateType, city, town, district, priceFrom, priceTo, priceCurrency, areaFrom, areaTo, isExchangable, ageFrom, ageTo, heatingType, roomHallType, floor, floorCount, advertOwner, bathCount, isFlatForLandMethod, creditType, deedType, fuelType, isSublease, advertStatusType, advertUsingType, starCount, isSettlement, bedCountFrom, bedCountTo, roomCountFrom, roomCountTo, features);
    }

    public string GetSearchQueryHash(string city, string town, string district, string estateType, string childEstateType, string marketingType, string areaFrom, string areaTo, string priceFrom, string priceTo, string priceCurrency, string isExchangable, string _ageFrom, string _ageTo, string _bathCount, string _floorCount, string _floor, string _heatingType, string _roomHall, string _advertOwner, string _isFlatForLandMethod, string _creditType, string _deedType, string _fuelType, string _isSublease, string _advertStatus, string _advertUsing, string _starCount, string _isSettlement, string _bedCountFrom, string _bedCountTo, string _roomCountFrom, string _roomCountTo, string _features)
    {
        string query = "marketingType=" + marketingType;
        query += "&estateType=" + estateType;
        query += "&childEstateType=" + childEstateType;
        query += "&city=" + city;
        query += "&town=" + town;
        query += "&district=" + district;
        query += "&priceFrom=" + priceFrom;
        query += "&priceTo=" + priceTo;
        query += "&priceCurrency=" + priceCurrency;
        query += "&areaFrom=" + areaFrom;
        query += "&areaTo=" + areaTo;
        query += "&isExchangable=" + isExchangable;
        query += "&ageFrom=" + _ageFrom;
        query += "&ageTo=" + _ageTo;
        query += "&heatingType=" + _heatingType;
        query += "&roomHallType=" + _roomHall;
        query += "&floor=" + _floor;
        query += "&floorCount=-1";
        query += "&advertOwner=-1";
        query += "&bathCount=" + _bathCount;
        query += "&isFlatForLandMethod=" + _isFlatForLandMethod;
        query += "&creditType=" + _creditType;
        query += "&deedType=" + _deedType;
        query += "&fuelType=" + _fuelType;
        query += "&isSublease=" + _isSublease;
        query += "&advertStatusType=" + _advertStatus;
        query += "&advertUsingType=" + _advertUsing;
        query += "&starCount=" + _starCount;
        query += "&isSettlement=" + _isSettlement;
        query += "&bedCountFrom=" + _bedCountFrom;
        query += "&bedCountTo=" + _bedCountTo;
        query += "&roomCountFrom=" + _roomCountFrom;
        query += "&roomCountTo=" + _roomCountTo;
        query += "&features=" + _features;

        string hash = Encrypt(query);
        return hash;
    }
}