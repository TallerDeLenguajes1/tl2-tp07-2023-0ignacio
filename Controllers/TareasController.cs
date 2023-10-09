using Microsoft.AspNetCore.Mvc;
using webApiTareas;
namespace tl2_tp07_2023_0ignacio.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private readonly ILogger<TareasController> _logger;
    private ManejoTareas manejoTareas;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        var accesoDatos = new DataAccessTareas();
        manejoTareas = new ManejoTareas(accesoDatos);
    }

    [HttpPost("CrearTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        var nuevaTarea = manejoTareas.AgregarTarea(tarea);
        return Created("La tarea se creo", nuevaTarea);
    }

    [HttpGet("GetTareaId")]
    public ActionResult<Tarea> GetTareaId(int idTarea)
    {
        var tareaABuscar = manejoTareas.GetTarea(idTarea);
        return (tareaABuscar == null) ? NotFound("No se encontro una tarea con ese ID"): Ok(tareaABuscar);
    }

    [HttpPut("ModidificarTarea")]
    public ActionResult<Tarea> ModidificarTarea(Tarea tarea, int idTarea)
    {
        var tareaAModificar = manejoTareas.ModifyTarea(tarea, idTarea);
        return (tareaAModificar == null) ? BadRequest("Solicitud de modificaion incorrecta, no se encontro una tarea con el ID proporcionado") : Ok(tareaAModificar);
    }

    [HttpDelete("EliminarTarea")]
    public ActionResult<Tarea> EliminarTarea(int idTarea)
    {
        var tareaAEliminar = manejoTareas.DeleteTarea(idTarea);
        return (tareaAEliminar == null) ? BadRequest("Solicitud de eliminacion incorrecta, no se encontro una tarea con el ID proporcionado") : NoContent();
    }

    [HttpGet("ObtenerTareas")]
    public ActionResult<List<Tarea>> ObtenerTareas()
    {
        var tareas = manejoTareas.GetTareas();
        return (tareas == null) ? NotFound("No se encontro una tarea con el ID proporcionado") : Ok(tareas);
    }

    [HttpGet("ObtenerTareasCompletadas")]
    public ActionResult<List<Tarea>> ObtenerTareasCompletadas()
    {
        var tareasCompletadas = manejoTareas.GetTareasCompletadas();
        return (tareasCompletadas == null) ? NotFound("No se encontraron tareas con el estado 'Completada'") : Ok(tareasCompletadas);
    }
}