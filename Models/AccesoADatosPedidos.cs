using System.Text.Json;
public class AccesoADatosPedidos{
    public List<Pedido> Obtener()
    {
        string rutaDeArchivo = "../Datos/pedidos.json";
        List<Pedido> listaPedidos;
        string documento;
        using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            listaPedidos = JsonSerializer.Deserialize<List<Pedido>>(documento);
        }
        return listaPedidos;
    }

    public void Guardar(List<Pedido> pedidos)
    {
        string datosPedidos = "../Datos/pedidos.json";
        string formatJson = JsonSerializer.Serialize(pedidos);
        File.WriteAllText(datosPedidos, formatJson);
    }
}