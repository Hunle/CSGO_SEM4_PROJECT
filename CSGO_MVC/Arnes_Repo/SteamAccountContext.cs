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
    }
}