using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DBLayer
{
    public class SearchQuery : RealEstateEntities
    {
        public int CityId { get; set; }
        public int TownId { get; set; }

        public bool _DistrictId { get; set; }
        public int[] DistrictId { get; set; }
        public int EstateTypeId { get; set; }

        public bool _EstateTypeChildIdList { get; set; }
        public int[] EstateTypeChildIdList { get; set; }
        public int MarketingTypeId { get; set; }
        public int AreaFrom { get; set; }
        public int AreaTo { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int PriceCurrencyId { get; set; }
        public bool? IsExchangable { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }

        public bool _HeatingTypeId { get; set; }
        public int[] HeatingTypeId { get; set; }


        public bool _RoomHallId { get; set; }
        public int[] RoomHallId { get; set; }


        public bool _FloorId { get; set; }
        public int[] FloorId { get; set; }
        
        
        public int FloorCount { get; set; }
        public int AdvertOwner { get; set; }
        public int BathCount { get; set; }
        public bool? IsFlatForLandMethod { get; set; }
        public int CreditTypeId { get; set; }
        public int DeedTypeId { get; set; }

        public bool _FuelTypeId { get; set; }        
        public int[] FuelTypeId { get; set; }
        
        public bool? IsSublease { get; set; }
        public int AdvertStatusId { get; set; }
        public int AdvertUsingTypeId { get; set; }
        public int StarCountId { get; set; }
        public bool? IsSettlement { get; set; }
        public int BedCountFrom { get; set; }
        public int BedCountTo { get; set; }
        public int RoomCountFrom { get; set; }
        public int RoomCountTo { get; set; }


        public bool _FeaturesId { get; set; }
        public int[] FeaturesId { get; set; }

        public SearchQuery(object cityId, object townId, object districtId, object estateTypeId, object marketingTypeId, object area, object price, object priceCurrency)
        {
            int _cityId = -1;
            int.TryParse(cityId.ToString(), out _cityId);
            this.CityId = _cityId;

            int _townId = -1;
            int.TryParse(townId.ToString(), out _townId);
            this.TownId = _townId;

            int _districtId = -1;
            if (districtId.ToString().Contains(','))
            {
                string[] d = districtId.ToString().Split(',');
                DistrictId = new int[d.Length];
                for (int i = 0; i < d.Length; i++)
                {
                    if (int.TryParse(d[i], out _districtId))
                        this.DistrictId[i] = Convert.ToInt32(d[i]);
                }
                this._DistrictId = true;
            }
            else
            {
                this.DistrictId = new int[1];
                this.DistrictId[0] = Convert.ToInt32(districtId);

                if (districtId.ToString() != "-1")
                    this._DistrictId = true;
                else
                    this._DistrictId = false;
            }


            int _estateTypeId = -1;
            int.TryParse(estateTypeId.ToString(), out _estateTypeId);
            this.EstateTypeId = _estateTypeId;

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

        public SearchQuery(object marketingType, object estateType, object childEstateType, object city, object town, object district, object priceFrom, object priceTo, object priceCurrency, object areaFrom, object areaTo, object isExchangable, object ageFrom, object ageTo, object heatingType, object roomHallType, object floor, object floorCount, object advertOwner, object bathCount, object isFlatForLandMethod, object creditType, object deedType, object fuelType, object isSublease, object advertStatusType, object advertUsingType, object starCount, object isSettlement, object bedCountFrom, object bedCountTo, object roomCountFrom, object roomCountTo, object features)
        {
            int _cityId = -1;
            int.TryParse(city.ToString(), out _cityId);
            this.CityId = _cityId;

            int _townId = -1;
            int.TryParse(town.ToString(), out _townId);
            this.TownId = _townId;

            int _districtId = -1;
            if (district.ToString().Contains(','))
            {
                string[] d = district.ToString().Split(',');
                DistrictId = new int[d.Length];
                for (int i = 0; i < d.Length; i++)
                {
                    if (int.TryParse(d[i], out _districtId))
                        this.DistrictId[i] = Convert.ToInt32(d[i]);
                }
                this._DistrictId = true;
            }
            else
            {
                this.DistrictId = new int[1];
                this.DistrictId[0] = Convert.ToInt32(district);

                if (district.ToString() != "-1")
                    this._DistrictId = true;
                else
                    this._DistrictId = false;
            }

            int _estateTypeId = -1;
            int.TryParse(estateType.ToString(), out _estateTypeId);
            this.EstateTypeId = _estateTypeId;

            int _childEstateTypeId = -1;
            if (childEstateType.ToString().Contains(','))
            {
                string[] c = childEstateType.ToString().Split(',');
                EstateTypeChildIdList = new int[c.Length];
                for (int i = 0; i < c.Length; i++)
                {
                    if (int.TryParse(c[i], out _childEstateTypeId))
                        this.EstateTypeChildIdList[i] = Convert.ToInt32(c[i]);
                }
                this._EstateTypeChildIdList = true;
            }
            else
            {
                this.EstateTypeChildIdList = new int[1];
                this.EstateTypeChildIdList[0] = Convert.ToInt32(childEstateType);

                if (childEstateType.ToString() == "-1")
                    this._EstateTypeChildIdList = false;
                else
                    this._EstateTypeChildIdList = true;
            }

            int _marketingTypeId = -1;
            int.TryParse(marketingType.ToString(), out _marketingTypeId);
            this.MarketingTypeId = _marketingTypeId;

            int _areaFrom = -1;
            int _areaTo = -1;
            int.TryParse(areaFrom.ToString(), out _areaFrom);
            int.TryParse(areaTo.ToString(), out _areaTo);            
            this.AreaFrom = _areaFrom;
            this.AreaTo = _areaTo;


            int _priceFrom = -1;
            int _priceTo = -1;
            int.TryParse(priceFrom.ToString(), out _priceFrom);
            int.TryParse(priceTo.ToString(), out _priceTo);            
            this.PriceFrom = _priceFrom;
            this.PriceTo = _priceTo;

            int _priceCurrencyId = -1;
            int.TryParse(priceCurrency.ToString(), out _priceCurrencyId);
            this.PriceCurrencyId = _priceCurrencyId;

            bool? _isExchangable = null;
            if(isExchangable.ToString() != "-1")
            {
                if (isExchangable.ToString() == "1")
                    _isExchangable = true;
                else
                    _isExchangable = false;
            }
            this.IsExchangable = _isExchangable;

            int _ageFrom = -1;
            int _ageTo = -1;
            int.TryParse(ageFrom.ToString(), out _ageFrom);
            int.TryParse(ageTo.ToString(), out _ageTo);
            this.AgeFrom = _ageFrom;
            this.AgeTo = _ageTo;

            int _heatingType = -1;
            if (heatingType.ToString().Contains(','))
            {
                string[] h = heatingType.ToString().Split(',');
                this.HeatingTypeId = new int[h.Length];
                for (int i = 0; i < h.Length; i++)
                {
                    if(int.TryParse(h[i], out _heatingType))
                        this.HeatingTypeId[i] = Convert.ToInt32(h[i]);
                }
                this._HeatingTypeId = true;
            }
            else
            {
                this.HeatingTypeId = new int[1];
                this.HeatingTypeId[0] = Convert.ToInt32(_heatingType);

                if (heatingType.ToString() != "-1")
                    this._HeatingTypeId = true;
                else
                    this._HeatingTypeId = false;
            }

            int _roomHall = -1;
            if (roomHallType.ToString().Contains(','))
            {
                string[] r = roomHallType.ToString().Split(',');
                this.RoomHallId = new int[r.Length];
                for (int i = 0; i < r.Length; i++)
                {
                    if (int.TryParse(r[i], out _roomHall))
                        this.RoomHallId[i] = Convert.ToInt32(r[i]);
                }
                this._RoomHallId = true;
            }
            else
            {
                this.RoomHallId = new int[1];
                this.RoomHallId[0] = Convert.ToInt32(roomHallType);

                if (roomHallType.ToString() != "-1")
                    this._RoomHallId = true;
                else
                    this._RoomHallId = false;
            }

            
            int _floor = -1;
            if (floor.ToString().Contains(','))
            {
                string[] f = floor.ToString().Split(',');
                this.FloorId = new int[f.Length];
                for (int i = 0; i < f.Length; i++)
                {
                    if (int.TryParse(f[i], out _floor))
                        this.FloorId[i] = Convert.ToInt32(f[i]);
                }
                this._FloorId = true;
            }
            else
            {
                this.FloorId = new int[1];
                this.FloorId[0] = Convert.ToInt32(floor);

                if (floor.ToString() != "-1")
                    this._FloorId = true;
                else
                    this._FloorId = false;
            }


            int _floorCount = -1;
            int.TryParse(floorCount.ToString(), out _floorCount);
            this.FloorCount = _floorCount;

            int _advertOwner = -1;
            int.TryParse(advertOwner.ToString(), out _advertOwner);
            this.AdvertOwner = _advertOwner;

            int _bathCount = -1;
            int.TryParse(bathCount.ToString(), out _bathCount);
            this.BathCount = _bathCount;

            bool? _isFlatForLandMethod = null;
            if (isFlatForLandMethod.ToString() != "-1")
            {
                if (isFlatForLandMethod.ToString() == "1")
                    _isFlatForLandMethod = true;
                else
                    _isFlatForLandMethod = false;
            }
            this.IsFlatForLandMethod = _isFlatForLandMethod;

            int _creditType = -1;
            int.TryParse(creditType.ToString(), out _creditType);
            this.CreditTypeId = _creditType;

            int _deedType = -1;
            int.TryParse(deedType.ToString(), out _deedType);
            this.DeedTypeId = _deedType;

            int _fuelType = -1;
            if (fuelType.ToString().Contains(','))
            {
                string[] f = fuelType.ToString().Split(',');
                this.FuelTypeId = new int[f.Length];
                for (int i = 0; i < f.Length; i++)
                {
                    if (int.TryParse(f[i], out _fuelType))
                        this.FuelTypeId[i] = Convert.ToInt32(f[i]);
                }
                this._FuelTypeId = true;
            }
            else
            {
                this.FuelTypeId = new int[1];
                this.FuelTypeId[0] = Convert.ToInt32(fuelType);

                if (fuelType.ToString() != "-1")
                    this._FuelTypeId = true;
                else
                    this._FuelTypeId = false;
            }

            bool? _isSublease = null;
            if (isSublease.ToString() != "-1")
            {
                if (isSublease.ToString() == "1")
                    _isSublease = true;
                else
                    _isSublease = false;
            }
            this.IsSublease = _isSublease;

            int _advertStatusType = -1;
            int.TryParse(advertStatusType.ToString(), out _advertStatusType);
            this.AdvertStatusId = _advertStatusType;

            int _advertUsingType = -1;
            int.TryParse(advertUsingType.ToString(), out _advertUsingType);
            this.AdvertUsingTypeId = _advertUsingType;

            int _starCount = -1;
            int.TryParse(starCount.ToString(), out _starCount);
            this.StarCountId = _starCount;


            bool? _isSettlement = null;
            if (isSettlement.ToString() != "-1")
            {
                if (isSettlement.ToString() == "1")
                    _isSettlement = true;
                else
                    _isSettlement = false;
            }
            this.IsSettlement = _isSettlement;

            int _bedCountFrom = -1;
            int _bedCountTo = -1;
            int.TryParse(bedCountFrom.ToString(), out _bedCountFrom);
            int.TryParse(bedCountTo.ToString(), out _bedCountTo);
            this.BedCountFrom = _bedCountFrom;
            this.BedCountTo = _bedCountTo;

            int _roomCountFrom = -1;
            int _roomCountTo = -1;
            int.TryParse(roomCountFrom.ToString(), out _roomCountFrom);
            int.TryParse(roomCountTo.ToString(), out _roomCountTo);
            this.RoomCountFrom = _roomCountFrom;
            this.RoomCountTo = _roomCountTo;

            int _feature = -1;
            if (features.ToString().Contains(','))
            {
                string[] f = features.ToString().Split(',');
                this.FeaturesId = new int[f.Length];
                for (int i = 0; i < f.Length; i++)
                {
                    if (int.TryParse(f[i], out _feature))
                        this.FeaturesId[i] = Convert.ToInt32(f[i]);
                }
                this._FeaturesId = true;
            }
            else
            {
                this.FeaturesId = new int[1];
                this.FeaturesId[0] = Convert.ToInt32(features);

                if (features.ToString() != "-1")
                    this._FeaturesId = true;                
                else
                    this._FeaturesId = false;                
            }
        }

        public string GetHash()
        {
            string query = "marketingType=" + MarketingTypeId;
            query += "&estateType=" + EstateTypeId;
            query += "&childEstateType=" + GetArrayStringFormat(EstateTypeChildIdList, _EstateTypeChildIdList);
            query += "&city=" + CityId;
            query += "&town=" + TownId;
            query += "&district=" + GetArrayStringFormat(DistrictId, _DistrictId);
            query += "&priceFrom=" + PriceFrom;
            query += "&priceTo=" + PriceTo;
            query += "&priceCurrency=" + PriceCurrencyId;
            query += "&areaFrom=" + AreaFrom;
            query += "&areaTo=" + AreaTo;
            query += "&isExchangable=" + GetBooleanStringFormat(IsExchangable);
            query += "&ageFrom=" + AgeFrom;
            query += "&ageTo=" + AgeTo;
            query += "&heatingType=" + GetArrayStringFormat(HeatingTypeId, _HeatingTypeId);
            query += "&roomHallType=" + GetArrayStringFormat(RoomHallId, _RoomHallId);
            query += "&floor=" + GetArrayStringFormat(FloorId, _FloorId);
            query += "&floorCount=-1";
            query += "&advertOwner=-1";
            query += "&bathCount=" + BathCount;
            query += "&isFlatForLandMethod=" + GetBooleanStringFormat(IsFlatForLandMethod);
            query += "&creditType=" + CreditTypeId;
            query += "&deedType=" + DeedTypeId;
            query += "&fuelType=" + GetArrayStringFormat(FuelTypeId, _FuelTypeId);
            query += "&isSublease=" + GetBooleanStringFormat(IsSublease);
            query += "&advertStatusType=" + AdvertStatusId;
            query += "&advertUsingType=" + AdvertUsingTypeId;
            query += "&starCount=" + StarCountId;
            query += "&isSettlement=" + GetBooleanStringFormat(IsSettlement);
            query += "&bedCountFrom=" + BedCountFrom;
            query += "&bedCountTo=" + BedCountTo;
            query += "&roomCountFrom=" + RoomCountFrom;
            query += "&roomCountTo=" + RoomCountTo;
            query += "&features=" + GetArrayStringFormat(FeaturesId, _FeaturesId);

            return Encrypt(query);            
        }

        private string GetArrayStringFormat(int[] input, bool inputControl)
        {
            if (inputControl)
            {
                string result = "";
                foreach (int item in input)
                {
                    if (item != input.Last())
                        result += item.ToString() + ",";
                    else
                        result += item.ToString();
                }
                return result;
            }
            else
            {
                return "-1";
            }
        }

        private string GetBooleanStringFormat(bool? input)
        {
            if (input.HasValue)
                return (bool)input ? "1" : "0";
            else
                return "-1";
        }

        #region Encryption
        private string CyrptoKey = "Faruk";
        private TripleDESCryptoServiceProvider _cryptDES3;
        private TripleDESCryptoServiceProvider cryptDES3
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
        private MD5CryptoServiceProvider cryptMD5Hash
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

        private string Encrypt(string text)
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
        #endregion
        
    }
}
