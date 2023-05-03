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
        public Responce Consultar()
        {
            Responce docenteResponce;
            try
            {
                if (docenteRepository.Consultar() != null)
                {
                    List<Docente> docente = docenteRepository.Consultar();
                    docenteResponce = new Responce(docente);
                    return docenteResponce;
                }
                else
                {
                    return docenteResponce = new Responce("No se encontraron elementos");
                }
            }
            catch (Exception e)
            {
                return docenteResponce = new Responce("Se produjo un error: " + e.Message);
            }
        }
        public string MostrarTotalLiquidacion()
        {
            double liquidacion = 0;
            if (Consultar().ListaVacia == true)
            {
                Console.WriteLine(Consultar().Mensaje);
            }
            else
            {
                List<Docente> liquidaciones = Consultar().docenteResponce;
                foreach (var item in liquidaciones)
                {
                    liquidacion += item.Sueldo;
                }
            }
            double liq = Math.Round(liquidacion, 2);
            return liq.ToString();
            
        }
        public string MostrarTotalDocentes()
        {
            int liquidacion = 0;
            if (Consultar().ListaVacia == true)
            {
                Console.WriteLine(Consultar().Mensaje);
            }
            else
            {
                List<Docente> liquidaciones = Consultar().docenteResponce;
                foreach (var item in liquidaciones)
                {
                    liquidacion += 1;
                }
            }
            return liquidacion.ToString();

        }
        public string CrearPDF()
        {
            try
            {
                docenteRepository.CrearDocumento();
                return "PDF Creado Satisfactoriamente";
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }
    }
}