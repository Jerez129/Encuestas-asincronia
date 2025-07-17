using ScottPlot;
using System;


namespace Encuestas_asincronia
{
    public partial class frmPrincipal : Form
    {
        Datos datos;
        public frmPrincipal()
        {
            InitializeComponent();
            datos = new Datos();
            datos.AlActualizar += ActualizarResultados;
            ActualizarResultados();
        }

        private void btnEmpezarencuesta_Click(object sender, EventArgs e)
        {
            frmEncuestas frmEncuestas = new frmEncuestas(datos);
            frmEncuestas.Show();
        }

        private void ActualizarResultados()
        {
            if (InvokeRequired)
            {
                Invoke(() => ActualizarResultados());
                return;
            }

            // Actualiza etiquetas, contadores, etc. si los tienes
            // ...

            // Ahora actualiza el gráfico
            MostrarGrafico();
        }

        private void MostrarGrafico()
        {
            var plt = plotPregunta1.Plot;
            plt.Clear();

            // Obtener los valores reales de la Pregunta 1
            double[] valores = datos.Pregunta1.Select(v => (double)v).ToArray();

            string[] etiquetas = { "Ejercicio", "Revisar celular", "Café" };

            // Agregar barras
            var barPlot = plt.Add.Bars(valores);

            ScottPlot.Color[] colores = {
               ScottPlot.Colors.Orange,
               ScottPlot.Colors.MediumPurple,
               ScottPlot.Colors.Teal
             };

            for (int i = 0; i < barPlot.Bars.Count; i++)
            {
                barPlot.Bars[i].FillColor = colores[i];
                barPlot.Bars[i].Size = 0.6;
                barPlot.Bars[i].Label = valores[i].ToString();
            }

            barPlot.ValueLabelStyle.FontSize = 14;
            barPlot.ValueLabelStyle.Bold = true;

            double[] posiciones = Enumerable.Range(0, etiquetas.Length).Select(i => (double)i).ToArray();
            plt.Axes.Bottom.SetTicks(posiciones, etiquetas);

            plt.Title("Actividad al despertar");
            plt.YLabel("Cantidad de respuestas");

            plotPregunta1.Refresh();
        }



        private void frmPrincipal_Load(object sender, EventArgs e)
        {
          
        }
    }
}
