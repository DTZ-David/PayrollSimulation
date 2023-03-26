using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class Responce
    {
        public List<DocenteOcasional> docentesResponce { get; set; }
        public List<DocenteCatedratico> docentesCResponce { get; set; }
        public bool ListaVacia { get; set; }
        public string Mensaje { get; set; }
        public Responce(List<DocenteOcasional> docentesResponce)
        {
            this.docentesResponce = docentesResponce;
            this.ListaVacia = false;
            this.Mensaje = "Lectura Exitosa";
        }
        public Responce(string mensaje)
        {
            this.ListaVacia = true;
            this.Mensaje = mensaje;
        }

        public Responce(List<DocenteCatedratico> docentesCResponce)
        {
            this.docentesCResponce = docentesCResponce;
            this.ListaVacia = false;
            this.Mensaje = "Lectura Exitosa";
        }
    }
    
}
