using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class CreditType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public CreditType AddCreditType(string name, string key)
        {
            CreditType obj = new CreditType()
            {
                TypeName = name,
                TypeKey = key,
                Deleted = false
            };
            AddToCreditType(obj);
            SaveChanges();
            return obj;
        }

        public CreditType GetCreditTypeByObjectId(int id)
        {
            return CreditType.FirstOrDefault(i => i.ObjectId == id && i.Deleted == false);
        }

        public List<CreditType> GetCreditTypeList()
        {
            return CreditType.Where(i => i.Deleted == false).ToList();
        }
    }
}
