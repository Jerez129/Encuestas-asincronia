using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas_asincronia
{
    public class Datos
    {
        // Listas que almacenan el conteo de respuestas para cada pregunta.
        // Cada pregunta tiene 3 opciones inicializadas en 0.
        public List<int> Pregunta1 = new List<int> { 0, 0, 0 };
        public List<int> Pregunta2 = new List<int> { 0, 0, 0 };
        public List<int> Pregunta3 = new List<int> { 0, 0, 0 };
        public List<int> Pregunta4 = new List<int> { 0, 0, 0 };


        // Evento que se dispara para notificar que los datos han sido actualizados.
        // El formulario principal se suscribirá a este evento para refrescar gráficos y contadores.
        public event Action AlActualizar;

        // Método asincrónico que simula el envío y procesamiento de una respuesta.
        // Recibe:
        //   pregunta: número de la pregunta (1 a 4)
        //   opcion: índice de la opción seleccionada (0 a 2)
        public async Task EnviarRespuestaAsync(int pregunta, int opcion)
        {
            // Simula latencia de red o procesamiento con un retraso aleatorio entre 500 y 1000 ms.
            await Task.Delay(new Random().Next(500, 1000));

            // Ejecuta el procesamiento en un hilo de fondo para no bloquear la interfaz de usuario.
            await Task.Run(() =>
            {
                // Dependiendo del número de pregunta, incrementa el contador de la opción seleccionada.
                switch (pregunta)
                {
                    case 1:
                        Pregunta1[opcion]++;
                        break;
                    case 2:
                        Pregunta2[opcion]++;
                        break;
                    case 3:
                        Pregunta3[opcion]++;
                        break;
                    case 4:
                        Pregunta4[opcion]++;
                        break;
                        // Opcionalmente, puedes agregar un caso default para manejar errores.
                }
            });

            // Dispara el evento para notificar a los suscriptores que los datos cambiaron.
            // Esto permite que el formulario principal actualice los gráficos o contadores.
            AlActualizar.Invoke();
        }

    }




}
