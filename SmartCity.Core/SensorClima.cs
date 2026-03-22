namespace SmartCity.Core;

public class SensorClima : DispositivoIoT
{
    public DatosClima UltimaLectura { get; private set; }
    private ProcesadorDatos<DatosClima> procesador = new ProcesadorDatos<DatosClima>();
    
    public SensorClima(int id, bool estado, int bateria, double temperatura) : base(id, estado, bateria)
    {
        UltimaLectura = new DatosClima(20.0, 50.0, DateTime.Now);
    }

    public void TomarLectura()
    {
        Random r = new Random();
        double nuevaTemp = r.NextDouble() * (35 - 10) + 10;
        double nuevaHum = r.NextDouble() * 100;
        
        procesador.EncolarDato(UltimaLectura);
        
        UltimaLectura = new DatosClima(nuevaTemp, nuevaHum, DateTime.Now);

        Bateria -= 1;

        if (Bateria < 0)
        {
            
            throw new BateriaAgotadaException($"[ALERTA] El sensor de clima {this.Id} se ha quedad sin batería.");
        }
    }

    public override void RealizarDiagnostico()
    {
        Console.WriteLine("[Sensor Clima] ");
        Console.WriteLine($"ID: {this.Id} | Temp: {UltimaLectura.Temperatura:F2}ºC | Hum: {UltimaLectura.Humedad:F0}% | Batería: {Bateria}");
    }
}