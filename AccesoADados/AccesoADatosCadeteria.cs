using System.Text.Json;
public class AccesoADatosCadeteria{
    public Cadeteria Obtener()
    {
        Random random = new Random();
        string? jsonString = File.ReadAllText("./Datos/cadeterias.json");
        List<Cadeteria>? listadoCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(jsonString);
        return listadoCadeterias[random.Next(0, 3)];
    }
}