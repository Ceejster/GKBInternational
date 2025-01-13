using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GKBInternational.Controllers
{
    public class QuoteController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(string Name, string Email, string Message)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Message))
            {
                return BadRequest("Invalid input.");
            }

            try
            {
                // Sanitize input to prevent scripting attacks
                Name = HtmlEncoder.Default.Encode(Name);
                Email = HtmlEncoder.Default.Encode(Email);
                Message = HtmlEncoder.Default.Encode(Message);

                // Send email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@example.com"), // Replace with your email
                    Subject = "New Quote Request",
                    Body = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}",
                    IsBodyHtml = false
                };
                mailMessage.To.Add("work-email@example.com"); // Replace with the work email

                using var smtpClient = new SmtpClient("smtp.example.com") // Replace with your SMTP server
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("your-email@example.com", "your-email-password"),
                    EnableSsl = true
                };

                await smtpClient.SendMailAsync(mailMessage);
                return Json(new { success = true, message = "Quote request submitted successfully!" });
            }
            catch
            {
                return StatusCode(500, "There was an error processing your request.");
            }
        }
    }
}
