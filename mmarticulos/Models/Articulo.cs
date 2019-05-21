using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mmarticulos.Models
{
    public class Articulo
    {
  
        public Articulo()
        {
        }

        public Articulo(int codigo, string descripcion, float precio)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
        }

        //private int numero;
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    //    public int Numero { get; set; }
    }
}