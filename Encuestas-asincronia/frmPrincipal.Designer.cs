namespace Encuestas_asincronia
{
    partial class frmPrincipal
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
            plotPregunta1 = new ScottPlot.WinForms.FormsPlot();
            btnEmpezarencuesta = new Button();
            plotPregunta2 = new ScottPlot.WinForms.FormsPlot();
            plotPregunta3 = new ScottPlot.WinForms.FormsPlot();
            plotPregunta4 = new ScottPlot.WinForms.FormsPlot();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // plotPregunta1
            // 
            plotPregunta1.BackColor = Color.FromArgb(247, 234, 212);
            plotPregunta1.DisplayScale = 1.25F;
            plotPregunta1.Location = new Point(12, 12);
            plotPregunta1.Name = "plotPregunta1";
            plotPregunta1.RightToLeft = RightToLeft.No;
            plotPregunta1.Size = new Size(753, 196);
            plotPregunta1.TabIndex = 0;
            // 
            // btnEmpezarencuesta
            // 
            btnEmpezarencuesta.BackgroundImage = Properties.Resources.principal_iniciar;
            btnEmpezarencuesta.BackgroundImageLayout = ImageLayout.Zoom;
            btnEmpezarencuesta.FlatAppearance.BorderColor = Color.FromArgb(247, 234, 212);
            btnEmpezarencuesta.FlatAppearance.MouseDownBackColor = Color.FromArgb(247, 234, 212);
            btnEmpezarencuesta.FlatAppearance.MouseOverBackColor = Color.FromArgb(247, 234, 212);
            btnEmpezarencuesta.FlatStyle = FlatStyle.Flat;
            btnEmpezarencuesta.Location = new Point(818, 656);
            btnEmpezarencuesta.Name = "btnEmpezarencuesta";
            btnEmpezarencuesta.Size = new Size(258, 86);
            btnEmpezarencuesta.TabIndex = 1;
            btnEmpezarencuesta.UseVisualStyleBackColor = true;
            btnEmpezarencuesta.Click += btnEmpezarencuesta_Click;
            // 
            // plotPregunta2
            // 
            plotPregunta2.BackColor = Color.FromArgb(247, 234, 212);
            plotPregunta2.DisplayScale = 1.25F;
            plotPregunta2.Location = new Point(12, 214);
            plotPregunta2.Name = "plotPregunta2";
            plotPregunta2.RightToLeft = RightToLeft.No;
            plotPregunta2.Size = new Size(753, 196);
            plotPregunta2.TabIndex = 2;
            // 
            // plotPregunta3
            // 
            plotPregunta3.BackColor = Color.FromArgb(247, 234, 212);
            plotPregunta3.DisplayScale = 1.25F;
            plotPregunta3.Location = new Point(12, 416);
            plotPregunta3.Name = "plotPregunta3";
            plotPregunta3.RightToLeft = RightToLeft.No;
            plotPregunta3.Size = new Size(753, 196);
            plotPregunta3.TabIndex = 3;
            // 
            // plotPregunta4
            // 
            plotPregunta4.BackColor = Color.FromArgb(247, 234, 212);
            plotPregunta4.DisplayScale = 1.25F;
            plotPregunta4.Location = new Point(12, 619);
            plotPregunta4.Name = "plotPregunta4";
            plotPregunta4.RightToLeft = RightToLeft.No;
            plotPregunta4.Size = new Size(753, 196);
            plotPregunta4.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Principal_borde;
            pictureBox1.Location = new Point(771, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(346, 326);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.principal_titulo;
            pictureBox2.Location = new Point(771, 388);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(346, 224);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 234, 212);
            ClientSize = new Size(1129, 818);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(plotPregunta4);
            Controls.Add(plotPregunta3);
            Controls.Add(plotPregunta2);
            Controls.Add(btnEmpezarencuesta);
            Controls.Add(plotPregunta1);
            Name = "frmPrincipal";
            Text = "Form1";
            Load += frmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plotPregunta1;
        private Button btnEmpezarencuesta;
        private ScottPlot.WinForms.FormsPlot plotPregunta2;
        private ScottPlot.WinForms.FormsPlot plotPregunta3;
        private ScottPlot.WinForms.FormsPlot plotPregunta4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
