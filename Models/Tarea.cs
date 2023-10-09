public enum EstadoTarea{
    Pendiente,
    EnProgreso,
    Completada
}

namespace webApiTareas
{
    public class Tarea
    {
        private int id;
        private string titulo;
        private string desc;
        private EstadoTarea estado;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Desc { get => desc; set => desc = value; }
        public EstadoTarea Estado { get => estado; set => estado = value; }
    }
}