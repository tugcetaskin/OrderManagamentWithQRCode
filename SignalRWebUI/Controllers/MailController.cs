using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.DTOs.MailDTOs;
using MailKit.Net.Smtp;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Pkcs;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(CreateMailDTO mail)
        {
            Index(mail);
            return RedirectToAction("SendMail");
        }
        public static void Index(CreateMailDTO mail)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("DIOVOR", "");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress(mail.ReceiverName, mail.ReceiverEmail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mail.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mail.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("taskintugce97@gmail.com", "zvjv zcfr eyfe jxmf");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
