using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SB_Admin.Entities
{
    public class GraficaOBJ
    {

        public int idEstadoTrabajo { get; set; }

        public string name { get; set; }

        public double y { get; set; }

        public bool sliced { get; set; }

        public bool selected { get; set; }

        public string Marca { get; set; }




        public GraficaOBJ()
        {

        }

        public GraficaOBJ(string name, double y, bool sliced = false, bool selected = false)
        {
            this.name = name;
            this.y = y;
            this.sliced = sliced;
            this.selected = selected;


        }


    }
}