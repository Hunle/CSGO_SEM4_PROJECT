using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bet
    {
        public int Id { get; set; }
        public double BetValue { get; set; }
        public DateTime Date { get; set; }
        public double Min { get; set;  }
        public double Max { get; set; }
        public bool Status { get; set; }



        public Bet()
        {

        }
    }
}
