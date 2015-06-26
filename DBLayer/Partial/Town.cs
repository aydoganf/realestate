using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class Town
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public Town AddTown(string townName, int cityObectId)
        {
            Town obj = new Town()
            {
                TownName = townName,
                CityObjectId = cityObectId,
                Deleted = false
            };
            AddToTown(obj);
            return obj;
        }

        public List<Town> GetTownListByCityObjectId(int cityObjectId)
        {
            return Town.Where(i => i.CityObjectId == cityObjectId && i.Deleted == false).OrderBy(i => i.TownName).ToList();
        }

        public Town GetTownByObjectId(int objectId)
        {
            return Town.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
