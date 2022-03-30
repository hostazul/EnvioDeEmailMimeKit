using MimeKit;
using System;

namespace EnvioDeEmailMimeKit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Início do envio de e-mail!");

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Título do e-mail", "email_de_oriem@seudomnio.com.br"));
                message.To.Add(new MailboxAddress("Meu Email Destino", "email_destino@gmail.com"));
                message.Subject = "Teste de envio de e-mail com autenticação";

                message.Body = new TextPart("plain")
                {
                    Text = @"Teste de envio de e-mail"
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("servidor_smtp.com.br", 465, true);
                    client.Authenticate("email_de_oriem@seudomnio.com.br", "sua_senha");

                    client.Send(message);
                    client.Disconnect(true);
                }

                Console.WriteLine("Email enviado com sucesso!");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Ocorreu o seguinte erro ao enviar o e-mail:{error.Message}");
            }
        }
    }
}


