using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Models
{
    public class UserLog
    {
        [Key]
        public int AuthenticationID { get; set; }
        [ForeignKey("AuthenticationID")]
        public virtual User User { get; set; }

        public String Title { get; set; }
        public String Name { get; set; }
        public String Affilation { get; set; }
        public String primaryEmail { get; set; }
        public String secondaryEmail { get; set; }
        public String password { get; set; }
        public String Phone { get; set; }
        public String fax { get; set; }
        public String URL { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String Record { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class UserLogViewModel
    {
        public List<UserLog> UserLogs{ get; set; }
        public UserLogViewModel()
        {
            UserLogs= new List<UserLog>();
        }
    }
}