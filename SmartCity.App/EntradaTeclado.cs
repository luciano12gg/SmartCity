namespace SmartCity.App;

public class EntradaTeclado
{
    public static int? LeerOpcion(string mensaje, bool ok)
    {
        int numero = 0;
        do
        {
            Console.Write(mensaje);
            string? texto = Console.ReadLine();

            if (string.IsNullOrEmpty(texto))
            {
                Error("no se puede dejar vacio");
                ok = false;
            }
            else
            {
                if (int.TryParse(texto, out numero))
                {
                    if (numero < 0 || numero > 4)
                    {
                        Error("el numero introducido no esta dentro del rango entre 0 y 4");
                        ok = false;
                    }
                    else ok = true;
                }
                else
                {
                    Error("no es un numero");
                    ok = false;
                }
            }
        } while (!ok);
        return numero;
    }
    public static void Error(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine("X Error: " + mensaje);
        Console.ResetColor();
    }
}