using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UI
{
    public partial class FrmMenu : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(

            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeithEllipse

        );
        public FrmMenu()
        {
            InitializeComponent();
            BtnNominaA.FlatAppearance.BorderSize = 0;
            BtnNominaB.FlatAppearance.BorderSize = 0;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            PnlNav.Height = BtnNominaA.Height;
            PnlNav.Top = BtnNominaA.Top;
            PnlNav.Left = BtnNominaA.Left;
            BtnNominaA.BackColor = Color.FromArgb(46, 51, 73);
        }
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PnlFormularioHijo.Controls.Add(childForm);
            PnlFormularioHijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void PpalMenu_Load(object sender, EventArgs e)
        {

        }

        private void BtnNominaA_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnNominaA.Height;
            PnlNav.Top = BtnNominaA.Top;
            PnlNav.Left = BtnNominaA.Left;
            BtnNominaA.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new FrmNominaA());
        }

        private void BtnNominaB_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnNominaB.Height;
            PnlNav.Top = BtnNominaB.Top;
            BtnNominaB.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new FrmNominaB());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}