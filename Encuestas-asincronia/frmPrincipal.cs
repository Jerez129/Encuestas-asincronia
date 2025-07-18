using ScottPlot;
using System;


namespace Encuestas_asincronia
{
    public partial class frmPrincipal : Form
    {
        // Instancia que contiene los resultados de la encuesta y tiene el evento de actualizaci�n
        Datos datos;
        public frmPrincipal()
        {
            InitializeComponent();
            // Se inicializa el objeto Datos
            datos = new Datos();
            // Se suscribe a un evento que se activa cuando hay nuevos datos
            datos.AlActualizar += ActualizarResultados;
            //Muestra los gr�ficos al iniciar el formulario
            MostrarGraficos();
        }

        // Este evento se activa cuando el usuario hace clic en el bot�n "Empezar encuesta"
        private void btnEmpezarencuesta_Click(object sender, EventArgs e)
        {
            // Se abre el formulario de encuesta, pas�ndole la instancia de Datos
            frmEncuestas frmEncuestas = new frmEncuestas(datos);
            frmEncuestas.Show();
        }

        // M�todo que se invoca cuando se actualizan los datos que se encuentran en las lislas dentro de la clase Datos
        private void ActualizarResultados()
        {
            // Verifica si el m�todo est� trabajando en otro hilo que no es el de la interfaz.
            if (InvokeRequired)
            {
                // Si no est� en el hilo principal de la interfaz,
                // se reinvoca el m�todo en el hilo correcto usando Invoke.
                Invoke(() => ActualizarResultados());
                return;
            }

            // Ahora actualiza el gr�fico
            MostrarGraficos();
        }

        // Carga los gr�ficos de cada pregunta
        private void MostrarGraficos()
        {
            MostrarGraficoIndividual(plotPregunta1, datos.Pregunta1, "�Cu�l es la primera actividad que realiza tras despertarse?", new[] { "Realizar ejercicio f�sico", "Consultar el tel�fono m�vil", "Preparar y consumir el desayuno" });
            MostrarGraficoIndividual(plotPregunta2, datos.Pregunta2, "�A qu� hora comienza habitualmente su jornada en d�as laborables?", new[] { "Antes de las 6:00 a. m.", "Entre las 6:00 y las 8:00 a. m.", "Despu�s de las 8:00 a. m." });
            MostrarGraficoIndividual(plotPregunta3, datos.Pregunta3, "�Con qu� frecuencia toma una ducha a primera hora de la ma�ana?", new[] { "Siempre", "A veces", "Rara vez o nunca" });
            MostrarGraficoIndividual(plotPregunta4, datos.Pregunta4, "�C�mo describir�a su nivel de energ�a durante los primeros treinta minutos tras despertarse?", new[] { "Alto (me siento con mucha vitalidad)", "Moderado (me activo gradualmente)", "Bajo (necesito m�s tiempo para despertarme)" });
        }

        //Carga gr�ficos individuales para cada pregunta
        //plotControl: el control gr�fico donde se mostrar� el resultado.
        //valoresInt: la lista con los conteos de respuestas por opci�n.
        //titulo: el t�tulo de la pregunta que se mostrar� en el gr�fico.
        //etiquetas: los textos que representan cada opci�n de respuesta.
        private void MostrarGraficoIndividual(ScottPlot.WinForms.FormsPlot plotControl, List<int> valoresInt, string titulo, string[] etiquetas)
        {
            // Se accede al objeto Plot del control gr�fico para empezar a configurarlo
            var plt = plotControl.Plot;
            // Limpia el gr�fico antes de agregar nuevos datos
            plt.Clear();

            // Convierte los valores (int) a tipo double, como requiere ScottPlot
            double[] valores = valoresInt.Select(v => (double)v).ToArray();

            // Se agregan las barras al gr�fico usando los datos
            var barPlot = plt.Add.Bars(valores);

            // Se definen los colores para las barras (uno por cada opci�n de respuesta)
                ScottPlot.Color[] colores = {
                ScottPlot.Colors.Orange,
                ScottPlot.Colors.MediumPurple,
                ScottPlot.Colors.Teal
                 };


            // Configura cada barra individualmente
            for (int i = 0; i < barPlot.Bars.Count; i++)
            {
                barPlot.Bars[i].FillColor = colores[i]; // Asigna un color espec�fico a cada barra
                barPlot.Bars[i].Size = 0.6;             // Define el ancho de las barras
                barPlot.Bars[i].Label = valores[i].ToString(); // Muestra el valor de cada barra como etiqueta
            }

            // Configura el estilo de las etiquetas de los valores en las barras
            barPlot.ValueLabelStyle.FontSize = 14;
            barPlot.ValueLabelStyle.Bold = true;

            //  Define las posiciones y los textos para las etiquetas del eje X
            double[] posiciones = Enumerable.Range(0, etiquetas.Length).Select(i => (double)i).ToArray();
            plt.Axes.Bottom.SetTicks(posiciones, etiquetas);

            // Establece t�tulo del gr�fico y etiqueta del eje Y
            plt.Title(titulo);
            plt.YLabel("Cantidad de respuestas");

            // Refresca el control gr�fico para que se apliquen los cambios visuales
            plotControl.Refresh();
        }



        private void frmPrincipal_Load(object sender, EventArgs e)
        {
          
        }
    }
}
