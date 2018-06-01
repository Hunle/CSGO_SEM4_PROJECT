using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSGO_MVC.Models
{
    public class Roulette
    {
        [Key]
        private int Id { get; set; }
        private int RNGSeed { get; set; }
        private List<Field> Fieldlist = new List<Field>();  


        public Roulette()
        {
            
            RNGSeed = 0;
        }
    }
}