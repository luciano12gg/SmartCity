using System.Text.RegularExpressions;

namespace SmartCity.Core;


public static class ValidadorRed
{
    public static bool EsMacValida(string mac)
    {
        string patron = @"^([0-9A-Fa-f]{2}:){5}[0-9A-Fa-f]{2}$";
        return Regex.IsMatch(mac, patron);
    }
}
