using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Entity;
using System.Collections;

namespace DAL
{
    public class DocenteRepository
    {
        string rutaO = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesO.txt";
        string rutaC = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesC.txt";
        string rutaPDF = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\Docentes.pdf";
        string ruta= "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\Docentes.txt";
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
                docenteC.Cesantias);
            writer.Close();
            file.Close();
        }
        public void CombinarTxt()
        {
            string contenidoArchivo1 = File.ReadAllText(rutaC);
            string contenidoArchivo2 = File.ReadAllText(rutaO);
            string contenidoResultado = contenidoArchivo1 + contenidoArchivo2;
            File.WriteAllText(ruta, contenidoResultado);
        }
        public void CrearDocumento()
        {
            CrearDocDocentesOcasionales();
            CrearDocDocentesCatedraticos();

        }

        private void CrearDocDocentesCatedraticos()
        {
            Document pdfDocument = new Document(PageSize.LETTER);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(rutaPDF, FileMode.Append));
            pdfDocument.Open();
            try
            {

                PdfPTable tabla = new PdfPTable(6);
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

                tabla.AddCell(celdaHoras);
                tabla.AddCell(celdaValorHora);
                tabla.AddCell(celdaSueldo);
                tabla.AddCell(celdaSalud);
                tabla.AddCell(celdaPension);
                tabla.AddCell(celdaCesantias);

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
            }
            finally
            {
                pdfDocument.Close();
                pdfWriter.Close();
            }
        }

        private void CrearDocDocentesOcasionales()
        {
            Document pdfDocument = new Document(PageSize.LETTER);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(rutaPDF, FileMode.Append));
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
            }
            finally
            {
                pdfDocument.Close();
                pdfWriter.Close();
            }
        }

        public List<DocenteOcasional> Consultar()
        {
            List<DocenteOcasional> docenteO = new List<DocenteOcasional>();
            FileStream file = new FileStream(rutaO, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                DocenteOcasional docentes = MapearProducto(linea);
                docenteO.Add(docentes);
            }
            reader.Close();
            file.Close();
            return docenteO;
        }
        public DocenteOcasional Mapear(DocenteOcasional docenteO, string[] matrizDocentes)
        {
            docenteO.Categoria = (matrizDocentes[0]);
            docenteO.Sueldo = double.Parse(matrizDocentes[1]);
            docenteO.Postgrado = (matrizDocentes[2]);
            docenteO.gruposSemillero = (matrizDocentes[3]);
            docenteO.Salario = double.Parse(matrizDocentes[4]);

            return docenteO;
        }
        public DocenteOcasional MapearProducto(string linea)
        {
            DocenteOcasional docente;
            char delimeter = ';';
            string[] matrizProductos = linea.Split(delimeter);
            docente = new DocenteOcasional();
            Mapear(docente, matrizProductos);
            return docente;
        }

    }
}