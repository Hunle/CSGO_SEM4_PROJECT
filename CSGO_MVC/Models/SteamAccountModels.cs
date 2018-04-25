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

        public SteamAccountModels(int id, int steamid, string name, bool status, string tradelink)
        {
            this.Id = id;
            this.SteamId = steamid;
            this.Name = name;
            this.Status = status;
            this.TradeLink = tradelink;

        }



    }
}