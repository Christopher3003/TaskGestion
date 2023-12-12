using Newtonsoft.Json;
using ProbarApp.Observer;

namespace ProbarApp.Servicios
{
    public class Login
    {
        public string login(string username, string password)
        {
            try
            {
                string rutaDevs = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Usuarios.json";
                string rutaSerializarDevs = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\UsuarioActual.json";
                string json = File.ReadAllText(rutaDevs);
                List<Usuarios> _developers = JsonConvert.DeserializeObject<List<Usuarios>>(json);

                Usuarios usuarioActual = _developers.Find(u => u.NombreUsuario == username && u.password == password);


                if (usuarioActual != null)
                {
                    string rol = usuarioActual.Roll;
                    Usuarios userList = new Usuarios
                    {
                        NombreUsuario = username,
                        password = usuarioActual.password,
                        Email = usuarioActual.Email,
                        Roll = rol
                    };

                    string serializado = JsonConvert.SerializeObject(userList);
                    File.WriteAllText(rutaSerializarDevs, serializado);
                    return "Sesion Iniciada";

                }
                else
                {
                    return "Usuario o password incorrectos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
