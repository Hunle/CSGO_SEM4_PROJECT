using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skins
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string State { get; set; }
       // public int FloatValue { get; set; }  // Your condition on ze weeeapon


        public Skins(string skinname, int skinprice, string skinstatus)
        {
            this.Name = skinname;
            this.Price = skinprice;
            this.State = skinstatus;

        }

    }
}
