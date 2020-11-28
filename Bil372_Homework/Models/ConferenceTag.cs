using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Models
{
    public class ConferenceTag
    {
        [Key]
        [Column(Order = 0)]
        public String ConfID;
        [ForeignKey("ConfID")]
        public virtual Conference Conferece { get; set; }

        [Key, StringLength(5)]
        public String Tag;
    }

    public class ConferenceTagViewModel
    { 
        public List<ConferenceTag> conferenceTags { get; set; }
        public ConferenceTagViewModel()
        {
            conferenceTags = new List<ConferenceTag>();
        }
    }

}