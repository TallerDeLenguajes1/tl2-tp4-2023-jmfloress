public class DatosCadete
{
    private Cadete cadete;
    private int cantPedidos;
    private float montoGanado;

    public DatosCadete(Cadete cadete, int cantPedidos, float montoGanado)
    {
        this.Cadete = cadete;
        this.CantPedidos = cantPedidos;
        this.MontoGanado = montoGanado;
    }

    public Cadete Cadete { get => cadete; set => cadete = value; }
    public int CantPedidos { get => cantPedidos; set => cantPedidos = value; }
    public float MontoGanado { get => montoGanado; set => montoGanado = value; }
}

public class Informe
{
    private List<DatosCadete> cadetes;
    private int pedidosEnviados;
    private int promedioPedidosEnviados;

    public Informe(List<DatosCadete> cadetes, int pedidosEnviados, int promedioPedidosEnviados)
    {
        this.cadetes = cadetes;
        this.pedidosEnviados = pedidosEnviados;
        this.promedioPedidosEnviados = promedioPedidosEnviados;
    }

    public List<DatosCadete> Cadetes { get => cadetes; }
    public int PedidosEnviados { get => pedidosEnviados; }
    public int PromedioPedidosEnviados { get => promedioPedidosEnviados; }
}