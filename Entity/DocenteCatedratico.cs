using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DocenteCatedratico : Docente
    {
        public int Horas { get; set; }
        public double ValorHora { get; set; }
        public double Salud { get; set; }
        public double Pension { get; set; }
        public double Cesantias { get; set; }
       
        public DocenteCatedratico(int horas, double valorHora)
        {
            Horas = horas;
            ValorHora = valorHora;
            Sueldo = Horas * ValorHora;
            Salud = Sueldo * 0.125;
            Pension = Sueldo * 0.16;
            Cesantias = (Sueldo * (horas / 3)) / 360;
        }

    }
}
