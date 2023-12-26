using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

using BLL.Interfaces;
using DAL.Interfaces;
using Entity;
using Entity.Entity;
using System.Net.Mime;

namespace BLL.Implementacion
{
    public class CorreoService : ICorreoService
    {
        private readonly IGenericRepository<Configuracion> _repositorio;

        public CorreoService(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("Servicio_Correo"));

                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);

                var correo = new MailMessage()
                {
                    From = new MailAddress(Config["correo"], Config["alias"]),
                    Subject = Asunto,
                    Body = Mensaje,
                    IsBodyHtml = true
                };

                correo.To.Add(new MailAddress(CorreoDestino));

                var clienteServidor = new SmtpClient()
                {
                    Host = Config["host"],
                    Port = int.Parse(Config["puerto"]),
                    Credentials = credenciales,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };

                clienteServidor.Send(correo);
                return true;
            }
            catch { 
                return false;
            }





            //// Crea un mensaje de correo
            //MailMessage correo = new MailMessage();
            //correo.From = new MailAddress("tu_correo@gmail.com");
            //correo.To.Add("destinatario@example.com");
            //correo.Subject = "Asunto del correo";
            //correo.Body = "Cuerpo del correo";

            //// Adjunta el PDF al correo
            //Attachment pdfAttachment = new Attachment("ruta_del_pdf.pdf", MediaTypeNames.Application.Pdf);
            //correo.Attachments.Add(pdfAttachment);

            //// Envía el correo utilizando SmtpClient (debes configurar tus propios datos SMTP)
            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            //smtpClient.Port = 587;
            //smtpClient.Credentials = new System.Net.NetworkCredential("tu_correo@gmail.com", "tu_contraseña");
            //smtpClient.EnableSsl = true;

            //smtpClient.Send(correo);
        }
    }
}
