using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Models
{
    public class User
    {
        [Key]
        public int AuthenticationID { get; set; }
        [StringLength(20)]
        public String UserName { get; set; }
        [StringLength(50)]
        public String Password { get; set; }
    }

    public class UserViewModel
    {
        public List<User> Users{ get; set; }
        public UserViewModel()
        {
            Users = new List<User>();
        }
    }
}