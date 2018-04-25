﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Field
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public int Number { get; set; }

        public Field(string colores, int numero)
        {
            this.Color = colores;
            this.Number = numero;
        }

 
    }
}
