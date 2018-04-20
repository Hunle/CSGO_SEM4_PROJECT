using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {
        private int Id { get; set; }
        private int SteamId { get; set; }
        private string Name { get; set; }
        private bool Status { get; set; }
        private string TradeLink { get; set; }

        public Account(int id, int steamid, string name, bool status, string tradelink)
        {
            this.Id = id;
            this.SteamId = steamid;
            this.Name = name;
            this.Status = status;
            this.TradeLink = tradelink;

        }
    }
}
