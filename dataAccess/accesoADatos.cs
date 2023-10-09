namespace webApiTareas
{
    using System.Text.Json;

    public class DataAccessTareas
    {
        public List<Tarea> Obtener()
        {
            if (File.Exists("TareasData.json"))
            {
                string json = File.ReadAllText("TareasData.json");
                List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(json);
                return tareas;
            }
            return new List<Tarea>();
        }

        public void Guardar(List<Tarea> tareas)
        {
            if(File.Exists("TareasData.json"))
            {
                using (File.Create("TareasData.json")) {}
            }
            string json = JsonSerializer.Serialize(tareas);
            File.WriteAllText("TareasData.json", json);
        }
    }
}