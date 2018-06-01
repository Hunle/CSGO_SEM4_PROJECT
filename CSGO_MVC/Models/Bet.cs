using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CSGO_MVC.Models
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public SteamAccount Betmaker { get; set; }
        public Field Betfield { get; set; }
        public double BetValue { get; set; }
        public DateTime Date { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public bool Status { get; set; }



        public Bet(double Betvalue)
        {
            BetValue = 100.00;

        }
        public Bet()
        {

        }
   
    }
}