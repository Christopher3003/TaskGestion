using Newtonsoft.Json;
using ProbarApp.Servicios;

namespace ProbarApp.Observer
{
    public class Tasks:ITasks
    {
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public string? AssignedTo { get; set; }

        public List<Usuarios> observers = new List<Usuarios>();
        
        public void Attash(Usuarios observer)
        {
            observers.Add(observer);
        }
        public void Detash(Usuarios observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach(var item in observers)
            {
                item.Update();
            }
        }

        public string Asignar(string taskName, string nombreAsignado)
        {
            string path = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\UsuarioActual.json";
            string jsonContent = File.ReadAllText(path);
            Usuarios users = JsonConvert.DeserializeObject<Usuarios>(jsonContent);
            try
            {
                users = JsonConvert.DeserializeObject<Usuarios>(jsonContent);

                if (users.Roll == "Lider")
                {
                    string filePath = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Task.json";

                    string jsonCont = File.ReadAllText(filePath);
                    List<Tasks> tareas = JsonConvert.DeserializeObject<List<Tasks>>(jsonCont);
                    Tasks tarea = tareas.Find(t => t.TaskName == taskName);

                    if (tarea != null)
                    {
                        tarea.AssignedTo = nombreAsignado;
                        string updatedJson = JsonConvert.SerializeObject(tareas, Formatting.Indented);
                        File.WriteAllText(filePath, updatedJson);
                        tarea.Notify();

                        return "Asignada";
                    }
                    else
                    {
                        return "No se encontro la tarea";
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
