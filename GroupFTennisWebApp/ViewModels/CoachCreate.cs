using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupFTennisWebApp.Models;


namespace GroupFTennisWebApp.ViewModels
{
    public class CoachCreate
    {
        public Schedule Schedule { get; set; }
        public IEnumerable<Coach> Coach { get; set; }
    }
}
