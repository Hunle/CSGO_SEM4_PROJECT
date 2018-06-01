using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSGO_MVC.Models
{
    public class SteamAccountContext :DbContext
    {
        public SteamAccountContext() : base("DefaultConnection")
        {

        }

        public DbSet<SteamAccount> Accounts { get; set; }
        public System.Data.Entity.DbSet<CSGO_MVC.Models.Balance> Balances { get; set; }
        public DbSet<Field> Fields { get; set; }

        public DbSet<Skin> Skins { get; set; }
        public DbSet<Bet> Bets { get; set; }
        
    }
}