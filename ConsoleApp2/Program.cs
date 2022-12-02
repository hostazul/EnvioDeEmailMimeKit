using MimeKit;
using System;

namespace EnvioDeEmailMimeKit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Início do envio de e-mail!");
            var meuEmail = "email_de_oriem@seudomnio.com.br";
            var senhaDoMeuEmail = "sua_senha";
            var para = "email_destino@gmail.com";
            var enderecoServidorSMTP = "servidor_smtp.com.br";
            var porta = 465;

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Título do e-mail", meuEmail));
                message.To.Add(new MailboxAddress("Meu Email Destino", para));
                message.Subject = "Teste de envio de e-mail com autenticação";

                message.Body = new TextPart("plain")
                {
                    Text = @"Teste de envio de e-mail"
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(enderecoServidorSMTP, porta, true);
                    client.Authenticate(meuEmail, senhaDoMeuEmail);

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


