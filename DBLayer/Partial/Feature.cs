using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class Feature
    {
        public void Delete()
        {
            this.Deleted = true;
        }

        public enum TypeOf
        {
            Ic = 1,
            Dis = 2,
            Konum = 3
        }
    }

    public partial class RealEstateEntities
    {
        public Feature AddFeature(string featureName, string featureKey, int featureTypeObjectId)
        {
            Feature obj = new Feature() 
            {
                FeatureName = featureName,
                FeatureKey = featureKey,
                FeatureTypeObjectId = featureTypeObjectId,
                Deleted = false
            };
            AddToFeature(obj);
            return obj;
        }

        public List<Feature> GetFeatureList()
        {
            return Feature.Where(i => i.Deleted == false).OrderBy(i => i.FeatureName).ToList();
        }

        public Feature GetFeatureByObjectId(int objectId)
        {
            return Feature.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }

        public List<Feature> GetFeatureListByFeatureTypeObjectId(int featureTypeId)
        {
            return Feature.Where(i => i.FeatureTypeObjectId == featureTypeId && i.Deleted == false).ToList();
        }
    }
}
