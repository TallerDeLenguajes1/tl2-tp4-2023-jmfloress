public class AccesoCSV:AccesoADados
{
    public override List<Cadeteria> AccesoCadeterias(string rutaDeArchivo)
    {
        FileStream MiArchivo = new FileStream(rutaDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);
            string Linea = "";
            List<Cadeteria> cadeterias = new List<Cadeteria>();
            char caracter =',';
            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] fila = Linea.Split(caracter);
                cadeterias.Add(new Cadeteria(fila[0],fila[1]));
            }

            return cadeterias;
    }

    public override List<Cadete> AccesoCadetes(string rutaDeArchivo)
    {
        FileStream MiArchivo = new FileStream(rutaDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);
            string Linea = "";
            List<Cadete> cadetes = new List<Cadete>();
            int contador=1;
            char caracter =',';
            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] fila = Linea.Split(caracter);
                cadetes.Add(new Cadete(contador,fila[0],fila[1],fila[2]));
                contador++;
            }

            return cadetes;
    }
}