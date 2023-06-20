using HotelProject.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressfrom = new MailboxAddress("Hotelier Admin", "eminsusam6@gmail.com");
            mimeMessage.From.Add(mailboxAddressfrom);

            MailboxAddress mailboxAddressto = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressto);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("eminsusam6@gmail.com", "kbbfyolbcgbdjrfh");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
