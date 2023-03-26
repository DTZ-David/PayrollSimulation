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
        public DocenteCatedratico(int horas, double valorHora)
        {
            Horas = horas;
            ValorHora = valorHora;
            Salario = Horas * ValorHora;
        }

    }
}
