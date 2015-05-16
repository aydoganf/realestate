using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class Currency
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public Currency AddCurrency(string currencyName)
        {
            Currency obj = new Currency() 
            {
                CurrencyName = currencyName,
                Deleted = false
            };
            AddToCurrency(obj);
            return obj;
        }

        public List<Currency> GetCurrencyList()
        {
            return Currency.Where(i => i.Deleted == false).ToList();
        }

        public Currency GetCurrencyByObjectId(int objectId)
        {
            return Currency.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
