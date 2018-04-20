using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Basket
    {
        private int Id { get; set; }

        private List<Skins> Skinlist { get; set; }


        public Basket (int id)
        {
            this.Id = id;
        }

    }
}
