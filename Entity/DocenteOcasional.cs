using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DocenteOcasional : Docente
    {
        public string Categoria { get; set; }

        public DocenteOcasional(string Categoria)
        {
            this.Categoria = Categoria;
            switch(Categoria)
            {
                case "Auxiliar Tiempo Completo":
                    Salario = 1160000 * 2.645;
                    break;
                case "Auxiliar Medio Tiempo":
                    Salario = 1160000 * 1.509;
                    break;
                case "Asistente Tiempo Completo":
                    Salario = 1160000 * 3.125;
                    break;
                case "Asistente Medio Tiempo":
                    Salario = 1160000 * 1.749;
                    break;
                case "Asociado Tiempo Completo":
                    Salario = 1160000 * 3.606;
                    break;
                case "Asocioado Medio Tiempo":
                    Salario = 1160000 * 1.990;
                    break;
                case "Titular Tiempo Completo":
                    Salario = 1160000 * 3.918;
                    break;
                case "Titular Medio Tiempo":
                    Salario = 1160000 * 2.146;
                    break;                
            }
        }

    }
}
