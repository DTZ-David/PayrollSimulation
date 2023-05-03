using Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DAL
{
    public class DocenteRepository
    {
        string rutaO = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesO.txt";
        string rutaC = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesC.txt";
        string rutaPDFO = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesO.pdf";
        string rutaPDFC= "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesC.pdf";
        string rutaTxt = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\Docentes.txt";
        string rutaPDF = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\Docentes.pdf";
        public void GuardarDocentesOcasionales(DocenteOcasional docenteOcasional)
        {
            FileStream file = new FileStream(rutaO, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(docenteOcasional.Categoria + ";" +
                docenteOcasional.Postgrado + ";" +
                docenteOcasional.gruposSemillero + ";" +
                docenteOcasional.Salario);
            writer.Close();
            file.Close();
        }
        public void GuardarDocentesCatedraticos(DocenteCatedratico docenteC)
        {
            FileStream file = new FileStream(rutaC, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(docenteC.Horas + ";" +
                docenteC.ValorHora + ";" +
                docenteC.Sueldo + ";" +
                docenteC.Salud + ";" +
                docenteC.Pension + ";" +
                docenteC.Cesantias + ";" +
                docenteC.SalarioTotal);
            writer.Close();
            file.Close();
        }
     
        public void CrearDocumento()
        {
            CrearDocDocentesOcasionales();
            CrearDocDocentesCatedraticos();
            UnirTxt();
            CrearDocumentoPDF();

        }
        
        private void UnirTxt()
        {
            

            string[] lineasArchivo1 = File.ReadAllLines(rutaC);
            string[] lineasArchivo2 = File.ReadAllLines(rutaO);

            using (StreamWriter sw = new StreamWriter(rutaTxt))
            {
                for (int i = 0; i < lineasArchivo1.Length; i++)
                {
                    string[] camposArchivo1 = lineasArchivo1[i].Split(';');
                    string[] camposArchivo2 = lineasArchivo2[i].Split(';');

                    camposArchivo1[0] = "Docente Catedratico";
                    camposArchivo2[0] = "Docente Ocasional";
                    
                    string primerCampo1 = camposArchivo1[0];
                    string ultimoCampo1 = camposArchivo1[camposArchivo1.Length - 1];

                    string primerCampo2 = camposArchivo2[0];
                    string ultimoCampo2 = camposArchivo2[camposArchivo2.Length - 1];
                    sw.WriteLine(primerCampo1 + ";" + ultimoCampo1);
                    sw.WriteLine(primerCampo2 + ";" + ultimoCampo2);
                }
            }
        }
        private void CrearDocDocentesCatedraticos()
        {
            string aux = CalcularNominaCatedraticos();
            Document pdfDocument = new Document(PageSize.LETTER);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(rutaPDFC, FileMode.Append));
            pdfDocument.Open();
            try
            {

                PdfPTable tabla = new PdfPTable(7);
                tabla.WidthPercentage = 100;
                string[] lineas = File.ReadAllLines(rutaC);
                Paragraph titulo = new Paragraph("NOMINA DOCENTES CATEDRATICOS", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK));
                titulo.SpacingBefore = 20f;
                titulo.SpacingAfter = 20f;
                titulo.Alignment = Element.ALIGN_CENTER;
                pdfDocument.Add(titulo);

                PdfPCell celdaHoras = new PdfPCell(new Phrase("Horas"));
                PdfPCell celdaValorHora = new PdfPCell(new Phrase("ValorHora"));
                PdfPCell celdaSueldo = new PdfPCell(new Phrase("Sueldo"));
                PdfPCell celdaSalud = new PdfPCell(new Phrase("Salud"));
                PdfPCell celdaPension = new PdfPCell(new Phrase("Pension"));
                PdfPCell celdaCesantias = new PdfPCell(new Phrase("Cesantias"));
                PdfPCell celdaSalario = new PdfPCell(new Phrase("SalarioFinal"));

                tabla.AddCell(celdaHoras);
                tabla.AddCell(celdaValorHora);
                tabla.AddCell(celdaSueldo);
                tabla.AddCell(celdaSalud);
                tabla.AddCell(celdaPension);
                tabla.AddCell(celdaCesantias);
                tabla.AddCell(celdaSalario);


                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    for (int i = 0; i < datos.Length; i++)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(datos[i]));
                        tabla.AddCell(celda);
                    }
                }
               

                pdfDocument.Add(tabla);
                pdfDocument.Add(Chunk.NEWLINE);
                Paragraph p = new Paragraph();
                p.Alignment = Element.ALIGN_CENTER;
                p.Add("Universidad Popular del Cesar");
                p.Add(Chunk.NEWLINE);
                p.Add("La liquidacion de la nomina es de: " + aux);
                pdfDocument.Add(p);
            }
            finally
            {
                pdfDocument.Close();
                pdfWriter.Close();
            }
        }

        private string CalcularNominaCatedraticos()
        {
            double liquidacion = 0;
            List<DocenteCatedratico> liquidaciones = ConsultarCatedratico();
            foreach (var item in liquidaciones)
            {
                liquidacion += item.SalarioTotal;
                
            }
            return liquidacion.ToString();
        }
        private string CalcularNominaOcasionales()
        {
            double liquidacion = 0;
            List<DocenteOcasional> liquidaciones = ConsultarOcasional();
            foreach (var item in liquidaciones)
            {
                liquidacion += item.Salario;

            }
            return liquidacion.ToString();
        }

        public List<Docente> Consultar()
        {
            List<Docente> docente = new List<Docente>();
            FileStream file = new FileStream(rutaTxt, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                Docente docentes = MapearDocente(linea);
                docente.Add(docentes);
            }
            reader.Close();
            file.Close();
            return docente;
        }
        public Docente Mapear(Docente docente, string[] matrizDocente)
        {
            docente.TipoDocente = (matrizDocente[0]);
            docente.Sueldo = double.Parse(matrizDocente[1]);
            return docente;
        }
        public Docente MapearDocente(string linea)
        {
            Docente docente;
            char delimeter = ';';
            string[] matrizDocente = linea.Split(delimeter);
            docente = new Docente();
            Mapear(docente, matrizDocente);
            return docente;
        }
        public List<DocenteCatedratico> ConsultarCatedratico()
        {
            List<DocenteCatedratico> docente = new List<DocenteCatedratico>();
            FileStream file = new FileStream(rutaC, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                DocenteCatedratico docentes = MapearDocenteCatedratico(linea);
                docente.Add(docentes);
            }
            reader.Close();
            file.Close();
            return docente;
        }
        public DocenteCatedratico MapearCatedratico(DocenteCatedratico docente, string[] matrizDocente)
        {
            docente.Horas = int.Parse(matrizDocente[0]);
            docente.ValorHora = double.Parse(matrizDocente[1]);
            docente.Sueldo = double.Parse(matrizDocente[2]);
            docente.Salud = double.Parse(matrizDocente[3]);
            docente.Pension = double.Parse(matrizDocente[4]);
            docente.Cesantias = double.Parse(matrizDocente[5]);
            docente.SalarioTotal = double.Parse(matrizDocente[6]);
            return docente;
        }
        public DocenteCatedratico MapearDocenteCatedratico(string linea)
        {
            DocenteCatedratico docente;
            char delimeter = ';';
            string[] matrizDocente = linea.Split(delimeter);
            docente = new DocenteCatedratico();
            MapearCatedratico(docente, matrizDocente);
            return docente;
        }
        public List<DocenteOcasional> ConsultarOcasional()
        {
            List<DocenteOcasional> docente = new List<DocenteOcasional>();
            FileStream file = new FileStream(rutaO, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                DocenteOcasional docentes = MapearDocenteOcasional(linea);
                docente.Add(docentes);
            }
            reader.Close();
            file.Close();
            return docente;
        }
        public DocenteOcasional MapearOcasional(DocenteOcasional docente, string[] matrizDocente)
        {
            docente.Categoria = (matrizDocente[0]);
            docente.Postgrado = (matrizDocente[1]);
            docente.gruposSemillero = (matrizDocente[2]);
            docente.Salario = double.Parse(matrizDocente[3]);
            return docente;
        }
        public DocenteOcasional MapearDocenteOcasional(string linea)
        {
            DocenteOcasional docente;
            char delimeter = ';';
            string[] matrizDocente = linea.Split(delimeter);
            docente = new DocenteOcasional();
            MapearOcasional(docente, matrizDocente);
            return docente;
        }
        private void CrearDocDocentesOcasionales()
        {
            string aux = CalcularNominaOcasionales();
            Document pdfDocument = new Document(PageSize.LETTER);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(rutaPDFO, FileMode.Append));
            pdfDocument.Open();
            try
            {

                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                string[] lineas = File.ReadAllLines(rutaO);
                Paragraph titulo = new Paragraph("NOMINA DOCENTES OCASIONALES", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK));
                titulo.SpacingBefore = 20f;
                titulo.SpacingAfter = 20f;
                titulo.Alignment = Element.ALIGN_CENTER;
                pdfDocument.Add(titulo);
                PdfPCell celdaCategoria = new PdfPCell(new Phrase("Categoria"));
                PdfPCell celdaSueldo = new PdfPCell(new Phrase("Posgrado"));
                PdfPCell celdaPosgrado = new PdfPCell(new Phrase("Semillero"));
                PdfPCell celdaSemillero = new PdfPCell(new Phrase("Salario"));
                tabla.AddCell(celdaCategoria);
                tabla.AddCell(celdaSueldo);
                tabla.AddCell(celdaPosgrado);
                tabla.AddCell(celdaSemillero);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    for (int i = 0; i < datos.Length; i++)
                    {

                        PdfPCell celda = new PdfPCell(new Phrase(datos[i]));
                        tabla.AddCell(celda);
                    }
                }
                pdfDocument.Add(tabla);
                pdfDocument.Add(Chunk.NEWLINE);
                Paragraph p = new Paragraph();
                p.Alignment = Element.ALIGN_CENTER;
                p.Add("Universidad Popular del Cesar");
                p.Add(Chunk.NEWLINE);
                p.Add("La liquidacion de la nomina es de: " + aux);
                pdfDocument.Add(p);
            }
            finally
            {
                pdfDocument.Close();
                pdfWriter.Close();
            }
        }
        private void CrearDocumentoPDF()
        {
            string aux = CalcularNominaOcasionales();
            string aux2 = CalcularNominaCatedraticos();
            double total = double.Parse(aux) + double.Parse(aux2);
            Document pdfDocument = new Document(PageSize.LETTER);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(rutaPDF, FileMode.Create));
            pdfDocument.Open();
            try
            {

                PdfPTable tabla = new PdfPTable(2);
                tabla.WidthPercentage = 100;
                string[] lineas = File.ReadAllLines(rutaTxt);
                Paragraph titulo = new Paragraph("NOMINA DOCENTES GENERAL", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK));
                titulo.SpacingBefore = 20f;
                titulo.SpacingAfter = 20f;
                titulo.Alignment = Element.ALIGN_CENTER;
                pdfDocument.Add(titulo);
                PdfPCell celdaTipoDocente = new PdfPCell(new Phrase("Tipo Docente"));
               
                PdfPCell celdaSalario = new PdfPCell(new Phrase("Salario"));
                tabla.AddCell(celdaTipoDocente);
                tabla.AddCell(celdaSalario);
               
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    for (int i = 0; i < datos.Length; i++)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(datos[i]));
                        tabla.AddCell(celda);
                    }
                }
                
                pdfDocument.Add(tabla);
                pdfDocument.Add(Chunk.NEWLINE);
                Paragraph p = new Paragraph();
                p.Alignment = Element.ALIGN_CENTER;
                p.Add("Universidad Popular del Cesar");
                p.Add(Chunk.NEWLINE);
                p.Add("La liquidacion de la nomina es de: " + total.ToString());
                pdfDocument.Add(p);
            }
            finally
            {
                pdfDocument.Close();
                pdfWriter.Close();
            }
        }

    }
}