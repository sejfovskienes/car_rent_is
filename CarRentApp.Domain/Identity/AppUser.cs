using CarRentApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress {  get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserBank { get; set; }
        public string? CardNumber { get; set; }

        // Navigation property for related RentedVehicles
        public virtual ICollection<RentedVehicle>? RentedVehicles { get; set; }

        // changed from IdentityUser to AppUser in Program.cs and LoginPartial view. 
        // control them for sure. 
    }
}
