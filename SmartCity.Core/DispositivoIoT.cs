namespace SmartCity.Core;

public abstract class DispositivoIoT
{
    public abstract int Id { get; set; }
    public abstract bool Estado { get; set; }
    public abstract int Bateria { get; set; }

    public DispositivoIoT(int id, bool estado, int bateria)
    {
        this.Id = id;
        this.Estado = estado;
        this.Bateria = bateria;
    }

    public virtual void RealizarDiagnostico()
    {
        Console.WriteLine($"[ID: {Id} Estado: {(Estado ? "Encendido" : "Apagado")} Bateria: {Bateria:P0}]");
    }
}