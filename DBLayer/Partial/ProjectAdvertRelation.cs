using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class ProjectAdvertRelation
    {
        public void Delete()
        {
            Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public ProjectAdvertRelation AddProjectAdvertRelation(int projectObjectId, int advertObjectId, string housingTypeName)
        {
            ProjectAdvertRelation obj = new ProjectAdvertRelation()
            {
                AdvertObjectId = advertObjectId,
                ProjectObjectId = projectObjectId,
                HousingTypeName = housingTypeName,
                Deleted = false
            };
            AddToProjectAdvertRelation(obj);
            SaveChanges();
            return obj;
        }

        public ProjectAdvertRelation GetProjectAdvertRelationByObjectId(int objectId)
        {
            return ProjectAdvertRelation.FirstOrDefault(i => i.ObjectId == objectId && !i.Deleted);
        }
    }
}
