using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Models
{
    public class Conference
    {
        [Key,StringLength(20)]
        public String ConfID { get; set; }
        public DateTime CreationDateTime { get; set; }
        [StringLength(100)]
        public String Name { get; set; }
        [StringLength(19)]
        public String ShortName { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SubmisionDeadline { get; set; }
        public int? CreatorUser { get;set;}
        [ForeignKey("CreatorUser")]
        public virtual User User { get; set; }
        [StringLength(19)]
        public String WebSite { get; set; }

    }

    public class ConferenceViewModel
    {
        public List<Conference> Conferences{ get; set; }
        public ConferenceViewModel()
        {
            Conferences = new List<Conference>();
        }
    }

}