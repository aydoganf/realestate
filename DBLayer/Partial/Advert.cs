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
        public Advert AddAdvert(string title, string description, int area, int? age, int? heatingTypeObjectId, int? roomHallObjectId, int marketingTypeObjectId, int estateTypeObjectId, int? floorObjectId, int? advertTypeObjectId, int? bathCount, int? floorCount, int? deposit, int? depositCurrencyObjectId, int price, int priceCurrencyObjectId, int createdByPersonObjectId, string latitude, string longitude, string gAddress, int districtObjectId, int townObjectId, int cityObjectId, string cityName, string townName, string districtName, int? advertOwnerTypeObjectId, bool? isFlatForLandMethod, int? creditTypeObjectId, int? deedTypeObjectId, bool? isExchangable, int? fuelTypeObjectId, bool? isSublease, int? advertStatusObjectId, int? advertUsingTypeObjectId, int? starCountObjectId, bool? isSettlement, int? bedCount, int? roomCount)
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
                UpdateDate = DateTime.Now,
                CityName = cityName,
                TownName = townName,
                DistrictName = districtName,
                AdvertOwnerTypeObjectId = advertOwnerTypeObjectId,
                IsFlatForLandMethod = isFlatForLandMethod,
                CreditTypeObjectId = creditTypeObjectId,
                DeedTypeObjectId = deedTypeObjectId,
                IsExchangable = isExchangable,
                FuelTypeObjectId = fuelTypeObjectId,
                IsSublease = isSublease,
                AdvertStatusObjectId = advertStatusObjectId,
                StarCountObjectId = starCountObjectId,
                IsSettlement = isSettlement,
                BedCount = bedCount,
                RoomCount = roomCount
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
                    (obj._DistrictId ? obj.DistrictId.Contains(i.DistrictObjectId) : true) &&
                    (obj.EstateTypeId != -1 ? i.ParentEstateTypeObjectId == obj.EstateTypeId : true) &&
                    (obj.MarketingTypeId != -1 ? i.MarketingTypeObjectId == obj.MarketingTypeId : true) &&
                    (obj.AreaFrom != -1 ? i.Area >= obj.AreaFrom : true) &&
                    (obj.AreaTo != -1 ? i.Area <= obj.AreaTo : true) &&
                    (obj.PriceFrom != -1 ? i.Price >= obj.PriceFrom : true) &&
                    (obj.PriceTo != -1 ? i.Price <= obj.PriceTo : true) &&
                    (obj.PriceCurrencyId != -1 ? i.PriceCurrencyObjectId == obj.PriceCurrencyId : true) &&
                    i.Deleted == false && i.IsActive
                ).Distinct().OrderByDescending(i=> i.UpdateDate).ThenByDescending(i=> i.CreateDate).ToList();
        }

        public List<Advert> AdvancedSearchAdvert(SearchQuery obj, int pageNo, int pageItemCount)
        {
            return Advert.Where(
                i => (obj.AreaFrom != -1 ? i.Area >= obj.AreaFrom : true) &&
                    (obj.AreaTo != -1 ? i.Area <= obj.AreaTo : true) &&
                    (obj.AgeFrom != -1 ? i.Age >= obj.AgeFrom : true) &&
                    (obj.AgeTo != -1 ? i.Age >= obj.AgeTo : true) &&
                    (obj._HeatingTypeId ? obj.HeatingTypeId.Contains(i.HeatingTypeObjectId.Value) : true) &&
                    (obj._RoomHallId ? obj.RoomHallId.Contains(i.RoomHallObjectId.Value) : true) &&
                    (obj.MarketingTypeId != -1 ? i.MarketingTypeObjectId == obj.MarketingTypeId : true) &&
                    (obj.EstateTypeId != -1 ? i.ParentEstateTypeObjectId == obj.EstateTypeId : true) &&
                    (obj._EstateTypeChildIdList ? obj.EstateTypeChildIdList.Contains(i.EstateTypeObjectId) : true) &&
                    (obj._FloorId ? obj.FloorId.Contains(i.FloorObjectId.Value) : true) &&
                    (obj.BathCount != -1 ? i.BathCount == obj.BathCount : true) &&
                    (obj.FloorCount != -1 ? i.FloorCount == obj.FloorCount : true) &&
                    (obj.PriceFrom != -1 ? i.Price >= obj.PriceFrom : true) &&
                    (obj.PriceTo != -1 ? i.Price <= obj.PriceTo : true) &&
                    (obj.PriceCurrencyId != -1 ? i.PriceCurrencyObjectId == obj.PriceCurrencyId : true) &&
                    (obj.CityId != -1 ? i.CityObjectId == obj.CityId : true) &&
                    (obj.TownId != -1 ? i.TownObjectId == obj.TownId : true) &&
                    (obj._DistrictId ? obj.DistrictId.Contains(i.DistrictObjectId) : true) &&
                    (obj.IsFlatForLandMethod.HasValue ? i.IsFlatForLandMethod == obj.IsFlatForLandMethod : true) &&
                    (obj.CreditTypeId != -1 ? i.CreditTypeObjectId == obj.CreditTypeId : true) &&
                    (obj.DeedTypeId != -1 ? i.DeedTypeObjectId == obj.DeedTypeId : true) &&
                    (obj.IsExchangable.HasValue ? i.IsExchangable == obj.IsExchangable : true) &&
                    (obj._FuelTypeId ? obj.FuelTypeId.Contains(i.FuelTypeObjectId.Value) : true) &&
                    (obj.IsSublease.HasValue ? i.IsSublease == obj.IsSublease : true) &&
                    (obj.AdvertStatusId != -1 ? i.AdvertStatusObjectId == obj.AdvertStatusId : true) &&
                    (obj.AdvertUsingTypeId != -1 ? i.AdvertUsingTypeObjectId == obj.AdvertUsingTypeId : true) &&
                    (obj.StarCountId != -1 ? i.StarCountObjectId == obj.StarCountId : true) &&
                    (obj.BedCountFrom != -1 ? i.BedCount >= obj.BedCountFrom : true) &&
                    (obj.BedCountTo != -1 ? i.BedCount <= obj.BedCountTo : true) &&
                    (obj.RoomCountFrom != -1 ? i.RoomCount >= obj.RoomCountFrom : true) &&
                    (obj.RoomCountTo != -1 ? i.RoomCount <= obj.RoomCountTo : true) && i.Deleted == false && i.IsActive
                ).Distinct().OrderByDescending(i => i.UpdateDate).ThenByDescending(i => i.CreateDate).Skip((pageNo - 1) * pageItemCount).Take(pageItemCount).ToList();
        }

        public Advert GetAdvertByAdvertNumber(string advertNumber)
        {
            return Advert.FirstOrDefault(i => i.AdvertNumber == advertNumber && !i.Deleted && i.IsActive);
        }
    }
}
