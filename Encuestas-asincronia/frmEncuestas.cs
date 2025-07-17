using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestas_asincronia
{
    public partial class frmEncuestas : Form
    {
        Datos datos;
        public frmEncuestas()
        {
            InitializeComponent();
            datos = new Datos();
        }

        private void frmEncuestas_Load(object sender, EventArgs e)
        {

        }
       
        private async void btnEmpezarencuesta_Click(object sender, EventArgs e)
        {

            int p1 = ObtenerOpcionSeleccionada(gbRespuestas1);
            int p2 = ObtenerOpcionSeleccionada(gbRespuestas2);
            int p3 = ObtenerOpcionSeleccionada(gbRespuestas3);
            int p4 = ObtenerOpcionSeleccionada(gbRespuestas4);

            // Validamos que todas las preguntas estén respondidas
            if (p1 == -1 || p2 == -1 || p3 == -1 || p4 == -1)
            {
                MessageBox.Show("Por favor, responde todas las preguntas antes de enviar la encuesta.", "Faltan respuestas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salimos sin enviar nada
            }

            if (p1 != -1)
                await datos.EnviarRespuestaAsync(1, p1);
            if (p2 != -1)
                await datos.EnviarRespuestaAsync(2, p2);
            if (p3 != -1)
                await datos.EnviarRespuestaAsync(3, p3);
            if (p4 != -1)
                await datos.EnviarRespuestaAsync(4, p4);

            MessageBox.Show("Respuesta enviada!");
            this.Close();
        }



        private int ObtenerOpcionSeleccionada(GroupBox grupo)
        {
            var radios = grupo.Controls.OfType<RadioButton>().ToList();
            for (int i = 0; i < radios.Count; i++)
            {
                if (radios[i].Checked)
                    return i;
            }
            return -1; // Ningún RadioButton seleccionado
        }








        //Botones para despliegue de respuestas para las encuestas
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
                pnlIconopreguntas4.Visible = false;
            }
            else
            {
                pnlIconopreguntas4.Visible = true;
            }
        }

    }
}
