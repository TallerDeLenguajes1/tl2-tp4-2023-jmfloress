using System.Text.Json;
public class AccesoADatosPedidos{
    public List<Pedido> Obtener()
    {
        string? jsonString = File.ReadAllText("./Datos/pedidos.json");
        List<Pedido>? listadoPedidos = JsonSerializer.Deserialize<List<Pedido>>(jsonString);
        return listadoPedidos;
    }

    public bool Guardar(List<Pedido> pedidos)
    {
        string datosPedidos = "../Datos/pedidos.json";
        string? formatJson = JsonSerializer.Serialize(pedidos);
        File.WriteAllText(datosPedidos, formatJson);
        return formatJson != null;
    }
}