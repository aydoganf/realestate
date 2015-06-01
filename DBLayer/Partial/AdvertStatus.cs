using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class AdvertStatus
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public AdvertStatus AddAdvertStatus(string name, string key)
        {
            AdvertStatus obj = new AdvertStatus()
            {
                TypeName = name,
                TypeKey = key,
                Deleted = false
            };
            AddToAdvertStatus(obj);
            SaveChanges();
            return obj;
        }

        public AdvertStatus GetAdvertStatusByObjectId(int id)
        {
            return AdvertStatus.FirstOrDefault(i => i.ObjectId == id && i.Deleted == false);
        }

        public List<AdvertStatus> GetAdvertStatusList()
        {
            return AdvertStatus.Where(i => i.Deleted == false).ToList();
        }
    }
}
