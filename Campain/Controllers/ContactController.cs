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
        //// GET: api/<ContactController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ContactController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ContactController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ContactController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ContactController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpPost]
       public IActionResult SendMail(Contact1 contact1)
        {
            MailMessage msg = new MailMessage();
          //  var msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("chanylev100@gmail.com");
            msg.To.Add("chanylev100@gmail.com");

            //msg.ReplyToList.Add(string.Concat(recipients, ",", "123@gmail.com"));
            msg.Subject = "Hello from C#:)";
           // msg.Attachments.Add(new System.Net.Mail.Attachment(reportPath));
           // msg.IsBodyHtml = true;
            msg.Body =  contact1.FirstName+ ":שם פרטי"+"\n" + contact1.LastName+ ":שם משפחה" + "\n" + contact1.Email+ ":מייל" + "\n" +contact1.Message+ ":הודעה" ;

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
