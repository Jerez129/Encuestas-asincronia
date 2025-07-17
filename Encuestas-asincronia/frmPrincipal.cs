using ScottPlot;
using System;


namespace Encuestas_asincronia
{
    public partial class frmPrincipal : Form
    {
        // Instancia que contiene los resultados de la encuesta y tiene el evento de actualización
        Datos datos;
        public frmPrincipal()
        {
            InitializeComponent();
            // Se inicializa el objeto Datos
            datos = new Datos();
            // Se suscribe a un evento que se activa cuando hay nuevos datos
            datos.AlActualizar += ActualizarResultados;
            //Muestra los gráficos al iniciar el formulario
            MostrarGraficos();
        }

        // Este evento se activa cuando el usuario hace clic en el botón "Empezar encuesta"
        private void btnEmpezarencuesta_Click(object sender, EventArgs e)
        {
            // Se abre el formulario de encuesta, pasándole la instancia de Datos
            frmEncuestas frmEncuestas = new frmEncuestas(datos);
            frmEncuestas.Show();
        }

        // Método que se invoca cuando se actualizan los datos que se encuentran en las lislas dentro de la clase Datos
        private void ActualizarResultados()
        {
            // Verifica si el método está trabajando en otro hilo que no es el de la interfaz.
            if (InvokeRequired)
            {
                // Si no está en el hilo principal de la interfaz,
                // se reinvoca el método en el hilo correcto usando Invoke.
                Invoke(() => ActualizarResultados());
                return;
            }

            // Ahora actualiza el gráfico
            MostrarGraficos();
        }

        // Carga los gráficos de cada pregunta
        private void MostrarGraficos()
        {
            MostrarGraficoIndividual(plotPregunta1, datos.Pregunta1, "¿Cuál es la primera actividad que realiza tras despertarse?", new[] { "Realizar ejercicio físico", "Consultar el teléfono móvil", "Preparar y consumir el desayuno" });
            MostrarGraficoIndividual(plotPregunta2, datos.Pregunta2, "¿A qué hora comienza habitualmente su jornada en días laborables?", new[] { "Antes de las 6:00 a. m.", "Entre las 6:00 y las 8:00 a. m.", "Después de las 8:00 a. m." });
            MostrarGraficoIndividual(plotPregunta3, datos.Pregunta3, "¿Con qué frecuencia toma una ducha a primera hora de la mañana?", new[] { "Siempre", "A veces", "Rara vez o nunca" });
            MostrarGraficoIndividual(plotPregunta4, datos.Pregunta4, "¿Cómo describiría su nivel de energía durante los primeros treinta minutos tras despertarse?", new[] { "Alto (me siento con mucha vitalidad)", "Moderado (me activo gradualmente)", "Bajo (necesito más tiempo para despertarme)" });
        }

        //Carga gráficos individuales para cada pregunta
        //plotControl: el control gráfico donde se mostrará el resultado.
        //valoresInt: la lista con los conteos de respuestas por opción.
        //titulo: el título de la pregunta que se mostrará en el gráfico.
        //etiquetas: los textos que representan cada opción de respuesta.
        private void MostrarGraficoIndividual(ScottPlot.WinForms.FormsPlot plotControl, List<int> valoresInt, string titulo, string[] etiquetas)
        {
            // Se accede al objeto Plot del control gráfico para empezar a configurarlo
            var plt = plotControl.Plot;
            // Limpia el gráfico antes de agregar nuevos datos
            plt.Clear();

            // Convierte los valores (int) a tipo double, como requiere ScottPlot
            double[] valores = valoresInt.Select(v => (double)v).ToArray();

            // Se agregan las barras al gráfico usando los datos
            var barPlot = plt.Add.Bars(valores);

            // Se definen los colores para las barras (uno por cada opción de respuesta)
                ScottPlot.Color[] colores = {
                ScottPlot.Colors.Orange,
                ScottPlot.Colors.MediumPurple,
                ScottPlot.Colors.Teal
                 };


            // Configura cada barra individualmente
            for (int i = 0; i < barPlot.Bars.Count; i++)
            {
                barPlot.Bars[i].FillColor = colores[i]; // Asigna un color específico a cada barra
                barPlot.Bars[i].Size = 0.6;             // Define el ancho de las barras
                barPlot.Bars[i].Label = valores[i].ToString(); // Muestra el valor de cada barra como etiqueta
            }

            // Configura el estilo de las etiquetas de los valores en las barras
            barPlot.ValueLabelStyle.FontSize = 14;
            barPlot.ValueLabelStyle.Bold = true;

            //  Define las posiciones y los textos para las etiquetas del eje X
            double[] posiciones = Enumerable.Range(0, etiquetas.Length).Select(i => (double)i).ToArray();
            plt.Axes.Bottom.SetTicks(posiciones, etiquetas);

            // Establece título del gráfico y etiqueta del eje Y
            plt.Title(titulo);
            plt.YLabel("Cantidad de respuestas");

            // Refresca el control gráfico para que se apliquen los cambios visuales
            plotControl.Refresh();
        }



        private void frmPrincipal_Load(object sender, EventArgs e)
        {
          
        }
    }
}
