namespace webApiTareas
{
    public class ManejoTareas
    {
        private DataAccessTareas dataAccessTareas;
        
        public ManejoTareas(DataAccessTareas dataAccess)
        {
            this.dataAccessTareas = dataAccess;
        }

        public Tarea AgregarTarea(Tarea tarea)
        {
            var tareas = dataAccessTareas.Obtener();
            tareas.Add(tarea);
            tarea.Id = (tareas == null || tareas.Count == 0) ? 1 : tareas.Max(t => t.Id) + 1;
            dataAccessTareas.Guardar(tareas);
            return tarea;
        }

        public Tarea GetTarea(int idTarea)
        {
            var tareas = dataAccessTareas.Obtener();
            Tarea aux = tareas.FirstOrDefault(t => t.Id == idTarea);
            return (aux != null) ? aux : null;
        }

        public Tarea ModifyTarea(Tarea tarea, int idTarea)
        {
            var tareas = dataAccessTareas.Obtener();
            Tarea aux = tareas.FirstOrDefault(t => t.Id == idTarea);
            if (aux != null)
            {
                aux.Titulo = tarea.Titulo;
                aux.Desc = tarea.Desc;
                aux.Estado = tarea.Estado;
                dataAccessTareas.Guardar(tareas);
                return aux;
            }
            return null;
        }

        public Tarea DeleteTarea(int idTarea)
        {
            var tareas = dataAccessTareas.Obtener();
            Tarea aux = tareas.FirstOrDefault(t => t.Id == idTarea);
            if (aux != null)
            {
                tareas.Remove(aux);
                dataAccessTareas.Guardar(tareas);
                return aux;
            }
            return null;
        }

        public List<Tarea> GetTareas()
        {
            var tareas = dataAccessTareas.Obtener();
            return (tareas.Count != 0) ? tareas : null;
        }

        public List <Tarea> GetTareasCompletadas()
        {
            var tareas = dataAccessTareas.Obtener();
            List<Tarea> tareasCompletadas = tareas.Where(t => t.Estado == EstadoTarea.Completada).ToList();
            return (tareasCompletadas.Count != 0) ? tareasCompletadas : null;
        }
    }
}