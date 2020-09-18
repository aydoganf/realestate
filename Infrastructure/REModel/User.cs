using System;
using System.Collections.Generic;
using System.Text;

namespace REModel
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string AccountType { get; set; }
        public bool Deleted { get; set; }
    }
}
