using Newtonsoft.Json;
using ProbarApp.Observer;

namespace ProbarApp.Servicios
{
    public class BuscarTarea
    {
        public Tasks FindTask(string TaskName)
        {
            string path = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Task.json";
            try
            {
                string tasks = File.ReadAllText(path);
                List<Tasks> task = JsonConvert.DeserializeObject<List<Tasks>>(tasks);
                Tasks t = task.Find(t=>t.TaskName==TaskName);
                return t;

            }catch (Exception ex)
            {
            }
            return null;
        }
    }
}
