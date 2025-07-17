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

            // Ahora actualiza el gr�fico
            MostrarGraficos();
        }

        private void MostrarGraficos()
        {
            MostrarGraficoIndividual(plotPregunta1, datos.Pregunta1, "�Cu�l es la primera actividad que realiza tras despertarse?", new[] { "Realizar ejercicio f�sico", "Consultar el tel�fono m�vil", "Preparar y consumir el desayuno" });
            MostrarGraficoIndividual(plotPregunta2, datos.Pregunta2, "�A qu� hora comienza habitualmente su jornada en d�as laborables?", new[] { "Antes de las 6:00 a. m.", "Entre las 6:00 y las 8:00 a. m.", "Despu�s de las 8:00 a. m." });
            MostrarGraficoIndividual(plotPregunta3, datos.Pregunta3, "�Con qu� frecuencia toma una ducha a primera hora de la ma�ana?", new[] { "Siempre", "A veces", "Rara vez o nunca" });
            MostrarGraficoIndividual(plotPregunta4, datos.Pregunta4, "�C�mo describir�a su nivel de energ�a durante los primeros treinta minutos tras despertarse?", new[] { "Alto (me siento con mucha vitalidad)", "Moderado (me activo gradualmente)", "Bajo (necesito m�s tiempo para despertarme)" });
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
