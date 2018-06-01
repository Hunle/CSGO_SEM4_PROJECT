using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSGO_MVC.Models; 

namespace CSGO_MVC.Models
{
    public class _ViewModel
    {
        public Bet Bets { get; set; }
        public SteamAccount Accounts { get; set; }
     //   public Balance Balance { get; set; }
        public Balance Balance { get; set; }
        public List<Field> Fieldlist = new List<Field>();
        public bool ready;
    }
 
}