using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.Windows.Forms;
using System.Numerics;
using Entity;

namespace UI
{
    public partial class FrmNominaA : Form
    {
        DocenteService docenteService;
        public FrmNominaA()
        {
            InitializeComponent();
            docenteService = new DocenteService();
        }
        private DocenteOcasional MapearDocente()
        {
            DocenteOcasional docente = new DocenteOcasional("Auxiliar Tiempo Completo");
           
            return docente;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DocenteOcasional docente = MapearDocente();
            DocenteService docenteService = new DocenteService();
            string Mensaje = docenteService.GuardarOcasionales(docente);
            MessageBox.Show(Mensaje);
            

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
