using Newtonsoft.Json;
using ProbarApp.Observer;

namespace ProbarApp.Servicios
{
    public class FollowTask
    {
        public string follow(string taskname)
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
                        Tasks taskBuscar = tasks.Find(t => t.TaskName == taskname);

                        Usuarios usuarios = JsonConvert.DeserializeObject<Usuarios>(userList);

                        if (taskBuscar != null)
                        {
                            taskBuscar.Attash(usuarios);

                            File.WriteAllText(pathtask, JsonConvert.SerializeObject(tasks, Formatting.Indented));
                            return "Tarea seguida";
                        }
                        else
                        {
                            return "Hay problema";
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }

                }
                else
                {
                    return "No tienes acceso a seguir la tarea";
                }  

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
