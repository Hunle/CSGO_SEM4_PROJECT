using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Field
    {
        private int Id { get; set; }

        private string Color { get; set; }

        private int Number { get; set; }

        public Field(string colores, int numero)
        {
            this.Color = colores;
            this.Number = numero;
        }

 
    }
}
