using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayer;
using System.Web.Services;
using System.Web.Script.Services;

public partial class service_service : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public const int Konut = 2;
    public const int Isyeri = 3;
    public const int Arsa = 4;
    public const int Devremulk = 5;
    public const int Turistik = 6;

    

    #region EstateType
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<JSEstateTpe> GetEstateTypeTreeList()
    {
        List<JSEstateTpe> result = new List<JSEstateTpe>();

        List<KeyValueStore> baseList = GetBaseEstateTypeList();
        foreach (KeyValueStore item in baseList)
        {
            List<KeyValueStore> childList = GetEstateTypeListByParentEstateTypeID(item.Value);
            JSEstateTpe js = ConvertEstateTypeToJS(item, childList.Count != 0);

            js.children = new JSEstateTpe[childList.Count];
            int i = 0;
            foreach (KeyValueStore childItem in childList)
            {
                js.children[i] = recursiveTreeConstruct(childItem);
                i++;
            }
            result.Add(js);
        }

        return result;
    }

    private static JSEstateTpe recursiveTreeConstruct(KeyValueStore estateType)
    {
        JSEstateTpe parentNode = new JSEstateTpe();
        List<KeyValueStore> childEstateTypeList = new List<KeyValueStore>();


        parentNode = ConvertEstateTypeToJS(estateType, GetEstateTypeListByParentEstateTypeID(estateType.Value).Count != 0);

        childEstateTypeList = GetEstateTypeListByParentEstateTypeID(estateType.Value);

        if (childEstateTypeList.Count != 0)
        {
            parentNode.children = new JSEstateTpe[childEstateTypeList.Count];
            int i = 0;
            foreach (KeyValueStore childItem in childEstateTypeList)
            {
                parentNode.children[i] = recursiveTreeConstruct(childItem);
                i++;
            }
            return parentNode;
        }
        else
        {
            parentNode.children = null;
            return parentNode;
        }
    }

    private static List<KeyValueStore> GetEstateTypeListByParentEstateTypeID(string parentValue)
    {
        //RealEstateEntities dc = new RealEstateEntities();
        //return dc.GetEstateTypeListByParentId(parentEstateTypeId);

        return ApplicationGenericControls._estateTypes.Where(e => e.ParentValue == parentValue).ToList();
    }

    private static List<KeyValueStore> GetBaseEstateTypeList()
    {
        //RealEstateEntities dc = new RealEstateEntities();
        //return dc.GetBaseEstateTypeList();
        return ApplicationGenericControls._estateTypes.Where(e => string.IsNullOrEmpty(e.ParentValue)).ToList();
    }

    private static JSEstateTpe ConvertEstateTypeToJS(KeyValueStore obj, bool isDisabled)
    {
        string a_attr_class = "";
        if (isDisabled)
            a_attr_class = "no_checkbox";

        return new JSEstateTpe()
        {
            id = obj.Value,
            text = obj.Key,
            state = new JSEstateTpeState()
            {
                disabled = isDisabled
            },
            icon = "",
            a_attr = new JSa_attr() { @class = a_attr_class }
        };
    }
    #endregion

    #region Estate Map

    public class JSMapEstate
    {
        public string Link { get; set; }
        public int Price { get; set; }
        public string PriceCurrency { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Picture { get; set; }
        public int Area { get; set; }
        public string EstateType { get; set; }
        public string ParentEstateType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MarketingType { get; set; }
    }

    public class JSMapEstateResponse
    {
        public int StatusCode { get; set; }
        public string ResultMessage { get; set; }
        public JSMapEstate[] EstateList { get; set; }

        public string LatCenter { get; set; }
        public string LongCenter { get; set; }
    }

    public static JSMapEstate[] BuildJSMapEstateList(List<Advert> input)
    {
        JSMapEstate[] result = new JSMapEstate[input.Count];

        for (int i = 0; i < input.Count; i++)
        {
            result[i] = BuildJSMapEstate(input[i]);
        }

        return result;
    }

    public static JSMapEstate BuildJSMapEstate(Advert input)
    {
        return new JSMapEstate()
        {
            Price = input.Price,
            PriceCurrency = input.PriceCurrency.CurrencyName,
            Title = input.Title,
            ShortTitle = input.Title.Substring(0, 25),
            Picture = input.PrimarySmallAdvertPhoto,
            Area = input.Area,
            EstateType = input.EstateType.TypeName,
            ParentEstateType = input.EstateType.ParentEstateType.TypeName,
            Link = FormatAdvertLink(input),
            Latitude = input.Latitude,
            Longitude = input.Longitude,
            MarketingType = input.MarketingType.TypeName
        };
    }

    public static string FormatAdvertLink(Advert obj)
    {
        return "/emlak-detay/" + obj.CityName + "/" + obj.TownName + "/" + obj.DistrictName + "/" + obj.AdvertNumber + "/" + FormatAdvertTitle(obj.Title);
    }

    public static string FormatAdvertTitle(string title)
    {
        title = title.Replace('+', '_');
        title = title.Replace(' ', '-');
        title = title.Replace('.', '-');
        title = title.Replace("'", "-");
        return title;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static JSMapEstateResponse GetMapAdverts()
    {
        RealEstateEntities dc = new RealEstateEntities();
        List<Advert> advertList = dc.GetMostRecentAdvertList(20);
        double latTotal = 0;
        double longTotal = 0;

        foreach (Advert item in advertList)
        {
            latTotal += Convert.ToDouble(item.Latitude, System.Globalization.CultureInfo.InvariantCulture);
            longTotal += Convert.ToDouble(item.Longitude, System.Globalization.CultureInfo.InvariantCulture);
        }

        double latCenter = latTotal / advertList.Count;
        double longCenter = longTotal / advertList.Count;

        return new JSMapEstateResponse()
        {
            StatusCode = 0,
            ResultMessage = "İşlem başarılı",
            EstateList = BuildJSMapEstateList(advertList),
            LatCenter = latCenter.ToString(),
            LongCenter = longCenter.ToString()
        };
    }

    #endregion
}