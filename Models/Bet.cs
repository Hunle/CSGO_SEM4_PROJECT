using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bet
    {
        private double BetValue { get; set; }
        private DateTime Date { get; set; }
        private double Min { get; set;  }
        private double Max { get; set; }
        private bool Status { get; set; }



        public Bet()
        {

        }
    }
}
