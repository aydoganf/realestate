using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class City
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public City AddCity(string cityName, int sortOrder)
        {
            City obj = new City() 
            {
                CityName = cityName,
                SortOrder = sortOrder,
                Deleted = false
            };
            AddToCity(obj);
            return obj;
        }

        public List<City> GetCityList()
        {
            return City.Where(i => i.Deleted == false).OrderBy(i => i.SortOrder).ThenBy(i => i.CityName).ToList();
        }

        public City GetCityByObjectId(int objectId)
        {
            return City.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
