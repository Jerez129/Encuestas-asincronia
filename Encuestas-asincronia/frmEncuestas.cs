using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestas_asincronia
{
    public partial class frmEncuestas : Form
    {
        public frmEncuestas()
        {
            InitializeComponent();
        }

        private void frmEncuestas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pnlRespuestas1.Visible == true)
            {
                pnlRespuestas1.Visible = false;
            }
            else
            {
                pnlRespuestas1.Visible = true;
            }

            if (pnlIconopregunta1.Visible == true)
            {
                pnlIconopregunta1.Visible = false;
            }
            else
            {
                pnlIconopregunta1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pnlRespuestas2.Visible == true)
            {
                pnlRespuestas2.Visible = false;
            }
            else
            {
                pnlRespuestas2.Visible = true;
            }

            if (pnlIconopreguntas2.Visible == true)
            {
                pnlIconopreguntas2.Visible = false;
            }
            else
            {
                pnlIconopreguntas2.Visible = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pnlRespuestas3.Visible == true)
            {
                pnlRespuestas3.Visible = false;
            }
            else
            {
                pnlRespuestas3.Visible = true;
            }

            if (pnlIconopreguntas3.Visible == true)
            {
                pnlIconopreguntas3.Visible = false;
            }
            else
            {
                pnlIconopreguntas3.Visible = true;
            }

        }

        private void btnDesplegarpregunta4_Click(object sender, EventArgs e)
        {
            if (pnlRespuestas4.Visible == true)
            {
                pnlRespuestas4.Visible = false;
        
            }
            else
            {
                pnlRespuestas4.Visible = true;
            }

            if (pnlIconopreguntas4.Visible == true)
            {
                pnlIconopreguntas4 .Visible = false;
            }
            else
            {
                pnlIconopreguntas4.Visible = true;
            }
        }
    }
}
