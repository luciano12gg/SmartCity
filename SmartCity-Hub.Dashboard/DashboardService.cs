namespace SmartCity_Hub;

public class DashboardService
{
    public void MostrarPanel(int horaActual, DispositivoIoT[,] mapaCiudad)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("🏙️ SMARTCITY HUB - PANEL CENTRAL 🏙️");
        Console.WriteLine("==================================================");
        Console.WriteLine($"Hora actual de la simulación: {horaActual:00}:00");
        Console.WriteLine("ESTADO DE LA RED (Sectores 3x3):");

        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                Console.Write(FormatearDispositivo(mapaCiudad[fila, columna]) + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("OPCIONES:");
        Console.WriteLine("1. Ver detalle de todos los dispositivos");
        Console.WriteLine("2. Avanzar simulación (1 hora)");
        Console.WriteLine("3. Forzar mantenimiento (Recargar baterías)");
        Console.WriteLine("4. Desconectar red de un dispositivo");
        Console.WriteLine("0. Salir del Hub");
        Console.WriteLine("==================================================");
    }

    private string FormatearDispositivo(DispositivoIoT dispositivo)
    {
        if (dispositivo is SemaforoInteligente semaforo)
        {
            return $"[ SEMA: {semaforo.EstadoSemaforo} ]";
        }

        if (dispositivo is SensorClima sensor)
        {
            return sensor.Bateria > 20 ? "[ CLIM: OK ]" : "[ CLIM: WRN ]";
        }

        if (dispositivo is FarolaSolar farola)
        {
            return farola.Estado ? "[ FARO: ON ]" : "[ FARO: OFF ]";
        }

        return "[ ---- ]";
    }
}