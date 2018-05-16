using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSGO_MVC.Models
{
    public class SteamAccount
    {
        [Key]
        public int Id { get; set; }
        public long SteamId { get; set; }
        public Balance accountbalance { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UserStatus { get; set; }
        public string TradeLink { get; set; }

    }
}