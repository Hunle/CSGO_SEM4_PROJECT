using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {
        public int Id { get; set; }
        public int SteamId { get; set; }
        public string Name { get; set; }
        public Boolean Status { get; set; }
        public string TradeLink { get; set; }

        public Account()
        {

        }
    }
}
