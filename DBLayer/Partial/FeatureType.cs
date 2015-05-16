using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class FeatureType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public FeatureType AddFeatureType(string typeName)
        {
            FeatureType obj = new FeatureType() 
            {
                TypeName = typeName,
                Deleted = false
            };
            AddToFeatureType(obj);
            return obj;
        }

        public List<FeatureType> GetFeatureTypeList()
        {
            return FeatureType.Where(i => i.Deleted == false).ToList();
        }

        public FeatureType GetFeatureTypeByObjectId(int objectId)
        {
            return FeatureType.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
