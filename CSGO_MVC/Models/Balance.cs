using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CSGO_MVC.Models
{
    public class Balance
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; } //Bugger hvis begge hedder "Balance" muligvis wallet istedet for .. 

        public Balance (int amount)
        {
            this.Amount = amount;
        }


    }
}