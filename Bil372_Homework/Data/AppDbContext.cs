using Bil372_Homework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bil372_Homework.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<UserInfo> UserInfos { get; set; }
        public IDbSet<UserLog> UserLogs { get; set; }
        public IDbSet<Submission> Submissions { get; set; }
        public IDbSet<Conference> Conferences { get; set; }
        public IDbSet<ConferenceRoles> ConferenceRoles { get; set; }

    }
}