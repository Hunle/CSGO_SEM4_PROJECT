using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Roulette
    {
        private int Fields { get; set; }
        private int RNGSeed { get; set; }
        private List<Field> Fieldlist { get; set; }        //Bugger pt men kan løses fremover, kunne også overveje en ny klasse "Fields" hvor man kan være mere præcis / specifik? 


        public Roulette()
        {

        }
    }
}
