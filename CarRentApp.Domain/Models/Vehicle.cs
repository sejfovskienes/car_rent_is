using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Domain.Models
{
    public class Vehicle : BaseEntity
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateOnly? ProductionYear { get; set; }
        public string? FuelType { get; set; }
        public string? VehicleType { get; set; }
        public string? Mileage { get; set; }
        public string? Color { get; set; }
        public string[]? ImageLinks { get; set; } = new string[5];

    }
}
