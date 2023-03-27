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
        public double Parafiscales { get; set; }
        public double Arl { get; set; }
        public double Transporte { get; set; }
        public double SalarioPrestaciones { get; set; }
        public double SalarioCesantias { get; set; }
        public double Intereses { get; set; }
        public double SalarioPrima { get; set; }
        public double Vacaciones { get; set; }
        public double SalarioTotal { get; set; }
        public double SalarioNeto { get; set; }
        public DocenteCatedratico(int horas, double valorHora)
        {
            Horas = horas;
            ValorHora = valorHora;
            Sueldo = Horas * ValorHora;
            Salud = Sueldo * 0.085;
            Pension = Sueldo * 0.16;
            Parafiscales = (Sueldo * 0.02);
            Arl = Sueldo * 0.0522;
            Transporte = 106454;
            SalarioPrestaciones=(Sueldo-Salud-Pension);
            SalarioCesantias = (Sueldo + Transporte);
            Cesantias = (SalarioCesantias * 0.0833);
            Intereses = (SalarioCesantias * 0.01);
            SalarioPrima = (SalarioCesantias * 0.0833);
            Vacaciones = (SalarioCesantias * 0.0417);
            SalarioTotal=(Sueldo+Transporte);
            SalarioNeto=(SalarioTotal - Salud - Pension - Parafiscales - Arl - Cesantias - Intereses + SalarioPrima + Vacaciones);
        }

    }
}
