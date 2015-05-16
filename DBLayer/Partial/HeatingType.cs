using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class HeatingType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public HeatingType AddHeatingType(string typeName, string typeKey)
        {
            HeatingType obj = new HeatingType()
            {
                 TypeName = typeName,
                 TypeKey = typeKey,
                 Deleted = false
            };
            AddToHeatingType(obj);
            return obj;
        }

        public List<HeatingType> GetHeatingTypeList()
        {
            return HeatingType.Where(i => i.Deleted == false).OrderBy(i => i.TypeName).ToList(); 
        }

        public HeatingType GetHeatingTypeByObjectId(int objectId)
        {
            return HeatingType.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
