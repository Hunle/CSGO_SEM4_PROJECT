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
        public long SteamId { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public bool UserStatus { get; set; }
        public string TradeLink { get; set; }

        public Account()
        {

        }
        public Account(int id, long steamid, string name, bool status, string tradelink)
        {
            this.Id = id;
            this.SteamId = steamid;
            this.Username = name;
            this.UserStatus = status;
            this.Avatar = Avatar; 
            this.TradeLink = tradelink;

        }
    }
}
