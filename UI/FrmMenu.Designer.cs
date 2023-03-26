namespace UI
{
    partial class FrmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            panel1 = new Panel();
            panel2 = new Panel();
            PnlNav = new Panel();
            BtnNominaB = new Button();
            BtnNominaA = new Button();
            label1 = new Label();
            button1 = new Button();
            PnlFormularioHijo = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            PnlFormularioHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(46, 51, 73);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 545);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(46, 51, 73);
            panel2.Controls.Add(PnlNav);
            panel2.Controls.Add(BtnNominaB);
            panel2.Controls.Add(BtnNominaA);
            panel2.Location = new Point(0, 173);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 123);
            panel2.TabIndex = 3;
            // 
            // PnlNav
            // 
            PnlNav.BackColor = Color.FromArgb(0, 126, 249);
            PnlNav.Location = new Point(0, 10);
            PnlNav.Name = "PnlNav";
            PnlNav.Size = new Size(3, 100);
            PnlNav.TabIndex = 1;
            // 
            // BtnNominaB
            // 
            BtnNominaB.Dock = DockStyle.Bottom;
            BtnNominaB.FlatStyle = FlatStyle.Flat;
            BtnNominaB.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            BtnNominaB.ForeColor = SystemColors.Control;
            BtnNominaB.Location = new Point(0, 61);
            BtnNominaB.Name = "BtnNominaB";
            BtnNominaB.Size = new Size(250, 62);
            BtnNominaB.TabIndex = 2;
            BtnNominaB.Text = "Nomina B";
            BtnNominaB.TextAlign = ContentAlignment.MiddleLeft;
            BtnNominaB.UseVisualStyleBackColor = true;
            BtnNominaB.Click += BtnNominaB_Click;
            // 
            // BtnNominaA
            // 
            BtnNominaA.Dock = DockStyle.Top;
            BtnNominaA.FlatStyle = FlatStyle.Flat;
            BtnNominaA.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            BtnNominaA.ForeColor = SystemColors.ControlLightLight;
            BtnNominaA.Location = new Point(0, 0);
            BtnNominaA.Name = "BtnNominaA";
            BtnNominaA.Size = new Size(250, 62);
            BtnNominaA.TabIndex = 1;
            BtnNominaA.Text = "Nomina A";
            BtnNominaA.TextAlign = ContentAlignment.MiddleLeft;
            BtnNominaA.UseVisualStyleBackColor = true;
            BtnNominaA.Click += BtnNominaA_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(11, 19);
            label1.Name = "label1";
            label1.Size = new Size(197, 25);
            label1.TabIndex = 1;
            label1.Text = "Payroll Simulation";
            // 
            // button1
            // 
            button1.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(992, 1);
            button1.Name = "button1";
            button1.Size = new Size(29, 29);
            button1.TabIndex = 1;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PnlFormularioHijo
            // 
            PnlFormularioHijo.Controls.Add(pictureBox1);
            PnlFormularioHijo.Location = new Point(257, 47);
            PnlFormularioHijo.Name = "PnlFormularioHijo";
            PnlFormularioHijo.Size = new Size(764, 499);
            PnlFormularioHijo.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(83, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(601, 496);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 37, 55);
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1021, 551);
            Controls.Add(PnlFormularioHijo);
            Controls.Add(button1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payroll Simulation";
            Load += PpalMenu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            PnlFormularioHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button BtnNominaB;
        private Button BtnNominaA;
        private Label label1;
        private Panel PnlNav;
        private Button button1;
        private Panel PnlFormularioHijo;
        private PictureBox pictureBox1;
    }
}