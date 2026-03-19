namespace SmartCity.Core;

public abstract class SemaforoInteligente : DispositivoIoT
{
    public SemaforoInteligente(int id, bool estado, int bateria) : base(id, estado, bateria)
    {
    }
    
    public void ConectarRed() => Console.WriteLine($"Semáforo {Id} conectado.");
    public void DesconectarRed() => Console.WriteLine($"Semáforo {Id} desconectado.");

    public override void RealizarDiagnostico()
    {
        Console.WriteLine("[Semáforo] ");
        base.RealizarDiagnostico();
    }
}