using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParkingLotModelLayer
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ParkingSLot { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public DateTime EntryTime { get; set; }

        [Required]
        [ForeignKey("VehicleId")]
        public int PVehicleId { get; set; }

        [Required]
        public int PParkingId { get; set; }

        [Required]
        public int PRoleId { get; set; }

        public string Disabled { get; set; }
        
        public DateTime ExitTime { get; set; }

    }
}
