using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class District
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public District AddDistrict(string districtName, int townObjectId)
        {
            District obj = new District() 
            { 
                DistrictName = districtName,
                TownObjectId = townObjectId,
                Deleted = false
            };
            AddToDistrict(obj);
            return obj;
        }

        public List<District> GetDistrictListByTownObjectId(int townObjectId)
        {
            return District.Where(i => i.TownObjectId == townObjectId && i.Deleted == false).ToList();
        }

        public District GetDistrictByObjectId(int objectId)
        {
            return District.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
