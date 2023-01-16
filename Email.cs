using System;
using System.Net.Mail;

namespace diamond
{
    class Email
    {
      public static bool QuestionEmail()
      {
          Console.WriteLine("Deseja enviar o Diamante por email?");
          Console.WriteLine("Digite SIM OU NAO");
          string answer = Console.ReadLine();
          if(answer is null || answer.ToUpper() == "NAO" || answer.ToUpper() == "N") return false;
          if(answer.ToUpper() == "S" || answer.ToUpper() == "SIM") return true;
          return QuestionEmail();
      }

      public static string SendMail(string text)
      {
          Console.WriteLine("Digite o email para o qual deseja enviar o Diamante:");
          string sendMail = Console.ReadLine();
          if(!Utils.CheckIsValidEmail(sendMail))
          {
            return "Email inválido!";
          };
          try
          {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credential =
              new System.Net.NetworkCredential(Constants.EMAIL_CONFIG, Constants.PASSWORD_CONFIG);
            client.EnableSsl = true;
            client.Credentials = credential;

            MailMessage message = new MailMessage(Constants.EMAIL_CONFIG, sendMail);
            message.Subject = "Projeto Diamond - Iury Roque";
            message.Body = text;
            message.IsBodyHtml = false;
            client.Send(message);
            return "Email enviado com sucesso";
          }
          catch (System.Exception ex)
          {
            Console.WriteLine(ex.Message);
            return "Falha no envio de email";
            throw;
          }
      }
    }
}





// using System;
// using System.Collections.Generic;
// using System.Text;
// // using EASendMail; //add EASendMail namespace

// namespace diamond
// {
//     class Email
//     {public static void SendEmail(string letter, string diamond)
//     {
//       SmtpMail oMail = new SmtpMail("TryIt");
//       var from = "imarteste@outlook.com";
//       oMail.From = from;
//       oMail.To = GetEmailToSend();
//       oMail.Subject = "Diamante usando a letra: " + letter + "\n";
//       oMail.TextBody = diamond + Constants.SIGNATURE;
      
//       SmtpServer oServer = new SmtpServer("smtp.office365.com");

//       oServer.User = from;
//       oServer.Password = "teste!@#";
//       oServer.Port = 587;

//       oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

//       try
//       {
//           Console.WriteLine("Iniciando o envio do e-mail...");

//           SmtpClient oSmtp = new SmtpClient();
//           oSmtp.SendMail(oServer, oMail);

//           Console.WriteLine("e-mail enviado com sucesso!");
//       }
//       catch (Exception ex)
//       {
//           Console.WriteLine("Exception caught in SendEmail(): {0}",
//               ex.ToString());
//       }
//     }
//     }
// }