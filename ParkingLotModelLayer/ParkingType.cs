using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    public class ParkingType
    {
        [Key]
        public int ParkingId { get; set; }

        [Required]
        public string ParkingTypes { get; set; }
        
        [Required]
        public double Charges { get; set; }
    }
}
