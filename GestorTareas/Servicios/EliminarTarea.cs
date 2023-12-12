using Newtonsoft.Json;
using ProbarApp.Observer;

namespace ProbarApp.Servicios
{
    public class EliminarTarea
    {
        public string deleteTask(string taskName)
        {
            string pathUser = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\UsuarioActual.json";
            string user = File.ReadAllText(pathUser);
            Usuarios usuarios = JsonConvert.DeserializeObject<Usuarios>(user);

            try
            {
                if (usuarios.Roll == "Lider")
                {

                    string pathTask = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Task.json";
                    string task = File.ReadAllText(pathTask);

                    List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(task);
                    Tasks tareaElegida = tasks.Find(t => t.TaskName == taskName);

                    if (tareaElegida != null)
                    {
                        tasks.Remove(tareaElegida);
                        File.WriteAllText(pathTask, JsonConvert.SerializeObject(tasks));
                        return "Tarea eliminada";
                    }
                    else
                    {
                        return "La tarea no fue encotrada";
                    }

                }
                else
                {
                    return "No tienes acceso para eliminar tareas";
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
