namespace SmartCity.Core;

public class BateriaAgotada : Exception
{
    public BateriaAgotada() : base("La batería se ha agotado.") { }

    public BateriaAgotada(string mensaje) : base(mensaje) { }
}