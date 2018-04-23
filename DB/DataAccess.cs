using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;


namespace DB
{
    public class DataAccess : DbContext
    {
        public DataAccess() : base("Defaultconnection") { }

        public DbSet<Account> Accounts { get;  set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Skins> Skin { get; set; }
        

    }
}
