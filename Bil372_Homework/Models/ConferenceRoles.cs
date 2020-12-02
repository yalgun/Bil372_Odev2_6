using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Models
{
    public class ConferenceRoles
    {
        public int ConferenceRole { get; set; }
        [Key]
        [Column(Order = 0)]
        public int AuthenticationID { get; set; }
        [Key]
        [Column(Order = 1)]
        public string ConfID { get; set; }
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