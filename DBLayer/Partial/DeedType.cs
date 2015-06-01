using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class DeedType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public DeedType AddDeedType(string name, string key)
        {
            DeedType obj = new DeedType() 
            {
                TypeName = name,
                TypeKey = key,
                Deleted = false
            };
            AddToDeedType(obj);
            SaveChanges();
            return obj;
        }

        public DeedType GetDeedTypeByObjectId(int id)
        {
            return DeedType.FirstOrDefault(i => i.ObjectId == id && i.Deleted == false);
        }

        public List<DeedType> GetDeedTypeList()
        {
            return DeedType.Where(i => i.Deleted == false).ToList();
        }
    }
}
