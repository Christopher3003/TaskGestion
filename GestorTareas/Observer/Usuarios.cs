using System.Net.Mail;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ProbarApp.Observer
{
    public class Usuarios:IObserver
    {
        public string NombreUsuario { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public string Roll { get; set; }

        public void Update()
        {

            string pathUsuariosSiguiendo = @"C:\Users\eldes\source\repos\apis\ProbarApp\Servicios\Usuarios.json";

            try
            {
                string jsonUsuarios = File.ReadAllText(pathUsuariosSiguiendo);
                Usuarios[] usuarios = JsonConvert.DeserializeObject<Usuarios[]>(jsonUsuarios);

                string correoRemitente = "r00263439@gmail.com";
                string contraseña = "fait dyfy zqth qazo";

                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                clienteSmtp.Port = 587;
                clienteSmtp.Host = "smtp.gmail.com";
                clienteSmtp.EnableSsl = true;
                clienteSmtp.Credentials = new NetworkCredential(correoRemitente, contraseña);

                foreach (Usuarios usuario in usuarios)
                {
                    if (!string.IsNullOrEmpty(usuario.Email))
                    {
                        MailMessage mensaje = new MailMessage(correoRemitente, usuario.Email);
                        mensaje.From = new MailAddress(correoRemitente, "Tareas");
                        mensaje.Subject = "NOTIFICACION TAREA SEGUIDA";
                        mensaje.Body = "La tarea fue asignada";

                        try
                        {
                            clienteSmtp.Send(mensaje);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
