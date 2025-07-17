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
            MostrarGraficos();
        }

        private void MostrarGraficos()
        {
            MostrarGraficoIndividual(plotPregunta1, datos.Pregunta1, "¿Cuál es la primera actividad que realiza tras despertarse?", new[] { "Realizar ejercicio físico", "Consultar el teléfono móvil", "Preparar y consumir el desayuno" });
            MostrarGraficoIndividual(plotPregunta2, datos.Pregunta2, "¿A qué hora comienza habitualmente su jornada en días laborables?", new[] { "Antes de las 6:00 a. m.", "Entre las 6:00 y las 8:00 a. m.", "Después de las 8:00 a. m." });
            MostrarGraficoIndividual(plotPregunta3, datos.Pregunta3, "¿Con qué frecuencia toma una ducha a primera hora de la mañana?", new[] { "Siempre", "A veces", "Rara vez o nunca" });
            MostrarGraficoIndividual(plotPregunta4, datos.Pregunta4, "¿Cómo describiría su nivel de energía durante los primeros treinta minutos tras despertarse?", new[] { "Alto (me siento con mucha vitalidad)", "Moderado (me activo gradualmente)", "Bajo (necesito más tiempo para despertarme)" });
        }

        private void MostrarGraficoIndividual(ScottPlot.WinForms.FormsPlot plotControl, List<int> valoresInt, string titulo, string[] etiquetas)
        {
            var plt = plotControl.Plot;
            plt.Clear();

            double[] valores = valoresInt.Select(v => (double)v).ToArray();

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

            plt.Title(titulo);
            plt.YLabel("Cantidad de respuestas");

            plotControl.Refresh();
        }



        private void frmPrincipal_Load(object sender, EventArgs e)
        {
          
        }
    }
}
