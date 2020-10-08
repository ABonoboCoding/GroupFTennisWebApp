using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupFTennisWebApp.Models
{
    public class Coach
    {
        [Column("ID")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Biography { get; set; }
        [Column("PhotoURL")]
        //A image url instead of an image upload
        public string PhotoUrl { get; set; }
    }
}
