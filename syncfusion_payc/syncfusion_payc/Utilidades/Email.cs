using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace syncfusion_payc.Utilidades
{
    public class Email
    {
        public static string EnviarEmail(string smtp, int port, string usuario, 
            string passw, string from, string para, string subject, string body)
        {   // Enviar un mail. Retorna si hay error, el texto del error, sino vacio.
            string retorno = "";
            string fecha = DateTime.Now.ToString("yyyy-MMM-dd HH:mm:ss");
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);

                message.From = new MailAddress(from);
                message.To.Add(para);
                message.Subject = subject;
                message.Body = body;
                
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(usuario, passw);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(message);

            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }

        public static string EnviarEmailHtml(string smtp, int port, string usuario,
            string passw, string from, string para, string subject, string body)
        {   // Enviar un mail. Retorna si hay error, el texto del error, sino vacio.
            string retorno = "";
            string fecha = DateTime.Now.ToString("yyyy-MMM-dd HH:mm:ss");
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);

                message.From = new MailAddress(from);
                message.To.Add(para);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(usuario, passw);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(message);

            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }
            return retorno;
        }
    }
}