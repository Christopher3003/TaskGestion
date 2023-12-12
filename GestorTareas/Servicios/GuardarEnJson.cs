using Newtonsoft.Json;
using ProbarApp.Observer;

namespace ProbarApp.Servicios
{
    public class GuardarEnJson
    {
        public string SetInJson()
        {
            try
            {
                string path = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Task.json";
                string file = File.ReadAllText(path);
                Tasks tareas = new Tasks();
                File.AppendAllText(path, JsonConvert.SerializeObject(tareas));

                return "Added";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
