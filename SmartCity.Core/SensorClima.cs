namespace SmartCity.Core;

public abstract class SensorClima : DispositivoIoT
{
    public DatosClima UltimaLectura { get; private set; }
    public double Temperatura { get; set; }
    
    public SensorClima(int id, bool estado, int bateria, double temperatura) : base(id, estado, bateria)
    {
        this.Temperatura = temperatura;
        this.UltimaLectura = new DatosClima(20.0, 50.0, DateTime.Now);
    }

    public void TomarLectura()
    {
        Random r = new Random();
        double nuevaTemp = r.NextDouble() * (35 - 10) + 0;
        double nuevaHum = r.NextDouble() * 100;
        
        this.UltimaLectura = new DatosClima(nuevaTemp, nuevaHum, DateTime.Now);

        this.Bateria -= 1;

        if (this.Bateria < 0)
        {
            this.Bateria = 0;
            throw new BateriaAgotada($"[ALERTA] El sensor de clima {this.Id} se ha quedad sin batería.");
        }
    }

    public override void RealizarDiagnostico()
    {
        Console.WriteLine("[Sensor Clima] ");
        Console.WriteLine($"ID: {this.Id} | Temp: {UltimaLectura.Temperatura:F2}ºC | Hum: {UltimaLectura.Humedad:F0}% | Batería: {Bateria:P0}");
    }
}