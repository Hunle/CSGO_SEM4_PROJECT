using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace CSGO_MVC.Models
{
    public class Skin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string State { get; set; }
        // public int FloatValue { get; set; }  // Your condition on ze weeeapon


        public Skin(string skinname, int skinprice, string skinstatus)
        {
            this.Name = skinname;
            this.Price = skinprice;
            this.State = skinstatus;

        }

    }
}