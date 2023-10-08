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
    private Cadete cadete;

    public Pedido(int nro, string obs, EstadoPedido estado, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        this.estado = estado;
        this.cadete = new Cadete();
    }

    public int Nro { get => nro; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; }
    public EstadoPedido Estado { get => estado; set => estado = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }

    public override string ToString()
    {
        string obj = $"{this.obs}, {this.cliente.ToString()}";
        if(this.cadete != null){
            obj = obj + $", {this.cadete.ToString()}";
        }
        return obj;
    }

}