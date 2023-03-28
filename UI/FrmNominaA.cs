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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic;

namespace UI
{
    public partial class FrmNominaA : Form
    {
        DocenteService docenteService;
        bool validar = true;
        string categoria, posgrado, grupoSemillero;
        int horas;
        double valorHora;
        public FrmNominaA()
        {
            InitializeComponent();
            docenteService = new DocenteService();
            TotalDocentesTxt.Enabled = false;
            TotalNominaTxt.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerificarDocentes();

            if (validar == true)
            {
                CrearDocenteOcasional();
                CrearDocenteCatedratico();
            }
            else
            {
                validar = true;
                MessageBox.Show("Verifique la cantidad de docentes");
            }
        }
        private void CrearDocenteCatedratico()
        {
            for (int i = 0; i < Convert.ToInt32(DocentesCatedraticosTxt.Text); i++)
            {
                DefinirHoras();
                DefinirValorHora();
                DocenteCatedratico docente = new DocenteCatedratico(horas, valorHora);
                DocenteService docenteService = new DocenteService();
                string Mensaje = docenteService.GuardarCatedraticos(docente);
                MessageBox.Show(Mensaje);
                horas = 0;
                valorHora = 0;

            }
        }
        private void CrearDocenteOcasional()
        {
            for (int i = 0; i < Convert.ToInt32(DocentesOcasionalesTxt.Text); i++)
            {
                DefinirCategoria();
                DefinirPosgrado();
                DefinirGrupoSemillero();
                DocenteOcasional docente = new DocenteOcasional(categoria, posgrado, grupoSemillero);
                DocenteService docenteService = new DocenteService();
                string Mensaje = docenteService.GuardarOcasionales(docente);
                MessageBox.Show(Mensaje);
                categoria = "";
                posgrado = "";
                grupoSemillero = "";

            }
        }
        private void DefinirHoras()
        {
            string valor2 = (Interaction.InputBox("Digite la cantidad de horas: "));
            horas = int.Parse(valor2);
        }
        private void DefinirValorHora()
        {
            string valor2 = (Interaction.InputBox("Digite el sueldo por hora trabajada: "));
            valorHora = double.Parse(valor2);
        }
        private void DefinirGrupoSemillero()
        {
            string valor2 = (Interaction.InputBox("Digite el grupo Semillero: \n 1. A1 \n 2. A \n 3. B \n 4. C \n 5. Reconocidos por Colciencias \n 6. Semillero \n 7. No aplica"));
            switch (Convert.ToInt32(valor2))
            {
                case 1:
                    grupoSemillero = "A1";
                    break;
                case 2:
                    grupoSemillero = "AA";
                    break;
                case 3:
                    grupoSemillero = "B";
                    break;
                case 4:
                    grupoSemillero = "C";
                    break;
                case 5:
                    grupoSemillero = "Reconocidos por Colciencias";
                    break;
                case 6:
                    grupoSemillero = "Semillero";
                    break;
                default:
                    grupoSemillero = "No aplica";
                    break;
            }
        }

        private void DefinirPosgrado()
        {
            string valor1 = (Interaction.InputBox("Digite el posgrado: \n 1. Especializacion \n 2. Maestria \n 3. Doctorado \n 4. PostDoctorado \n 5. No aplica"));
            switch (Convert.ToInt32(valor1))
            {
                case 1:
                    posgrado = "Especializacion";
                    break;
                case 2:
                    posgrado = "Maestria";
                    break;
                case 3:
                    posgrado = "Doctorado";
                    break;
                case 4:
                    posgrado = "PostDoctorado";
                    break;
                default:
                    posgrado = "No aplica";
                    break;
            }
        }

        private void DefinirCategoria()
        {
            string valor = (Interaction.InputBox("Digite la categoria: \n 1. Auxiliar Tiempo Completo \n 2. Auxiliar Medio Tiempo \n 3. Asistente Tiempo Completo \n 4. Asistente Medio Tiempo \n 5. Asociado Tiempo Completo \n 6. Asociado Medio Tiempo \n 7. Titular Tiempo Completo \n 8. Titular Medio Tiempo"));
            int aux = Convert.ToInt32(valor);
            switch (aux)
            {
                case 1:
                    categoria = "Auxiliar Tiempo Completo";
                    break;
                case 2:
                    categoria = "Auxiliar Medio Tiempo";
                    break;
                case 3:
                    categoria = "Asistente Tiempo Completo";
                    break;
                case 4:
                    categoria = "Asistente Medio Tiempo";
                    break;
                case 5:
                    categoria = "Asociado Tiempo Completo";
                    break;
                case 6:
                    categoria = "Asocioado Medio Tiempo";
                    break;
                case 7:
                    categoria = "Titular Tiempo Completo";
                    break;
                case 8:
                    categoria = "Titular Medio Tiempo";
                    break;
            }
        }

        private void VerificarDocentes()
        {
            if (DocentesCatedraticosTxt.Text == "")
            {
                validar = false;
            }
            if (DocentesOcasionalesTxt.Text == "")
            {
                validar = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DocentesCatedraticosTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void DocentesOcasionalesTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void CrearPdfBtn_Click(object sender, EventArgs e)
        {
            string Mensaje = docenteService.CrearPDF();
            MessageBox.Show(Mensaje);

        }

        private void BtnMostrarTotal_Click(object sender, EventArgs e)
        {
            TotalNominaTxt.Text = docenteService.MostrarTotalLiquidacion();
            TotalDocentesTxt.Text = docenteService.MostrarTotalDocentes();
        }
    }
}
