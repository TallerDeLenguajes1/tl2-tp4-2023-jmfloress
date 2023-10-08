public enum EstadoPedido
{
    Pendiente,
    EnProceso,
    Completado
}
public class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private EstadoPedido estado;
    private Cadete? cadete;
    
    public Pedido()
    {
        
    }
    public Pedido(int nro, string obs, int estado, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        EstadoPedido aux;
        if (Enum.TryParse<EstadoPedido>($"{estado}", out aux))
            this.estado = aux;
        else
            this.estado = EstadoPedido.Pendiente;
        this.cadete = new Cadete();
    }

    public Pedido(int nro, string obs, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        this.estado = EstadoPedido.Pendiente;
        this.cadete = new Cadete();
    }

    public int Nro { get => nro; set => nro = value; }
    public string? Obs { get => obs; set => obs = value; }
    public Cliente? Cliente { get => cliente; set => cliente = value; }
    public EstadoPedido Estado { get => estado; set => estado = value; }
    public Cadete? Cadete { get => cadete; set => cadete = value; }

    public override string ToString()
    {
        string obj = $"{this.Obs}, {this.Cliente.ToString()}";
        if(this.Cadete != null){
            obj = obj + $", {this.Cadete.ToString()}";
        }
        return obj;
    }
}