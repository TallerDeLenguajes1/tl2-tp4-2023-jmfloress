using System.Text.Json;

public class AccesoJSON:AccesoADados
{
    public override List<Cadeteria> AccesoCadeterias(string rutaDeArchivo)
    {
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
            return listaCadeterias;
    }

    public override List<Cadete> AccesoCadetes(string rutaDeArchivo)
    {
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