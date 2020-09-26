using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using GroupFTennisWebApp.Models;
using GroupFTennisWebApp.Data;

namespace GroupFTennisWebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the GroupFTennisWebAppUser class
    public class GroupFTennisWebAppUser : IdentityUser
    {
        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        [PersonalData]
        public string Bio { get; set; }

        [PersonalData]
        public bool IsCoach { get; set; }

        [PersonalData]
        public bool IsMember { get; set; }

        [PersonalData]
        public bool IsAdmin { get; set; }
    }
}
