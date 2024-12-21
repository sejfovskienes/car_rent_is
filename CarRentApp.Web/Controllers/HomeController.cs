using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarRentApp.Domain.Models;
using CarRentApp.Service.Implementation;
using CarRentApp.Service.Interface;

namespace CarRentApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SendTestEmail()
        {
            var emailMessage = new EmailMessage
            {
                MailTo = "enes22seyfovski@gmail.com", 
                Subject = "Test Email",
                Content = "This is a test email sent from the application.",
                Status = true 
            };

            try
            {
                
                await _emailService.SendEmailAsync(emailMessage);

                
                TempData["Message"] = "Test email sent successfully!";
            }
            catch (Exception ex)
            {
                
                TempData["ErrorMessage"] = $"Error sending email: {ex.Message}";
            }

            
            return RedirectToAction("Index");
        }

    }
}
