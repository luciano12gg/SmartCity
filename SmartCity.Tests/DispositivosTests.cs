using SmartCity.Core;

namespace SmartCity.Tests;

public class DispositivosTests
{
    [Fact]
    public void RecargarBateria_DeberiaPonerBateriaA100()
    {
        // Arrange
        var sensor = new SensorClima(1, true, 35,40);

        // Act
        sensor.RecargarBateria();

        // Assert
        Assert.Equal(100, sensor.Bateria);
    }

    [Fact]
    public void SensorClima_TomarLectura_DeberiaReducirBateriaEnUno()
    {
        // Arrange
        var sensor = new SensorClima(3, true, 50,50);
        int bateriaInicial = sensor.Bateria;

        // Act
        sensor.TomarLectura();

        // Assert
        Assert.Equal(bateriaInicial - 1, sensor.Bateria);
    }

    [Fact]
    public void SensorClima_TomarLectura_DeberiaActualizarUltimaLectura()
    {
        // Arrange
        var sensor = new SensorClima(4, true, 80,50);
        DatosClima lecturaAnterior = sensor.UltimaLectura;

        // Act
        sensor.TomarLectura();

        // Assert
        Assert.NotEqual(lecturaAnterior, sensor.UltimaLectura);
    }

    [Fact]
    public void SensorClima_TomarLectura_ConBateriaCero_DeberiaLanzarExcepcion()
    {
        // Arrange
        var sensor = new SensorClima(5, true, 0,50);

        // Act & Assert
        Assert.Throws<BateriaAgotadaException>(() => sensor.TomarLectura());
    }

    [Fact]
    public void FarolaSolar_ActualizarEstado_DeNoche_DeberiaEncenderseYConsumirBateria()
    {
        // Arrange
        var farola = new FarolaSolar(6, false, 40);

        // Act
        farola.ActualizarEstado(22);

        // Assert
        Assert.True(farola.Estado);
        Assert.Equal(39, farola.Bateria);
    }

    [Fact]
    public void SemaforoInteligente_ActualizarEstado_DeberiaCambiarColorYConsumirBateria()
    {
        // Arrange
        var semaforo = new SemaforoInteligente(7, true, 60, EstadoSemaforo.Verde);

        // Act
        semaforo.ActualizarEstado(12);

        // Assert
        Assert.Equal(EstadoSemaforo.Amarillo, semaforo.EstadoSemaforo);
        Assert.Equal(58, semaforo.Bateria);
        Assert.True(semaforo.Estado);
    }
}