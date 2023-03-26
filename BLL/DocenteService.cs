using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class DocenteService
    {
        private readonly DocenteRepository docenteRepository;
        public DocenteService()
        {
            docenteRepository = new DocenteRepository();
        }
        public string GuardarOcasionales(DocenteOcasional docenteOcasional)
        {
            try
            {
                    docenteRepository.GuardarDocentesOcasionales(docenteOcasional);
                    return "Datos Guardados Satisfactoriamente";
                
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }
        public string GuardarCatedraticos(DocenteCatedratico docenteC)
        {
            try
            {
                docenteRepository.GuardarDocentesCatedraticos(docenteC);
                return "Datos Guardados Satisfactoriamente";

            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }
    }
}