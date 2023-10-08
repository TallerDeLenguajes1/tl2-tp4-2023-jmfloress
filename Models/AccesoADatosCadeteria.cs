using System.Text.Json;
public class AccesoADatosCadeteria{
    public Cadeteria Obtener()
    {
        string rutaDeArchivo = "../Datos/cadeterias.json";
        List<Cadeteria> listaCadeterias;
        string documento;
        using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            listaCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(documento);
        }
        Cadeteria aux;
        Random random = new Random();
        aux = listaCadeterias[random.Next(0, listaCadeterias.Count())];
        return aux;
    }
}