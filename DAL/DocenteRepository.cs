using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Entity;

namespace DAL
{
    public class DocenteRepository
    {
        string rutaO = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesO.txt";
        string rutaC = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\DocentesC.txt";
        string rutPDF = "C:\\Users\\davii\\source\\repos\\Payroll Simulation\\Docentes.pdf";
        public void GuardarDocentesOcasionales(DocenteOcasional docenteOcasional)
        {
            FileStream file = new FileStream(rutaO, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(docenteOcasional.Salario + ";" +
                docenteOcasional.Categoria);
            writer.Close();
            file.Close();
        }
        public void GuardarDocentesCatedraticos(DocenteCatedratico docenteC)
        {
            FileStream file = new FileStream(rutaC, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(docenteC.Horas + ";" +
                docenteC.ValorHora + ";" +
                docenteC.Salario);
            writer.Close();
            file.Close();
        }
        public void CrearDocumento()
        {
            Document document = new Document();
            string filename = rutPDF;
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
            document.Open();
            document.Add(new Paragraph("Hola mundo"));
            document.Close();
        }
    }
}