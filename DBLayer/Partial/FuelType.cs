using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class FuelType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public FuelType AddFuelType(string name, string key)
        {
            FuelType obj = new FuelType() 
            {
                TypeName = name,
                TypeKey = key,
                Deleted = false
            };
            AddToFuelType(obj);
            SaveChanges();
            return obj;
        }

        public FuelType GetFuelTypeByObjectId(int id)
        {
            return FuelType.FirstOrDefault(i => i.ObjectId == id && i.Deleted == false);
        }

        public List<FuelType> GetFuelTypeList()
        {
            return FuelType.Where(i => i.Deleted == false).ToList();
        }
    }
}
