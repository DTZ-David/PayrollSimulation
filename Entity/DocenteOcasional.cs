namespace Entity
{
    public class DocenteOcasional : Docente
    {
        public string Categoria { get; set; }
        public string Postgrado { get; set; }
        public string gruposSemillero { get; set; }
        public double Salario { get; set; }
        public DocenteOcasional(string Categoria, string postgrado, string semillero)
        {

            this.Categoria = Categoria;
            Postgrado = postgrado;
            gruposSemillero = semillero;
            DefinirSueldo(Categoria);
            double aux = CalcularBonificaciones(Sueldo);
            double aux1 = CalcularGrupoSemillero(Sueldo);
            Salario = aux1 + aux + Sueldo;
        }

        public DocenteOcasional()
        {
        }

        private double CalcularGrupoSemillero(double sueldo)
        {
            double aux= 0 ;
            switch (gruposSemillero)
            {
                case "A1":
                    aux = sueldo * 0.56;
                    break;
                case "A":
                    aux = sueldo * 0.47;
                    break;
                case "B":
                    aux = sueldo * 0.42;
                    break;
                case "C":
                    aux = sueldo * 0.38;
                    break;
                case "Reconocidos por Colciencias":
                    aux = sueldo * 0.33;
                    break;
                case "Semillero":
                    aux = sueldo * 0.19;
                    break;
                default: aux = 0; 
                    break;
            }
            return aux;
        }
        private double CalcularBonificaciones(double sueldo)
        {
            double aux1 = 0;
            switch (Postgrado)
            {
                case "Especializacion":
                    aux1 = sueldo * 0.10;
                    break;
                case "Maestria":
                    aux1 = sueldo * 0.45;
                    break;
                case "Doctorado":
                    aux1 = sueldo * 0.90;
                    break;
                case "PostDoctorado":
                    aux1 = 0;
                    break;
               default: aux1 = 0; 
                    break;
            }
            return aux1;
        }
        private void DefinirSueldo(string Categoria)
        {
            switch (Categoria)
            {
                case "Auxiliar Tiempo Completo":
                    Sueldo = 1160000 * 2.645;
                    break;
                case "Auxiliar Medio Tiempo":
                    Sueldo = 1160000 * 1.509;
                    break;
                case "Asistente Tiempo Completo":
                    Sueldo = 1160000 * 3.125;
                    break;
                case "Asistente Medio Tiempo":
                    Sueldo = 1160000 * 1.749;
                    break;
                case "Asociado Tiempo Completo":
                    Sueldo = 1160000 * 3.606;
                    break;
                case "Asocioado Medio Tiempo":
                    Sueldo = 1160000 * 1.990;
                    break;
                case "Titular Tiempo Completo":
                    Sueldo = 1160000 * 3.918;
                    break;
                case "Titular Medio Tiempo":
                    Sueldo = 1160000 * 2.146;
                    break;
            }
        }
    }
}
