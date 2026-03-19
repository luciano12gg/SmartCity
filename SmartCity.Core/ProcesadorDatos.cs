using System.Diagnostics;

namespace SmartCity.Core;

public class ProcesadorDatos<T>
{
    public void Procesar(T datos)
    {
        Debug.Assert(datos != null, "El dato nunca debe ser nulo.");
        
        Console.WriteLine($"Procesando dato de tipo: {typeof(T).Name}");
    }
}