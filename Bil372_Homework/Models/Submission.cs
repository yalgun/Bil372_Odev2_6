using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Models
{
    public class Submission
    {
        [Key]
        [Column(Order = 0)]
        public int AuthenticationID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ConfID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SubmissionID { get; set; }
        public int prevSubmissionID { get; set; }
    }

    public class SubmissionViewModel
    {
        public List<Submission> Submissions { get; set; }
        public SubmissionViewModel()
        {
            Submissions = new List<Submission>();
        }
    }
}