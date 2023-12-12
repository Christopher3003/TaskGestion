using Newtonsoft.Json;
using ProbarApp.Observer;

namespace ProbarApp.Servicios
{
    public class UnFollowTask
    {
        public string unFollow(string taskName)
        {
            string path = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\UsuarioActual.json";
            string jsonContent = File.ReadAllText(path);
            Usuarios users = JsonConvert.DeserializeObject<Usuarios>(jsonContent);
            try
            {
                users = JsonConvert.DeserializeObject<Usuarios>(jsonContent);

                if (users.Roll == "Desarrollador")
                {
                    string pathtask = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Task.json";
                    string pathUserAct = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\UsuarioActual.json";

                    try
                    {
                        string taskList = File.ReadAllText(pathtask);
                        string userList = File.ReadAllText(pathUserAct);

                        List<Tasks> tasks = JsonConvert.DeserializeObject<List<Tasks>>(taskList);
                        Tasks taskBuscar = tasks.Find(t => t.TaskName == taskName);

                        Usuarios usuarios = JsonConvert.DeserializeObject<Usuarios>(userList);

                        if (taskBuscar != null)
                        {
                            taskBuscar.observers.Remove(usuarios);
                            File.WriteAllText(pathtask, JsonConvert.SerializeObject(tasks));
                            return "Hecha";
                        }
                        else
                        {
                            return "Tarea no encontrada";
                        }
                    }catch (Exception ex)
                    {
                        return ex.Message;
                    }
                   

                }
                else
                {
                    return "No tienes acceso a esta accion";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
