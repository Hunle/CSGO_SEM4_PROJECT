using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CSGO_MVC.Models
{
    public class Field
    {
        [Key]
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