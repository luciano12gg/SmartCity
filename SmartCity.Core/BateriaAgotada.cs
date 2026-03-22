namespace SmartCity.Core;

public class BateriaAgotadaException : Exception
{
    public BateriaAgotadaException() : base("La batería se ha agotado.") { }

    public BateriaAgotadaException(string mensaje) : base(mensaje) { }
}