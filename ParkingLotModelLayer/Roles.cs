using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    public class Roles
    {
        [Required]
        public int RolesId { get; set; }
        
        [Required]
        public string Role { get; set; }
        
        [Required]
        public double Charges { get; set; }
    }
}
