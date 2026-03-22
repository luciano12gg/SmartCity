namespace SmartCity_Hub;

public class SmartCityApp
{
    private readonly MenuService menuService;
    private readonly DashboardService dashboardService;
    private readonly SimuladorService simuladorService;
    private readonly DispositivoService dispositivoService;

    private List<DispositivoIoT> dispositivos;
    private DispositivoIoT[,] mapaCiudad;
    private int horaActual;
    private bool salir;

    public SmartCityApp()
    {
        menuService = new MenuService();
        dashboardService = new DashboardService();
        simuladorService = new SimuladorService();
        dispositivoService = new DispositivoService();

        horaActual = 8;
        salir = false;

        dispositivos = InicializarDispositivos();
        mapaCiudad = InicializarMapa(dispositivos);
    }

    public void Ejecutar()
    {
        while (!salir)
        {
            Console.Clear();
            dashboardService.MostrarPanel(horaActual, mapaCiudad);

            string opcion = menuService.LeerOpcion();

            switch (opcion)
            {
                case "1":
                    dispositivoService.MostrarDetalles(dispositivos);
                    break;

                case "2":
                    simuladorService.AvanzarHora(dispositivos, ref horaActual);
                    break;

                case "3":
                    dispositivoService.RecargarTodos(dispositivos);
                    break;

                case "4":
                    dispositivoService.DesconectarDispositivo(dispositivos);
                    break;

                case "0":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    Pausa();
                    break;
            }
        }
    }

    private List<DispositivoIoT> InicializarDispositivos()
    {
        return new List<DispositivoIoT>
        {
            new SemaforoInteligente(1, true, 100, EstadoSemaforo.Verde),
            new SensorClima(2, true, 100),
            new FarolaSolar(3, false, 100),
            new FarolaSolar(4, false, 100),
            new SemaforoInteligente(5, true, 100, EstadoSemaforo.Rojo),
            new SensorClima(6, true, 100),
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