using ScottPlot;
using System;

namespace Encuestas_asincronia
{
    public partial class frmPrincipal : Form
    {
        Datos datos = new Datos();
        public frmPrincipal()
        {
            InitializeComponent();
            MostrarGrafico();
           
        }

        private void btnEmpezarencuesta_Click(object sender, EventArgs e)
        {
            frmEncuestas frmEncuestas = new frmEncuestas();
            frmEncuestas.Show();
        }

        private void MostrarGrafico()
        {
            var plt = plotPregunta1.Plot;
            plt.Clear();

            // Datos de ejemplo
            double[] valores = { 5, 8, 3 };
            string[] etiquetas = { "Ejercicio", "Revisar celular", "Café" };

            // Agregar barras
            var barPlot = plt.Add.Bars(valores);

            // Personalizar cada barra individualmente
            ScottPlot.Color[] colores = {
             ScottPlot.Colors.Orange,
             ScottPlot.Colors.MediumPurple,
                 ScottPlot.Colors.Teal
                 };

            for (int i = 0; i < barPlot.Bars.Count; i++)
            {
                barPlot.Bars[i].FillColor = colores[i];
                barPlot.Bars[i].Size = 0.6; // Equivalente a BarWidth
                barPlot.Bars[i].Label = valores[i].ToString(); // Mostrar valor encima
            }

            // Estilo de etiquetas
            barPlot.ValueLabelStyle.FontSize = 14;
            barPlot.ValueLabelStyle.Bold = true;

            // Etiquetas en eje X
            double[] posiciones = Enumerable.Range(0, etiquetas.Length).Select(i => (double)i).ToArray();
            plt.Axes.Bottom.SetTicks(posiciones, etiquetas);

            // Título y etiquetas
            plt.Title("Actividad al despertar");
            plt.YLabel("Cantidad de respuestas");

            plotPregunta1.Refresh();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
          
        }
    }
}
