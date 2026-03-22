using SmartCity.Core;

namespace SmartCity.App;

public class Menu
{
    private readonly EntradaTeclado _entradaTeclado;
    private readonly MostrarMenu _mostrarMenu;
    private readonly Temporizador _temporizador;
    private readonly Utilidades _utilidades;

    private List<DispositivoIoT> dispositivos;
    private DispositivoIoT[,] mapaCiudad;
    private int horaActual;
    private bool salir;

    public Menu()
    {
        _entradaTeclado = new EntradaTeclado();
        _mostrarMenu = new MostrarMenu();
        _temporizador = new Temporizador();
        _utilidades = new Utilidades();

        horaActual = 8;
        salir = false;

        dispositivos = InicializarDispositivos();
        mapaCiudad = InicializarMapa(dispositivos);
    }

    public void Ejecutar()
    {
        int? opcion;
        bool ok = false;
        do
        {
            Console.Clear();
            _mostrarMenu.MostrarPanel(horaActual, mapaCiudad);

            opcion = EntradaTeclado.LeerOpcion("elige opcion: ", ok);

            switch (opcion)
            {
                case 1:
                    _utilidades.MostrarDetalles(dispositivos);
                    break;

                case 2:
                    _temporizador.AvanzarHora(dispositivos, ref horaActual);
                    break;

                case 3:
                    _utilidades.RecargarTodos(dispositivos);
                    break;

                case 4:
                    _utilidades.DesconectarDispositivo(dispositivos);
                    break;

                case 0:
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    Pausa();
                    break;
            }

        } while (!salir);
    }

    private List<DispositivoIoT> InicializarDispositivos()
    {
        return new List<DispositivoIoT>
        {
            new SemaforoInteligente(1, true, 100, EstadoSemaforo.Verde),
            new SensorClima(2, true, 100, 20.0),
            new FarolaSolar(3, false, 100),
            new FarolaSolar(4, false, 100),
            new SemaforoInteligente(5, true, 100, EstadoSemaforo.Rojo),
            new SensorClima(6, true, 100,22.0),
            new SemaforoInteligente(7, true, 100, EstadoSemaforo.Amarillo),
            new FarolaSolar(8, false, 100),
            new SemaforoInteligente(9, true, 100, EstadoSemaforo.Verde)
        };
    }

    private DispositivoIoT[,] InicializarMapa(List<DispositivoIoT> dispositivos)
    {
        DispositivoIoT[,] mapa = new DispositivoIoT[3, 3];

        int index = 0;
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                mapa[fila, columna] = dispositivos[index];
                index++;
            }
        }

        return mapa;
    }

    private void Pausa()
    {
        Console.WriteLine("Pulsa una tecla para continuar...");
        Console.ReadKey();
    }
}