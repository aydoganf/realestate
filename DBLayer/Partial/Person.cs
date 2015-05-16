using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public partial class Person
    {
        public void Delete()
        {
            this.Deleted = true;
        }

        public string FullName 
        { 
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }

    public partial class RealEstateEntities
    {
        public Person AddPerson(string firstName, string lastName, string email, string password, string phone, string address, bool isActive, int accountTypeObjectId)
        {
            Person obj = new Person() 
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Phone = phone,
                Address = address,
                IsActive = isActive,
                AccountTypeObjectId = accountTypeObjectId,
                Deleted = false
            };
            AddToPerson(obj);
            return obj;
        }

        public List<Person> GetPersonList()
        {
            return Person.Where(i => i.Deleted == false).OrderBy(i => i.FirstName).ToList();
        }

        public Person GetPersonByObjectId(int objectId)
        {
            return Person.FirstOrDefault(i => i.ObjectId == objectId && i.Deleted == false);
        }

        public Person GetPersonByEmailAndPassword(string email, string password)
        {
            return Person.FirstOrDefault(i => i.Email == email && i.Password == password && i.IsActive && i.Deleted == false);
        }

        public Person GetPersonByEmailAndPassword(string email, string password, int accountTypeObjectId)
        {
            return Person.FirstOrDefault(i => i.Email == email && i.Password == password && i.IsActive && i.Deleted == false && i.AccountTypeObjectId == accountTypeObjectId);
        }

        public Person GetPersonByEmailAddress(string email)
        {
            return Person.FirstOrDefault(i => i.Email == email && i.Deleted == false);
        }

        public int GetPersonCount()
        {
            return Person.Where(i => i.Deleted == false).Count();
        }
    }
}
