using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class ProjectFeatureRelation
    {
        public void Delete()
        {
            Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public ProjectFeatureRelation AddProjectFeatureRelation(int projectObjectId, int featureObjectId)
        {
            ProjectFeatureRelation obj = new ProjectFeatureRelation()
            {
                ProjectObjectId = projectObjectId,
                FeatureObjectId = featureObjectId,
                Deleted = false
            };
            AddToProjectFeatureRelation(obj);
            SaveChanges();
            return obj;
        }

        public List<ProjectFeatureRelation> GetProjectFeatureRelationListByProjectObjectId(int projectObjectId)
        {
            return ProjectFeatureRelation.Where(i => i.ProjectObjectId == projectObjectId && !i.Deleted).ToList();
        }
        
    }

}
