using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Common.OtherObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campain.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ContactController : BaseController
    {
 
        [HttpPost]
       public IActionResult SendMail(Contact contact)
        {
            MailMessage msg = new MailMessage();
          //  var msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("chanylev100@gmail.com");
            msg.To.Add("chanylev100@gmail.com");

            //msg.ReplyToList.Add(string.Concat(recipients, ",", "123@gmail.com"));
            msg.Subject = "הודעה מקמפיין רמות";
           // msg.Attachments.Add(new System.Net.Mail.Attachment(reportPath));
           // msg.IsBodyHtml = true;
            msg.Body =  contact.FirstName+ ":שם פרטי"+"\n" + contact.LastName+ ":שם משפחה" + "\n" + contact.Email+ ":מייל" + "\n" +contact.Message+ ":הודעה" ;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential("chanylev100@gmail.com", @"v p u l o c d r u b l w e d b g");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                // Send the email
                client.Send(msg);

                Console.WriteLine("Email sent successfully.");
                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Failed to send email. Error message: " + ex.Message);
                return BadRequest();
            }
        }
    }
}
