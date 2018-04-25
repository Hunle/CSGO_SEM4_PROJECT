using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSGO_MVC.Models
{
    public class SteamAccountModels
    {
        public int Id { get; set; }
        public int SteamId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string TradeLink { get; set; }



        

    }
}