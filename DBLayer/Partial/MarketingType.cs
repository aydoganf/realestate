﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class MarketingType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public MarketingType AddMarketingType(string typeName, string typeKey)
        {
            MarketingType obj = new MarketingType() 
            {
                TypeName = typeName,
                TypeKey = typeKey,
                Deleted = false
            };
            AddToMarketingType(obj);
            SaveChanges();
            return obj;
        }

        public List<MarketingType> GetMarketingTypeList()
        {
            return MarketingType.Where(i => i.Deleted == false).ToList();
        }

        public MarketingType GetMarketingTypeByObjectId(int objectId)
        {
            return MarketingType.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }

        public MarketingType GetMarketingTypeByKey(string key)
        {
            return MarketingType.FirstOrDefault(i => i.TypeKey == key && i.Deleted == false);
        }
    }
}
