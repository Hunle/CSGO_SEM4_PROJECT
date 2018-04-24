using System;
using System.Data.Entity;
using Models;
using DB;


namespace MVC.Models
{
    public class AccountModels
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    public class DataAccess : DbContext
    {
        DbSet<AccountModels> Accounts { get; set; }
    }   
}

    