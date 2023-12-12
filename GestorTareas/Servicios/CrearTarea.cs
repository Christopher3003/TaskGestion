using Newtonsoft.Json;
using ProbarApp.Observer;
using System.Threading;

namespace ProbarApp.Servicios
{
    public class CrearTarea
    {
        public string createTask(string nombreTarea, string descripcion, string asignedTo)
        {
            string path = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\UsuarioActual.json";
            string jsonContent = File.ReadAllText(path);
            Usuarios users;
            try
            {
                users = JsonConvert.DeserializeObject<Usuarios>(jsonContent);



                if (users.Roll == "Lider")
                {
                    string filePath = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Task.json";
                    string jsonCont = File.ReadAllText(filePath);
                    List<Tasks> tareas = JsonConvert.DeserializeObject<List<Tasks>>(jsonCont);

                    if (tareas != null)
                    {
                        Tasks task = new Tasks
                        {

                            TaskName = nombreTarea,
                            TaskDescription = descripcion,
                            AssignedTo = asignedTo

                        };

                        tareas.Add(task);
                        string updatedJson = JsonConvert.SerializeObject(tareas);
                        File.WriteAllText(filePath, updatedJson);

                        return "Tarea creada";
                    }
                    else
                    {
                        return "No se pudo asignar";

                    }
                }
                else
                {
                    return "Lo siento, no tienes acceso a agregar tareas";
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
