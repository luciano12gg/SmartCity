using System.Diagnostics;

namespace SmartCity.Core;

public class ProcesadorDatos<T>
{
    private Queue<T> colaDatos = new Queue<T>();
        
    public void EncolarDato(T dato)
    {
        Debug.Assert(dato != null, "El dato nunca debe ser nulo.");
        colaDatos.Enqueue(dato);
    } 
    public void ProcesarTodo()
    {
        while (colaDatos.Count > 0)
        {
            T dato = colaDatos.Dequeue();
            Console.WriteLine($"Procesando dato de tipo: {typeof(T).Name} -> {dato}");
        }
    }
}