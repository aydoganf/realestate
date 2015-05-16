using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class AdvertFeatureRelation
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public AdvertFeatureRelation AddAdvertFeatureRelation(int advertObjectId, int featureObjectId)
        {
            AdvertFeatureRelation obj = new AdvertFeatureRelation()
            {
                AdvertObjectId = advertObjectId,
                FeatureObjectId = featureObjectId,
                Deleted = false
            };
            AddToAdvertFeatureRelation(obj);
            return obj;
        }

        public List<AdvertFeatureRelation> GetAdvertFeatureRelationListByFeatureObjectId(int featureObjectId)
        {
            return AdvertFeatureRelation.Where(i => i.FeatureObjectId == featureObjectId && i.Deleted == false).ToList();
        }

        public List<AdvertFeatureRelation> GetAdvertFeatureRelationListByAdvertObjectId(int advertObjectId)
        {
            return AdvertFeatureRelation.Where(i => i.AdvertObjectId == advertObjectId && i.Deleted == false).ToList();
        }
    }
}
