using System.Text.Json;

public class Cadeteria
{
    const int PRECIO_PEDIDO = 500;
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadete;
    private List<Pedido> listadoPedido;
    private AccesoADatosCadetes datosCadetes;
    private AccesoADatosPedidos datosPedidos;
    private static Cadeteria? cadeteriaSingleton;

    public static Cadeteria GetCadeteriaSingleton(){
        if(cadeteriaSingleton == null)
        {
            AccesoADatosCadeteria helperCadeteria = new AccesoADatosCadeteria();
            cadeteriaSingleton =helperCadeteria.Obtener();
            cadeteriaSingleton.datosCadetes = new AccesoADatosCadetes();
            cadeteriaSingleton.datosPedidos = new AccesoADatosPedidos();
            cadeteriaSingleton.listadoCadete = cadeteriaSingleton.datosCadetes.Obtener();
            cadeteriaSingleton.listadoPedido = cadeteriaSingleton.datosPedidos.Obtener();
        }
        return cadeteriaSingleton;
    }

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadete = new List<Cadete>();
        this.listadoPedido = new List<Pedido>();
    }
   
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadete { get => listadoCadete; }
    public List<Pedido> ListadoPedido { get => listadoPedido; }

    public override string ToString()
    {
        string obj = $"{this.Nombre} - Telefono: {this.Telefono}";
        return obj;
    }
    //Pedido
    public bool AltaPedido(Pedido pedido)
    {
        bool resultado = true;
        this.ListadoPedido.Add(pedido);
        if (datosPedidos.Guardar(this.ListadoPedido))
        {
            return resultado;
        }
        ListadoPedido.Remove(pedido);
        return !resultado;
    }

    public bool BorrarPedido(int nro)
    {
        bool resultado = true;
        Pedido? pedido = ListadoPedido.SingleOrDefault(p => p.Nro == nro);
        if(pedido != null){
            ListadoPedido.Remove(pedido);
            if(datosPedidos.Guardar(this.ListadoPedido))
                return resultado;
            ListadoPedido.Add(pedido);
        }
        return !resultado;
    }

    public bool ModificarPedido(int nro, string obs, string nombre, string direccion, string telefono, string datosReferenciaDireccion){
        bool resultado = true;
        Pedido? pedido = ListadoPedido.SingleOrDefault(p => p.Nro == nro);
        if(pedido != null){
            pedido.Obs = obs;
            pedido.Cliente.Nombre = nombre;
            pedido.Cliente.Direccion = direccion;
            pedido.Cliente.Telefono = telefono;
            pedido.Cliente.DatosReferenciaDireccion = datosReferenciaDireccion;
            datosPedidos.Guardar(this.ListadoPedido);
            return resultado;
        }
        return !resultado;
    }

    public bool AsignarCadeteAPedido(int nroPedido, int idCadete)
    {
        bool resultado = true;
        Pedido? pedido = ListadoPedido.SingleOrDefault(p => p.Nro == nroPedido);
        Cadete? cadete = ListadoCadete.SingleOrDefault(c => c.Id == idCadete);
        if(pedido != null && cadete != null){
            pedido.Cadete = cadete;
            datosPedidos.Guardar(this.ListadoPedido);
            return resultado;
        }
        return !resultado;
    }

    public bool CambiarEstadoPedido(int nro, int nuevoEstado){
        bool resultado = true;
        Pedido? pedido = ListadoPedido.SingleOrDefault(p => p.Nro == nro);
        if(pedido != null && pedido.Estado != EstadoPedido.Completado){
            EstadoPedido aux;
            if(Enum.TryParse<EstadoPedido>($"{nuevoEstado}", out aux)){
                pedido.Estado = aux;
                datosPedidos.Guardar(this.ListadoPedido);
                return resultado;
            } 
        }
        return !resultado;
    }

    public Pedido GetPedido(int nroPedido)
    {
        return ListadoPedido.SingleOrDefault(p => p.Nro == nroPedido);
    }
    //Cadete
    public bool AltaCadete(Cadete cadete)
    {
        bool resultado = true;
        this.ListadoCadete.Add(cadete);
        if (ListadoCadete.SingleOrDefault(c => c.Id == cadete.Id) != null)
        {
            datosCadetes.Guardar(this.ListadoCadete);
            return resultado;
        }
        return !resultado;
    }
    public Cadete GetCadete(int idCadete){
        return ListadoCadete.SingleOrDefault(c => c.Id == idCadete);
    }
    public List<Pedido> ListarPedidoPorCadete(int idCadete)
    {
        List<Pedido> lista = listadoPedido.Where(pedido => pedido.Cadete.Id == idCadete).ToList();
        return lista.ToList();
    }
    public int CantPedidosEntregadosPorCadete(int idCadete){
        List<Pedido> lista = listadoPedido.Where(pedido => pedido.Cadete.Id == idCadete && pedido.Estado ==EstadoPedido.Completado).ToList();
        return lista.Count();
    }

    public float JornalACobrar(int idCadete){
        return CantPedidosEntregadosPorCadete(idCadete) * PRECIO_PEDIDO;
    }

    public Informe GetInforme(){
        List<DatosCadete> cadetes = new List<DatosCadete>();
        int totalPedidosEnviados = 0;
        foreach (Cadete item in ListadoCadete)
        {
            int pedidosPorCadete = CantPedidosEntregadosPorCadete(item.Id);
            float montoPorCadete = pedidosPorCadete * PRECIO_PEDIDO;
            DatosCadete aux = new DatosCadete(item, pedidosPorCadete, montoPorCadete);
            cadetes.Add(aux);
            totalPedidosEnviados = totalPedidosEnviados + pedidosPorCadete;
        }
        int promedioPedidosEnviados = totalPedidosEnviados / ListadoCadete.Count();
        return new Informe(cadetes, totalPedidosEnviados, promedioPedidosEnviados);
    }
}