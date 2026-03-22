namespace SmartCity.Core;

public class FarolaSolar : DispositivoIoT
{
    private const int CONSUMO_FAROLA = 1;

    public FarolaSolar(int id, bool estado, int bateria) : base(id, estado, bateria)
    {
        
    }
    public void ActualizarEstado(int hora)
    {
        if (hora > 18 || hora < 7)
        {
            Estado = true; // Se enciende si es de noche 
            Bateria -= CONSUMO_FAROLA; 
        }
        else
        {
            Estado = false;
        }

        if (Bateria < 0)
        {
            Bateria = 0;
            throw new BateriaAgotadaException($"La Farola {Id} se ha quedado sin energía.");
        }
    }
    public override void RealizarDiagnostico()
    {
        string estadoLuz = Estado ? "Encendida (Noche)" : "Apagada (Día)";
        Console.WriteLine($"[Farola Solar ID: {Id}] Estado: {Estado} | Batería: {Bateria}%");
    }
}