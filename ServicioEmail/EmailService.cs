using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServicioEmail
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            try
            {
                server = new SmtpClient();
                server.Credentials = new NetworkCredential("862e5cdac3db0e", "****9cd7");
                server.EnableSsl = true;
                server.Port = 2525;
                server.Host = "sandbox.smtp.mailtrap.io";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("noResponder@appPrueba.com");
                email.To.Add(emailDestino);
                email.Subject = asunto;
                email.IsBodyHtml = true;
                email.Body = "<h1>Este es un mail de bienvenida</h1><p>Hola como estas..</p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void enviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
