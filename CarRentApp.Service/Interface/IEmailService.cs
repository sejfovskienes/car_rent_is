using CarRentApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage allMails);
    }
}
