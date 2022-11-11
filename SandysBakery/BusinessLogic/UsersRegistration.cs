using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class UsersRegistration
    {
        public UsersRegistration()
        {
            UserLogin = new UsersLogin();
        }
        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime RegistrationDate { get; set; }
        public UsersLogin UserLogin { get; set; }
    }
}