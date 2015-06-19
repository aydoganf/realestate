using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class EstateType
    {
        public void Delete()
        {
            this.Deleted = true;
        }

        public const int Konut = 2;
        public const int Isyeri = 3;
        public const int Arsa = 4;
        public const int Devremulk = 5;
        public const int Turistik = 6;
    }

    public partial class RealEstateEntities
    {
        public EstateType AddEstateType(string typeName, string typeKey, int? parentEstateTypeObjectId)
        {
            EstateType obj = new EstateType()
            {
                TypeName = typeName,
                TypeKey = typeKey,
                ParentEstateTypeObjectId = parentEstateTypeObjectId,
                Deleted = false
            };
            AddToEstateType(obj);
            return obj;
        }
        
        public List<EstateType> GetEstateTypeList()
        {
            return EstateType.Where(i => i.Deleted == false).OrderBy(i => i.TypeName).ToList();
        }

        public EstateType GetEstateTypeByObjectId(int objectId)
        {
            return EstateType.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }

        public List<EstateType> GetEstateTypeListByParentId(int parentId)
        {
            return EstateType.Where(i => i.ParentEstateTypeObjectId == parentId && i.Deleted == false).ToList();
        }

        public List<EstateType> GetBaseEstateTypeList()
        {
            return EstateType.Where(i => i.ParentEstateTypeObjectId == null && i.Deleted == false).ToList();
        }

        public EstateType GetEstateTypeByKey(string key)
        {
            return EstateType.FirstOrDefault(i => i.TypeKey.ToLower() == key.ToLower() && i.Deleted == false);
        }
    }
}
