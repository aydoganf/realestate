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
                CreateDate = DateTime.Now
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
    }
}
