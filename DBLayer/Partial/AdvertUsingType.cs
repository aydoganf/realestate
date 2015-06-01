using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class AdvertUsingType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public AdvertUsingType AddAdvertUsingType(string name, string key)
        {
            AdvertUsingType obj = new AdvertUsingType()
            {
                TypeName = name,
                TypeKey = key,
                Deleted = false
            };
            AddToAdvertUsingType(obj);
            SaveChanges();
            return obj;
        }

        public AdvertUsingType GetAdvertUsingTypeByObjectId(int id)
        {
            return AdvertUsingType.FirstOrDefault(i => i.ObjectId == id && i.Deleted == false);
        }

        public List<AdvertUsingType> GetAdvertUsingTypeList()
        {
            return AdvertUsingType.Where(i => i.Deleted == false).ToList();
        }
    }
}
