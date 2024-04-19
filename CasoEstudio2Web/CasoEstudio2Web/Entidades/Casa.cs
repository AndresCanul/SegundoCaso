using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoEstudio2Web.Entidades
{
    public class Casa
    {
        public long IdCasa { get; set; }

        public string DescripcionCasa { get; set; }

        public decimal PrecioCasa { get; set; }

        public string UsuarioAlquiler { get; set; }

        public string Estado { get; set; }

        public string FechaAlquiler { get; set; }
    }

    public class ResultadoCasa
    {
        public int Codigo { get; set; }

        public string Detalle { get; set; }

        public List<Casa> Datos { get; set; }

        public Casa Dato { get; set; }
    }
}