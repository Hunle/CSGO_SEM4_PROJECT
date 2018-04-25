using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Balance
    {
        public int Id { get; set; }
        public double Amount { get; set;  } //Bugger hvis begge hedder "Balance" muligvis wallet istedet for .. 
        public Balance()
        {
            this.Amount = 0; 
        }
    }
}
