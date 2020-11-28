using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Models
{
    public class ConferenceRoles
    {
        public int ConferenceRole { get; set; }
        [Key]
        public int AuthenticationID { get; set; }
    }

    public class ConferenceRolesViewModel
    {
        public List<ConferenceRoles> ConferenceRoles{ get; set; }
        public ConferenceRolesViewModel()
        {
            ConferenceRoles = new List<ConferenceRoles>();
        }
    }


}