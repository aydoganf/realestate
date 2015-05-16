using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class AdvertType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public AdvertType AddAdvertType(string typeName)
        {
            AdvertType obj = new AdvertType() 
            {
                TypeName = typeName,
                Deleted = false
            };
            AddToAdvertType(obj);
            return obj;
        }

        public List<AdvertType> GetAdvertTypeList()
        {
            return AdvertType.Where(i => i.Deleted == false).OrderBy(i=> i.TypeName).ToList();
        }
    }
}
