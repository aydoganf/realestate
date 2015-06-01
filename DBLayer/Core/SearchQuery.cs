using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public class SearchQuery : RealEstateEntities
    {
        public int CityId { get; set; }
        public int TownId { get; set; }
        public int DistrictId { get; set; }
        public int EstateTypeId { get; set; }
        public int[] EstateTypeChildIdList { get; set; }
        public int MarketingTypeId { get; set; }
        public int AreaFrom { get; set; }
        public int AreaTo { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int PriceCurrencyId { get; set; }


        public SearchQuery(object cityId, object townId, object districtId, object estateTypeId, object marketingTypeId, object area, object price, object priceCurrency)
        {
            int _cityId = -1;
            int.TryParse(cityId.ToString(), out _cityId);
            this.CityId = _cityId;

            int _townId = -1;
            int.TryParse(townId.ToString(), out _townId);
            this.TownId = _townId;

            int _districtId = -1;
            int.TryParse(districtId.ToString(), out _districtId);
            this.DistrictId = _districtId;

            int _estateTypeId = -1;
            int.TryParse(estateTypeId.ToString(), out _estateTypeId);
            this.EstateTypeId = _estateTypeId;

            if (_estateTypeId != -1)
            {
                List<EstateType> childList = GetEstateTypeListByParentId(_estateTypeId);
                EstateTypeChildIdList = new int[childList.Count];
                for (int i = 0; i < childList.Count; i++)
                {
                    EstateTypeChildIdList[i] = childList[i].ObjectId;
                }
            }

            int _marketingTypeId = -1;
            int.TryParse(marketingTypeId.ToString(), out _marketingTypeId);
            this.MarketingTypeId = _marketingTypeId;

            int _areaFrom = -1;
            int _areaTo = -1;
            if (area.ToString().Contains(','))
            {
                int.TryParse(area.ToString().Split(',')[0], out _areaFrom);
                int.TryParse(area.ToString().Split(',')[1], out _areaTo);
            }
            this.AreaFrom = _areaFrom;
            this.AreaTo = _areaTo;


            int _priceFrom = -1;
            int _priceTo = -1;
            if (price.ToString().Contains(','))
            {
                int.TryParse(price.ToString().Split(',')[0], out _priceFrom);
                int.TryParse(price.ToString().Split(',')[1], out _priceTo);
            }
            this.PriceFrom = _priceFrom;
            this.PriceTo = _priceTo;

            int _priceCurrencyId = -1;
            int.TryParse(priceCurrency.ToString(), out _priceCurrencyId);
            this.PriceCurrencyId = _priceCurrencyId;
        }

        
    }
}
