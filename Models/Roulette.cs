using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Roulette
    {
        public int Fields { get; set; }
        public int RNGSeed { get; set; }
        public List<Fields> Fields { get; set; }            //Bugger pt men kan løses fremover, kunne også overveje en ny klasse "Fields" hvor man kan være mere præcis / specifik? 


        public Roulette()
        {

        }
    }
}
