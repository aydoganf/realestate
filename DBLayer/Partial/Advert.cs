using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class Advert
    {
        public void Delete()
        {
            this.Deleted = true;
        }

        public string PrimaryAdvertPhoto
        {
            get
            {
                if (this.AdvertPhoto.FirstOrDefault(i=> i.Deleted == false) != null)
                {
                    return this.AdvertPhoto.FirstOrDefault(i => i.Deleted == false).PhotoName;
                }
                else
                {
                    return "no-photo.jpg";
                }
            }
        }

        public string PrimarySmallAdvertPhoto
        {
            get
            {
                if (this.AdvertPhoto.FirstOrDefault(i=> i.Deleted == false) != null)
                {
                    return this.AdvertPhoto.FirstOrDefault(i => i.Deleted == false).SmallPhotoName;
                }
                else
                {
                    return "no-photo.jpg";
                }
            }
        }
    }

    public partial class RealEstateEntities
    {
        public Advert AddAdvert(string title, string description, int area, int age, int? heatingTypeObjectId, int? roomHallObjectId, int marketingTypeObjectId, int estateTypeObjectId, int? floorObjectId, int? advertTypeObjectId, int? bathCount, int? floorCount, int? deposit, int? depositCurrencyObjectId, int price, int priceCurrencyObjectId, int createdByPersonObjectId, string latitude, string longitude, string gAddress, int districtObjectId, int townObjectId, int cityObjectId)
        {
            Advert obj = new Advert() 
            {
                Title = title,
                Description = description,
                Area = area,
                Age = age,
                HeatingTypeObjectId = heatingTypeObjectId,
                RoomHallObjectId = roomHallObjectId,
                MarketingTypeObjectId = marketingTypeObjectId,
                EstateTypeObjectId = estateTypeObjectId,
                FloorObjectId = floorObjectId,
                AdvertTypeObjectId = advertTypeObjectId,
                BathCount = bathCount,
                FloorCount = floorCount,
                Deposit = deposit,
                DepositCurrencyObjectId = depositCurrencyObjectId,
                Price = price,
                PriceCurrencyObjectId = priceCurrencyObjectId,
                CreatedByPersonObjectId = createdByPersonObjectId,
                Latitude = latitude,
                Longitude = longitude,
                GAddress = gAddress,
                DistrictObjectId = districtObjectId,
                TownObjectId = townObjectId,
                CityObjectId = cityObjectId,
                IsActive = true,
                Deleted = false,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            AddToAdvert(obj);
            Random rnd = new Random();
            int number = rnd.Next(100000, 999999);

            string advertNumber = number.ToString();
            obj.AdvertNumber = advertNumber;
            SaveChanges();            

            return obj;
        }

        public List<Advert> GetAdvertList()
        {
            return Advert.Where(i => i.Deleted == false).ToList();
        }

        public Advert GetAdvertByObjectId(int objectId)
        {
            return Advert.FirstOrDefault(i => i.Deleted == false && i.ObjectId == objectId);
        }

        public int GetAdvertCount()
        {
            return Advert.Where(i => i.Deleted == false).Count();
        }

        public List<Advert> GetMostRecentAdvertList(int count)
        {
            return Advert.Where(i => i.Deleted == false).OrderByDescending(i => i.UpdateDate).ThenByDescending(i => i.CreateDate).Take(count).ToList();
        }

        public List<Advert> GetMostRecentAdvertList(int count, int skip)
        {
            int total = Advert.Where(i => i.Deleted == false).Count();
            if (total >= (count + skip))
                return Advert.Where(i => i.Deleted == false).OrderByDescending(i => i.UpdateDate).ThenByDescending(i => i.CreateDate).Skip(skip).Take(count).ToList();
            else if(total >= skip)
                return Advert.Where(i => i.Deleted == false).OrderByDescending(i => i.UpdateDate).ThenByDescending(i => i.CreateDate).Skip(skip).Take(total - skip).ToList();
            else
                return Advert.Where(i => i.Deleted == false).OrderByDescending(i => i.UpdateDate).ThenByDescending(i => i.CreateDate).ToList();
        }

        public List<Advert> QuickSearchAdvert(SearchQuery obj)
        {
            return Advert.Where(
                i => (obj.CityId != -1 ? i.CityObjectId == obj.CityId : true) &&
                    (obj.TownId != -1 ? i.TownObjectId == obj.TownId : true) &&
                    (obj.DistrictId != -1 ? i.DistrictObjectId == obj.DistrictId : true) &&
                    (obj.EstateTypeId != -1 ? obj.EstateTypeChildIdList.Contains(i.EstateTypeObjectId) : true) &&
                    (obj.MarketingTypeId != -1 ? i.MarketingTypeObjectId == obj.MarketingTypeId : true) &&
                    (obj.AreaFrom != -1 ? i.Area >= obj.AreaFrom : true) &&
                    (obj.AreaTo != -1 ? i.Area <= obj.AreaTo : true) &&
                    (obj.PriceFrom != -1 ? i.Price >= obj.PriceFrom : true) &&
                    (obj.PriceTo != -1 ? i.Price <= obj.PriceTo : true) &&
                    (obj.PriceCurrencyId != -1 ? i.PriceCurrencyObjectId == obj.PriceCurrencyId : true) &&
                    i.Deleted == false && i.IsActive
                ).Distinct().OrderByDescending(i=> i.UpdateDate).ThenByDescending(i=> i.CreateDate).ToList();
        }
    }
}
