namespace SmartCity_Hub;

public class DispositivoService
{
    public void MostrarDetalles(List<DispositivoIoT> dispositivos)
    {
        Console.WriteLine("--- DETALLE DE DISPOSITIVOS ---");

        foreach (DispositivoIoT dispositivo in dispositivos)
        {
            dispositivo.RealizarDiagnostico();
        }

        Pausa();
    }

    public void RecargarTodos(List<DispositivoIoT> dispositivos)
    {
        foreach (DispositivoIoT dispositivo in dispositivos)
        {
            dispositivo.RecargarBateria();
        }

        Console.WriteLine("Todas las baterías han sido recargadas.");
        Pausa();
    }

    public void DesconectarDispositivo(List<DispositivoIoT> dispositivos)
    {
        Console.Write("Introduce el ID del dispositivo: ");
        bool parseado = int.TryParse(Console.ReadLine(), out int idBuscado);

        if (!parseado)
        {
            Console.WriteLine("ID no válido.");
            Pausa();
            return;
        }

        DispositivoIoT? encontrado = dispositivos.FirstOrDefault(d => d.Id == idBuscado);

        if (encontrado == null)
        {
            Console.WriteLine("No existe ningún dispositivo con ese ID.");
        }
        else if (encontrado is IConectable conectable)
        {
            conectable.DesconectarRed();
        }
        else
        {
            Console.WriteLine("Este dispositivo no tiene módulo de red.");
        }

        Pausa();
    }

    private void Pausa()
    {
        Console.WriteLine("Pulsa una tecla para continuar...");
        Console.ReadKey();
    }
}