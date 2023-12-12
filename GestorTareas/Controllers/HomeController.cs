using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProbarApp.Observer;
using ProbarApp.Servicios;

namespace ProbarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly Login login;
        private readonly FollowTask followTask;
        private readonly CrearTarea crearTarea;
        private readonly UnFollowTask unFollowTask;
        private readonly EliminarTarea eliminarTarea;
        private readonly BuscarTarea buscarTarea;
        private readonly Tasks tasks;

        public HomeController(Login login, FollowTask followTask, CrearTarea crearTarea, EliminarTarea eliminarTarea, BuscarTarea buscarTarea, UnFollowTask unFollowTask, Tasks tasks)
        {
            this.login = login;
            this.followTask = followTask;
            this.crearTarea = crearTarea;
            this.eliminarTarea = eliminarTarea;
            this.buscarTarea = buscarTarea;
            this.unFollowTask = unFollowTask;
            this.tasks = tasks;
        }

        [HttpPost("Iniciar Sesion")]
        public string iniciarSesion(string userName, string password)
        {
            return login.login(userName, password);
        }

        [HttpGet("Seguir Tarea")]
        public string SeguirTarea(string taskName)
        {
            return followTask.follow(taskName);
        }

        [HttpGet("Crear Tarea")]
        public string createTask(string taskname, string descripcion, string asignedTo)
        {
            return crearTarea.createTask(taskname, descripcion, asignedTo);
        }

        [HttpGet("Eliminar Tarea")]
        public string deleteTask(string Tname)
        {
            return eliminarTarea.deleteTask(Tname);
        }

        [HttpGet("Buscar Tarea")]
        public IActionResult BuscarTask(string taskName)
        {
            return Ok(buscarTarea.FindTask(taskName));
        }

        [HttpGet("Dejar de Seguir")]
        public string dejarSeguir(string taskName)
        {
            return unFollowTask.unFollow(taskName);
        }

        [HttpGet("Asignar tarea")]
        public string asignarTask(string taskName, string nombreAsignado)
        {
            return tasks.Asignar(taskName, nombreAsignado);
        }
    }
}
