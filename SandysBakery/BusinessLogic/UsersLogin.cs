using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class UsersLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int RegistrationId { get; set; }
        public DateTime LoginDate { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool isActive { get; set; }
    }
}