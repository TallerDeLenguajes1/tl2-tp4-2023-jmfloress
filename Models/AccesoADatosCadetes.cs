using System.Text.Json;
public class AccesoADatosCadetes{
    public List<Cadete> Obtener()
    {
        string rutaDeArchivo = "../Datos/cadetes.json";
        List<Cadete> listaCadetes;
        string documento;
        using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(documento);
        }
        return listaCadetes;
    }
}