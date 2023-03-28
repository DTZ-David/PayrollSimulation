namespace Entity
{
    public class DocenteCatedratico : Docente
    {
        public int Horas { get; set; }
        public double ValorHora { get; set; }
        public double Salud { get; set; }
        public double Pension { get; set; }
        public double Cesantias { get; set; }
        public double ParafiscalSena { get; set; }
        public double ParafiscalIcbf { get; set; }
        public double Arl { get; set; }
        public double Transporte { get; set; }
        public double PrimaVacaciones { get; set; }
        public double PrimaServicios { get; set; }
        public double SalarioTotal { get; set; }
        public double Parafiscales { get; set; }
        public double Primas { get; set; }
        public double Suma { get; set; }
        public double Resta { get; set; }

        public DocenteCatedratico(int horas, double valorHora)
        {
            Horas = horas;
            ValorHora = valorHora;
            Sueldo = Horas * ValorHora;
            Salud = (Sueldo * 0.04);
            Pension = (Sueldo * 0.04);
            Cesantias = (Sueldo / 2) * 0.0833;
            Transporte = 140606;
            ParafiscalSena = (Sueldo * 0.02);
            ParafiscalIcbf = (Sueldo * 0.03);
            Parafiscales = (ParafiscalSena + ParafiscalIcbf);
            Arl = (Sueldo * 0.0348);
            PrimaServicios = (Sueldo * 0.0833);
            PrimaVacaciones = (Sueldo * 0.0417);
            Primas = PrimaServicios + PrimaVacaciones;
            Suma = (Sueldo + Transporte + Primas);
            Resta = (Salud + Pension + Cesantias + Parafiscales + Arl);
            SalarioTotal = Suma - Resta;
        }

        public DocenteCatedratico()
        {
        }
    }
}
