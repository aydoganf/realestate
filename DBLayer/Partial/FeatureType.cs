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
        public FeatureType AddFeatureType(string typeName, int? estateTypeId, bool isProjectType)
        {
            FeatureType obj = new FeatureType() 
            {
                TypeName = typeName,
                EstateTypeObjectId = estateTypeId,
                IsProjectType = isProjectType,
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

        public List<FeatureType> GetFeatureTypeListByEstateTypeObjectId(int estateTypeId)
        {
            return FeatureType.Where(i => i.EstateTypeObjectId == estateTypeId && i.Deleted == false && i.IsProjectType == null).ToList();
        }

        public List<FeatureType> GetFeatureTypeListByProjectType()
        {
            return FeatureType.Where(i => i.IsProjectType == true && !i.Deleted && i.EstateTypeObjectId == null).ToList();
        }
    }
}
