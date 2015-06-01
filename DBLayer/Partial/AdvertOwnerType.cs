using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class AdvertOwnerType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public AdvertOwnerType AddAdvertOwnerType(string name, string key)
        {
            AdvertOwnerType obj = new AdvertOwnerType()
            {
                TypeName = name,
                TypeKey = key,
                Deleted = false
            };
            AddToAdvertOwnerType(obj);
            SaveChanges();
            return obj;
        }

        public AdvertOwnerType GetAdvertOwnerTypeByObjectId(int id)
        {
            return AdvertOwnerType.FirstOrDefault(i => i.ObjectId == id && i.Deleted == false);
        }

        public List<AdvertOwnerType> GetAdvertOwnerTypeList()
        {
            return AdvertOwnerType.Where(i => i.Deleted == false).ToList();
        }
    }
}
