using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class AccountType
    {
        public void Delete()
        {
            this.Deleted = true;
        }
    }

    public partial class RealEstateEntities
    {
        public AccountType AddAccountType(string accountTypeName, string accountTypeNameTR)
        {
            AccountType obj = new AccountType() 
            {
                AccountTypeName = accountTypeName,
                AccountTypeNameTR = accountTypeNameTR,
                Deleted = false
            };
            AddToAccountType(obj);
            return obj;
        }

        public List<AccountType> GetAccountTypeList()
        {
            return AccountType.Where(i => i.Deleted == false).OrderBy(i => i.AccountTypeName).ToList();
        }

        public AccountType GetAccountTypeByObjectId(int objectId)
        {
            return AccountType.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }
    }
}
