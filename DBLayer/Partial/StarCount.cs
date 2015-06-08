using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class StarCount
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public StarCount AddStarCount(string name, string key)
        {
            StarCount obj = new StarCount()
            {
                TypeName = name,
                TypeKey = key,
                Deleted = false
            };
            AddToStarCount(obj);
            SaveChanges();
            return obj;
        }

        public StarCount GetStarCountByObjectId(int id)
        {
            return StarCount.FirstOrDefault(i => i.ObjectId == id && i.Deleted == false);
        }

        public List<StarCount> GetStarCountList()
        {
            return StarCount.Where(i => i.Deleted == false).ToList();
        }
    }
}
