namespace UI
{
    partial class FrmNominaA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnCalcular = new Button();
            label1 = new Label();
            label2 = new Label();
            DocentesCatedraticosTxt = new TextBox();
            DocentesOcasionalesTxt = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SalarioNetoTxt = new TextBox();
            TotalDocentesTxt = new TextBox();
            TotalNominaTxt = new TextBox();
            CrearPdfBtn = new Button();
            SuspendLayout();
            // 
            // BtnCalcular
            // 
            BtnCalcular.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            BtnCalcular.Location = new Point(197, 146);
            BtnCalcular.Name = "BtnCalcular";
            BtnCalcular.Size = new Size(174, 35);
            BtnCalcular.TabIndex = 0;
            BtnCalcular.Text = "Calcular Nomina";
            BtnCalcular.UseVisualStyleBackColor = true;
            BtnCalcular.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(42, 45);
            label1.Name = "label1";
            label1.Size = new Size(220, 22);
            label1.TabIndex = 1;
            label1.Text = "Docentes Catedráticos:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(49, 87);
            label2.Name = "label2";
            label2.Size = new Size(213, 22);
            label2.TabIndex = 2;
            label2.Text = "Docentes Ocasionales:";
            // 
            // DocentesCatedraticosTxt
            // 
            DocentesCatedraticosTxt.Location = new Point(283, 44);
            DocentesCatedraticosTxt.Name = "DocentesCatedraticosTxt";
            DocentesCatedraticosTxt.Size = new Size(88, 27);
            DocentesCatedraticosTxt.TabIndex = 3;
            DocentesCatedraticosTxt.KeyPress += DocentesCatedraticosTxt_KeyPress;
            // 
            // DocentesOcasionalesTxt
            // 
            DocentesOcasionalesTxt.Location = new Point(283, 87);
            DocentesOcasionalesTxt.Name = "DocentesOcasionalesTxt";
            DocentesOcasionalesTxt.Size = new Size(88, 27);
            DocentesOcasionalesTxt.TabIndex = 4;
            DocentesOcasionalesTxt.KeyPress += DocentesOcasionalesTxt_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(49, 288);
            label3.Name = "label3";
            label3.Size = new Size(129, 22);
            label3.TabIndex = 5;
            label3.Text = "Salario Neto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(28, 337);
            label4.Name = "label4";
            label4.Size = new Size(150, 22);
            label4.TabIndex = 6;
            label4.Text = "Total Docentes:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(42, 386);
            label5.Name = "label5";
            label5.Size = new Size(136, 22);
            label5.TabIndex = 7;
            label5.Text = "Total Nomina:";
            // 
            // SalarioNetoTxt
            // 
            SalarioNetoTxt.Location = new Point(246, 283);
            SalarioNetoTxt.Name = "SalarioNetoTxt";
            SalarioNetoTxt.Size = new Size(125, 27);
            SalarioNetoTxt.TabIndex = 8;
            // 
            // TotalDocentesTxt
            // 
            TotalDocentesTxt.Location = new Point(246, 332);
            TotalDocentesTxt.Name = "TotalDocentesTxt";
            TotalDocentesTxt.Size = new Size(125, 27);
            TotalDocentesTxt.TabIndex = 9;
            // 
            // TotalNominaTxt
            // 
            TotalNominaTxt.Location = new Point(246, 385);
            TotalNominaTxt.Name = "TotalNominaTxt";
            TotalNominaTxt.Size = new Size(125, 27);
            TotalNominaTxt.TabIndex = 10;
            // 
            // CrearPdfBtn
            // 
            CrearPdfBtn.Location = new Point(197, 187);
            CrearPdfBtn.Name = "CrearPdfBtn";
            CrearPdfBtn.Size = new Size(174, 39);
            CrearPdfBtn.TabIndex = 11;
            CrearPdfBtn.Text = "Generar PDF";
            CrearPdfBtn.UseVisualStyleBackColor = true;
            CrearPdfBtn.Click += CrearPdfBtn_Click;
            // 
            // FrmNominaA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(731, 473);
            Controls.Add(CrearPdfBtn);
            Controls.Add(TotalNominaTxt);
            Controls.Add(TotalDocentesTxt);
            Controls.Add(SalarioNetoTxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(DocentesOcasionalesTxt);
            Controls.Add(DocentesCatedraticosTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnCalcular);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmNominaA";
            Text = "NominaA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCalcular;
        private Label label1;
        private Label label2;
        private TextBox DocentesCatedraticosTxt;
        private TextBox DocentesOcasionalesTxt;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox SalarioNetoTxt;
        private TextBox TotalDocentesTxt;
        private TextBox TotalNominaTxt;
        private Button CrearPdfBtn;
    }
}