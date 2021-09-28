using System;
using System.Net;
using System.Net.Mail;
using WebApp.Entities;
using WebApp.Interfaces.Services;

namespace WebApp.Services
{
    public class ServiceEmail : IServiceEmail
    {
        public bool EnviarEmail(EmailRemetente Email)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("e-mail", "senha");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("e-mail", "ENVIADOR");
            mail.From = new MailAddress("e-mail", "Nome");
            mail.To.Add(new MailAddress(Email.Email, Email.Nome));
            mail.Subject = Email.Assunto;
            mail.Body = " Mensagem do site:<br/> Nome:  " + Email.Nome + "<br/> Email : " + Email.Email + " <br/> Mensagem : " + Email.Mensagem; 
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                mail = null;
            }    

            return true;
        }
    }
}