namespace SmartCity.Core;

public class SemaforoInteligente : DispositivoIoT, IConectable
{

    private const int CONSUMO_SEMAFORO = 2;
    public EstadoSemaforo EstadoSemaforo { get; set; }

    public SemaforoInteligente(int id, bool estado, int bateria, EstadoSemaforo estadoSemaforo) : base(id, estado, bateria)
    {
        EstadoSemaforo = estadoSemaforo;
    }
    
    public void ConectarRed() => Console.WriteLine($"Semáforo {Id} conectado.");
    public void DesconectarRed() => Console.WriteLine($"Semáforo {Id} desconectado.");

    public void ActualizarEstado(int hora)
    {
        Estado = (hora >= 6 && hora <= 22);
        
        EstadoSemaforo = EstadoSemaforo switch
        {
            EstadoSemaforo.Verde => EstadoSemaforo.Amarillo,
            EstadoSemaforo.Amarillo => EstadoSemaforo.Rojo,
            EstadoSemaforo.Rojo => EstadoSemaforo.Verde,
            _ => EstadoSemaforo.Rojo
        };
        
        Bateria -= CONSUMO_SEMAFORO;

        if (Bateria <= 0)
        {
            Bateria = 0;
            throw new BateriaAgotadaException($"El semáforo {Id} se ha quedado sin energía.");
        }
    }
    
    public override void RealizarDiagnostico()
    {
        Console.WriteLine($"[Semáforo Inteligente ID: {Id}] Estado: {EstadoSemaforo} | Activo: {(Estado ? "Sí" : "No")} | Batería: {Bateria}%");
    }
}