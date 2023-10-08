using System.Text.Json;
public class AccesoADatosCadetes{
    public List<Cadete> Obtener()
    {
        string? jsonString = File.ReadAllText("./Datos/cadetes.json");
        List<Cadete>? listadoCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
        return listadoCadetes;
    }

    public bool Guardar(List<Cadete> cadetes)
    {
        string datosCadetes = "../Datos/cadetes.json";
        string? formatJson = JsonSerializer.Serialize(cadetes);
        File.WriteAllText(datosCadetes, formatJson);
        return formatJson != null;
    }
}