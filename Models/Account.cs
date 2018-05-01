using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {
        
        public int Id { get; set; }
        public long SteamId { get; set; }
        public string UserName { get; set; }
        public bool UserStatus { get; set; }
        public string TradeLink { get; set; }

    }
}

