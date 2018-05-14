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
        private List<Field> Fieldlist { get; set; }        //Bugger pt men kan løses fremover, kunne også overveje en ny klasse "Fields" hvor man kan være mere præcis / specifik? 


        public Roulette()
        {
            Fieldlist = new List<Field>();
            RNGSeed = 0;
        }
    }
}